using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�Ѿ� �ӵ�
    public float speed = 1f;

    private bool m_PlayerLookRight = false;

    public float distance;
    public LayerMask isLayer;

    Rigidbody2D rigid;


    // Start is called before the first frame update
    void Start()
    {
        //2�ʵڿ� �Ѿ�����
        Destroy(gameObject, 2);

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
        }
        else
        {
            transform.Translate(Vector2.right * -1 * speed * Time.deltaTime);
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
                    enemy.EnemyChangeHealth(-15);
                }
                DestroyBullet();
            }
        }

        void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}