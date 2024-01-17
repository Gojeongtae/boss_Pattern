using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�Ѿ� �ӵ�
    public float speed;
    //�Ѿ� ������(�������� BulletManager���� ����)
    public int damage;

    private bool m_PlayerLookRight = false;

    //�ش�Ÿ��� �Ǹ� ���� �ε��� �Ǵ�
    private float distance = 0.2f;
    public LayerMask isLayer;

    Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        //2�ʵڿ� �Ѿ�����
        Destroy(gameObject, 4);

        //ĳ���Ͱ� �ٶ󺸴� �������� �Ѿ˳���
        if (GameObject.Find("Player").transform.localScale.x < 0)
            m_PlayerLookRight = false;
        else
            m_PlayerLookRight = true;

        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //�Ѿ��� �ٶ󺸴� �������� �߻�ǵ���
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

        //���� �ε��� �Ǵ�
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider)
        {
            if (ray.collider.tag == "Enemy")
            {
                Enemy enemy = ray.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.EnemyChangeHealth(-damage); //�� ü���� -damge��ŭ ���ҽ�Ŵ
                }
                DestroyBullet();
            }
            //(����)���ÿ� �ε���
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
            //(����)���� �ε���
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

