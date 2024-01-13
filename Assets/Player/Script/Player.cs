using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ĳ���� ü��
    public int maxHP;
    //ĳ���� ���� ü��
    int currentHP;

    //ĳ���� �̵��ӵ�
    public float moveSpeed = 3f;
    private float horizontalMovement;
    //���⋚ �̲����� ����
    public float stoppingDrag = 2f;
    
    //ĳ���� ������
    public float jumpPower = 3f;
    //�������� ������ ���� �ٴ�üũ
    private bool isGrounded;

    //�Ѿ� ���ݷ�
    public int BulletDmg;
    //�Ѿ˻���
    public Transform BulletSpawnPos;
    public GameObject bulletPrefab;
    //�Ѿ˼ӵ�
    public float bulletSpeed = 10f;
    //�Ѿ� �߻簣��
    public float fireRate = 0.5f;
    //�Ѿ� ������?
    private float nextFireTime = 0f;


    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        BulletDmg = 10;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponentInChildren<Animator>();
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //�̵� Ű ������ �� ĳ���� �¿��̵�
        horizontalMovement = Input.GetAxis("Horizontal");
        
        //C���������� IsGrounded�� true�϶� ����ȣ��
        if (Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            Jump();
        }

        //�ȴ� �ִϸ��̼����� ��ȯ
        //�ӵ��� ���밪 0.3���ϸ� �ִϸ��̼� ���ߵ���
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("isMoving", false);
        }
        else anim.SetBool("isMoving", true);

        //X�� ������ �Ѿ��� �߻�
        if (Input.GetKeyDown(KeyCode.X) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
            anim.SetBool("isShooting", true);
        }
        else anim.SetBool("isShooting", false);
    }

    void FixedUpdate()
    {
        Move();
        //���� �� �̲����� ����
        ApplyStoppingDrag();
    }

    void Move()
    {
        //�̵� ���⿡ ���� ĳ���� �̵�
        Vector2 movement = new Vector2(horizontalMovement, 0f);
        rigid.velocity = new Vector2(movement.x * moveSpeed, rigid.velocity.y);

        //�̵� ���⿡ ���� ĳ���� ���� ��ȯ
        FlipCharacter(horizontalMovement);
    }

    //�̵� ���⿡ ���� ĳ���� ���� ��ȯ
    void FlipCharacter(float horizontal)
    {
        // �̵� ������ ���������� ���������� ���� ĳ���� ���� ��ȯ
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f); // ������ ����
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // ���� ����
        }
    }

    //���� �� �̲����� ����
    void ApplyStoppingDrag()
    {
        // ĳ���Ͱ� ���� �� �̲������� ����(�۵��ȵǴ°Ű���;)
        if (horizontalMovement == 0f)
        {
            rigid.drag = stoppingDrag;
        }
        else
        {
            rigid.drag = 0f;
        }
    }
    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        anim.SetBool("isJumping", true);
    }

    //�±׶� ������� ȣ��
    void OnCollisionEnter2D(Collision2D collision)
    {
        //���̶� �������
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        //���̶� �������
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
            anim.SetBool("isHit", true);
        }
        else anim.SetBool("isHit", false);

    }

    //Ground �±׿��� ����� �� ȣ��
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    //�Ѿ˻���
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, BulletSpawnPos.position, Quaternion.identity);
    }


    //������ ������ ���������� + ƨ�ܳ�
    void OnDamaged(Vector2 targetPos)
    {
        //���̾� ü����
        gameObject.layer = 9;
        //���ٲٱ�
        renderer.color = new Color(1, 1, 1, 0.4f);
        //ƨ�ܳ�
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);
        
        //�����ð�
        Invoke("OffDamaged", 3);
    }
    void OffDamaged()
    {
        gameObject.layer = 8;
        renderer.color = new Color(1, 1, 1, 1);
    }


    //ü�º���
    public void ChangeHealth(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);

        UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

}
