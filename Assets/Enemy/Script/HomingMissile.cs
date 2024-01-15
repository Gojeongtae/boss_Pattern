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


    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rigid.position; //타겟과 벡터거리를 구함

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.right).z;

        rigid.angularVelocity = -rotateAmount * rotateSpeed; //회전력

        rigid.velocity = transform.right * speed;//미사일이 오른쪽을 향함

        ////플레이어와 부딪힘 판단
        //RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        //if (ray.collider)
        //{
        //    if (ray.collider.tag == "Player")
        //    {
        //        Player player = ray.collider.gameObject.GetComponent<Player>();
        //        if (player != null)
        //        {
        //            player.ChangeHealth(-damage); //플레이어 체력을 -damge만큼 감소시킴
        //            Debug.Log(damage);
        //        }
        //        DestroyMissile();
        //        Effect();
        //    }
        //}
    }

    //void DestroyMissile()
    //{
    //    Destroy(gameObject);
    //}

    //void Effect()
    //{
    //    Instantiate(hiteffect, transform.position, transform.rotation);
    //    Destroy(hiteffect,2);
    //}
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
        //void DestroyEffect()
        //{
        //    Destroy(hiteffect, 1);
        //}
    }
}
