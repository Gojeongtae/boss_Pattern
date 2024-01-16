using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ĳ���� ü��
    public int maxHP;
    //ĳ���� ���� ü��
    int currentHP;
    //�ǰݽ� �����ð�����
    public float invincibleTime;

    //ĳ���� �̵��ӵ�
    public float moveSpeed = 3f;
    private float horizontalMovement;
    //���⋚ �̲����� ����
    public float stoppingDrag = 2f;
    
    //ĳ���� ������
    public float jumpPower = 3f;
    //�������� ������ ���� �ٴ�üũ
    private bool isGrounded;

    //�̻��� �浹����Ʈ
    public GameObject missilehit;

    //�Ѿ� �߻簣��
    public float fireRate = 0.5f;
    //�Ѿ� ������?
    private float nextFireTime = 0f;

    //�����̵�Ƚ��count(teleport ��ũ��Ʈ���� ����)
    public int QCount = 0;
    public int WCount = 0;
    public int ECount = 0;
    public int RCount = 0;
    public int VCountQ = 0;
    public int VCountW = 0;
    public int VCountE = 0;
    public int VCountR = 0;

    //��Ż�� ��Ÿ�� �����ֵ���
    public bool RedCooltime = true;
    public bool BlueCooltime = true;
    public bool YellowCooltime = true;
    public bool GreenCooltime = true;
    public bool PurpleCooltime = true;

    //�� �Ŵ����� �ҷ�����
    public BulletManager bulletmanager;
    public UImanager uImanager;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
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
            bulletmanager.normalAttack();
            anim.SetBool("isShooting", true);
        }
        else anim.SetBool("isShooting", false);

        //Q�� ������ Q��ų �ߵ�
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextFireTime && QCount >= 3) //�������� 3ȸ �̿��
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillQ();
            anim.SetBool("isShooting", true);
            QCount = 0; //Ƚ�� 0���� ������ֱ�
            uImanager.Qchange(false); //UIManager���� ������ ��Ȱ��ȭ
            VCountQ++;
            //Vcountüũ
            if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
        }
        else anim.SetBool("isShooting", false);

        //W�� ������ W��ų �ߵ�
        if (Input.GetKeyDown(KeyCode.W) && Time.time > nextFireTime && WCount >= 3) //�Ķ����� 3ȸ �̿��
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillW();
            anim.SetBool("isShooting", true);
            WCount = 0; //Ƚ�� 0���� ������ֱ�
            VCountW++;
            //Vcountüũ
            if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
            uImanager.Wchange(false); //UIManager���� ������ ��Ȱ��ȭ

        }
        else anim.SetBool("isShooting", false);

        //E�� ������ E��ų �ߵ�
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFireTime && ECount >= 4) //������� 4ȸ �̿��
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillE();
            anim.SetBool("isShooting", true);
            ECount = 0; //Ƚ�� 0���� ������ֱ�
            VCountE++;
            //Vcountüũ
            if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
            uImanager.Echange(false); //UIManager���� ������ ��Ȱ��ȭ
        }
        else anim.SetBool("isShooting", false);

        //R�� ������ R��ų �ߵ�
        if (Input.GetKeyDown(KeyCode.R) && Time.time > nextFireTime && RCount >= 5) //�ʷ����� 5ȸ �̿��
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillR();
            anim.SetBool("isShooting", true);
            RCount = 0; //Ƚ�� 0���� ������ֱ�
            //Vcountüũ
            VCountR++; if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
            uImanager.Rchange(false); //UIManager���� ������ ��Ȱ��ȭ
        }
        else anim.SetBool("isShooting", false);

        //V�� ������ V��ų �ߵ�
        if (Input.GetKeyDown(KeyCode.V) && Time.time > nextFireTime && VCountQ >= 1 && VCountW >=1 && VCountE >= 1 && VCountR >= 1) // Q,W,E,R �ѹ��� ��������
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillV();
            anim.SetBool("isShooting", true);
            VCountQ = 0; //Ƚ�� 0���� ������ֱ�
            VCountW = 0; //Ƚ�� 0���� ������ֱ�
            VCountE = 0; //Ƚ�� 0���� ������ֱ�
            VCountR = 0; //Ƚ�� 0���� ������ֱ�
            uImanager.Vchange(false); //UIManager���� ������ ��Ȱ��ȭ
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        //�� �Ѿ��̶� �������
        if (collision.gameObject.tag == "EnemyBullet")
        {
            OnDamaged(collision.transform.position);
            anim.SetBool("isHit", true);
        }

        //�����̻����̶� �������  
        else if (collision.gameObject.tag == "HomingMissile")
        {
            OnDamaged(collision.transform.position);
            anim.SetBool("isHit", true);
            GameObject effect = Instantiate(missilehit, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
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


    //������ ���������� + ƨ�ܳ�
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
        Invoke("OffDamaged", invincibleTime);
    }

    //�����ð�����
    void OffDamaged()
    {
        gameObject.layer = 8;
        renderer.color = new Color(1, 1, 1, 1);
    }


    //ü�¹� UI����
    public void ChangeHealth(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

}
