using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알 속도
    public float speed;
    //총알 데미지(데미지는 BulletManager에서 관리)
    public int damage;

    private bool m_PlayerLookRight = false;

    //해당거리가 되면 적과 부딪힘 판단
    private float distance = 0.2f;
    public LayerMask isLayer;

    Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        //2초뒤에 총알제거
        Destroy(gameObject, 4);

        //캐릭터가 바라보는 방향으로 총알나감
        if (GameObject.Find("Player").transform.localScale.x < 0)
            m_PlayerLookRight = false;
        else
            m_PlayerLookRight = true;

        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //총알이 바라보는 방향으로 발사되도록
        if (!m_PlayerLookRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.Translate(Vector2.right * -1 * speed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }

        //적과 부딪힘 판단
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider)
        {
            if (ray.collider.tag == "Enemy")
            {
                Enemy enemy = ray.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.EnemyChangeHealth(-damage); //적 체력을 -damge만큼 감소시킴
                }
                DestroyBullet();
            }
            //(퍼즐)가시와 부딪힘
            else if (ray.collider.tag == "Thorn")
            {
                Thorn thorn = ray.collider.gameObject.GetComponent<Thorn>();
                //ray.collider.gameObject.GetComponent<Thorn>().hitThorn();
                //if (thorn != null)
                //{
                //    thorn.ChangeHealth(1);
                //}
                Destroy(gameObject);
            }
            //(퍼즐)벽과 부딪힘
            else if (ray.collider.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

