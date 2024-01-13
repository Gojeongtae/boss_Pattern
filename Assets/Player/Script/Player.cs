using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //캐릭터 체력
    public int maxHP;
    //캐릭터 현재 체력
    int currentHP;

    //캐릭터 이동속도
    public float moveSpeed = 3f;
    private float horizontalMovement;
    //멈출떄 미끄러움 조절
    public float stoppingDrag = 2f;
    
    //캐릭터 점프력
    public float jumpPower = 3f;
    //더블점프 방지를 위한 바닥체크
    private bool isGrounded;

    //총알 공격력
    public int BulletDmg;
    //총알생성
    public Transform BulletSpawnPos;
    public GameObject bulletPrefab;
    //총알속도
    public float bulletSpeed = 10f;
    //총알 발사간격
    public float fireRate = 0.5f;
    //총알 딜레이?
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
        //이동 키 눌렀을 때 캐릭터 좌우이동
        horizontalMovement = Input.GetAxis("Horizontal");
        
        //C눌렀을때와 IsGrounded가 true일때 점프호출
        if (Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            Jump();
        }

        //걷는 애니메이션으로 전환
        //속도가 절대값 0.3이하면 애니메이션 멈추도록
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("isMoving", false);
        }
        else anim.SetBool("isMoving", true);

        //X를 누르면 총알을 발사
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
        //멈출 때 미끄러움 방지
        ApplyStoppingDrag();
    }

    void Move()
    {
        //이동 방향에 따라 캐릭터 이동
        Vector2 movement = new Vector2(horizontalMovement, 0f);
        rigid.velocity = new Vector2(movement.x * moveSpeed, rigid.velocity.y);

        //이동 방향에 따라 캐릭터 방향 전환
        FlipCharacter(horizontalMovement);
    }

    //이동 방향에 따라 캐릭터 방향 전환
    void FlipCharacter(float horizontal)
    {
        // 이동 방향이 오른쪽인지 왼쪽인지에 따라 캐릭터 방향 전환
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f); // 오른쪽 방향
        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // 왼쪽 방향
        }
    }

    //멈출 때 미끄러짐 방지
    void ApplyStoppingDrag()
    {
        // 캐릭터가 멈출 때 미끄러움을 적용(작동안되는거같음;)
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

    //태그랑 닿았을때 호출
    void OnCollisionEnter2D(Collision2D collision)
    {
        //땅이랑 닿았을때
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        //적이랑 닿았을때
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
            anim.SetBool("isHit", true);
        }
        else anim.SetBool("isHit", false);

    }

    //Ground 태그에서 벗어났을 때 호출
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    //총알생성
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, BulletSpawnPos.position, Quaternion.identity);
    }


    //보스에 맞으면 반투명해짐 + 튕겨남
    void OnDamaged(Vector2 targetPos)
    {
        //레이어 체인지
        gameObject.layer = 9;
        //색바꾸기
        renderer.color = new Color(1, 1, 1, 0.4f);
        //튕겨남
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);
        
        //무적시간
        Invoke("OffDamaged", 3);
    }
    void OffDamaged()
    {
        gameObject.layer = 8;
        renderer.color = new Color(1, 1, 1, 1);
    }


    //체력변경
    public void ChangeHealth(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);

        UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

}
