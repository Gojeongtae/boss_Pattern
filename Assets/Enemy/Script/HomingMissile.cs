using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotateSpeed;
    public GameObject hiteffect;
    public float distance;
    public LayerMask isLayer;
    public int damage;

    //미사일 폭발 이펙트
    public GameObject boom;


    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }

        rigid = GetComponent<Rigidbody2D>();

        //3초 뒤 미사일 제거
        Destroy(gameObject, 5);

        Invoke("effect", 4.99f);
    }


    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rigid.position; //타겟과 벡터거리를 구함

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.right).z;

        rigid.angularVelocity = -rotateAmount * rotateSpeed; //회전력

        rigid.velocity = transform.right * speed;//미사일이 오른쪽을 향함


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어와 충돌 시
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.ChangeHealth(-damage);
                Debug.Log(damage);
                Destroy(gameObject);
            }
        }
    }
    void effect()
    {
        GameObject boomeffect = Instantiate(boom, transform.position, transform.rotation);
        Destroy(boomeffect, 0.5f);
    }
}
