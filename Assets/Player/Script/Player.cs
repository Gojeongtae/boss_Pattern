using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //캐릭터 체력
    public int maxHP;
    //캐릭터 현재 체력
    int currentHP;
    //피격시 무적시간설정
    public float invincibleTime;

    //캐릭터 이동속도
    public float moveSpeed = 3f;
    private float horizontalMovement;
    //멈출떄 미끄러움 조절
    public float stoppingDrag = 2f;
    
    //캐릭터 점프력
    public float jumpPower = 3f;
    //더블점프 방지를 위한 바닥체크
    private bool isGrounded;

    //미사일 충돌이펙트
    public GameObject missilehit;

    //총알 발사간격
    public float fireRate = 0.5f;
    //총알 딜레이?
    private float nextFireTime = 0f;

    //텔포이동횟수count(teleport 스크립트에서 관리)
    public int QCount = 0;
    public int WCount = 0;
    public int ECount = 0;
    public int RCount = 0;
    public int VCountQ = 0;
    public int VCountW = 0;
    public int VCountE = 0;
    public int VCountR = 0;

    //포탈별 쿨타임 갖고있도록
    public bool RedCooltime = true;
    public bool BlueCooltime = true;
    public bool YellowCooltime = true;
    public bool GreenCooltime = true;
    public bool PurpleCooltime = true;

    //각 매니저들 불러오기
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
            bulletmanager.normalAttack();
            anim.SetBool("isShooting", true);
        }
        else anim.SetBool("isShooting", false);

        //Q를 누르면 Q스킬 발동
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextFireTime && QCount >= 3) //빨간텔포 3회 이용시
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillQ();
            anim.SetBool("isShooting", true);
            QCount = 0; //횟수 0으로 만들어주기
            uImanager.Qchange(false); //UIManager에서 아이콘 비활성화
            VCountQ++;
            //Vcount체크
            if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
        }
        else anim.SetBool("isShooting", false);

        //W를 누르면 W스킬 발동
        if (Input.GetKeyDown(KeyCode.W) && Time.time > nextFireTime && WCount >= 3) //파란텔포 3회 이용시
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillW();
            anim.SetBool("isShooting", true);
            WCount = 0; //횟수 0으로 만들어주기
            VCountW++;
            //Vcount체크
            if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
            uImanager.Wchange(false); //UIManager에서 아이콘 비활성화

        }
        else anim.SetBool("isShooting", false);

        //E를 누르면 E스킬 발동
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFireTime && ECount >= 4) //노란텔포 4회 이용시
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillE();
            anim.SetBool("isShooting", true);
            ECount = 0; //횟수 0으로 만들어주기
            VCountE++;
            //Vcount체크
            if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
            uImanager.Echange(false); //UIManager에서 아이콘 비활성화
        }
        else anim.SetBool("isShooting", false);

        //R를 누르면 R스킬 발동
        if (Input.GetKeyDown(KeyCode.R) && Time.time > nextFireTime && RCount >= 5) //초록텔포 5회 이용시
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillR();
            anim.SetBool("isShooting", true);
            RCount = 0; //횟수 0으로 만들어주기
            //Vcount체크
            VCountR++; if (VCountQ >= 1 && VCountW >= 1 && VCountE >= 1 && VCountR >= 1)
            {
                uImanager.Vchange(true);
            }
            uImanager.Rchange(false); //UIManager에서 아이콘 비활성화
        }
        else anim.SetBool("isShooting", false);

        //V를 누르면 V스킬 발동
        if (Input.GetKeyDown(KeyCode.V) && Time.time > nextFireTime && VCountQ >= 1 && VCountW >=1 && VCountE >= 1 && VCountR >= 1) // Q,W,E,R 한번씩 눌렀을때
        {
            nextFireTime = Time.time + 1f / fireRate;
            bulletmanager.SkillV();
            anim.SetBool("isShooting", true);
            VCountQ = 0; //횟수 0으로 만들어주기
            VCountW = 0; //횟수 0으로 만들어주기
            VCountE = 0; //횟수 0으로 만들어주기
            VCountR = 0; //횟수 0으로 만들어주기
            uImanager.Vchange(false); //UIManager에서 아이콘 비활성화
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        //적 총알이랑 닿았을때
        if (collision.gameObject.tag == "EnemyBullet")
        {
            OnDamaged(collision.transform.position);
            anim.SetBool("isHit", true);
        }

        //유도미사일이랑 닿았을때  
        else if (collision.gameObject.tag == "HomingMissile")
        {
            OnDamaged(collision.transform.position);
            anim.SetBool("isHit", true);
            GameObject effect = Instantiate(missilehit, transform.position, transform.rotation);
            Destroy(effect, 0.5f);
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


    //맞으면 반투명해짐 + 튕겨남
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
        Invoke("OffDamaged", invincibleTime);
    }

    //무적시간해제
    void OffDamaged()
    {
        gameObject.layer = 8;
        renderer.color = new Color(1, 1, 1, 1);
    }


    //체력바 UI변경
    public void ChangeHealth(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

}
