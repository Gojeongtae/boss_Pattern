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
        Vector2 direction = (Vector2)target.position - rigid.position; //Ÿ�ٰ� ���ͰŸ��� ����

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.right).z;

        rigid.angularVelocity = -rotateAmount * rotateSpeed; //ȸ����

        rigid.velocity = transform.right * speed;//�̻����� �������� ����

        ////�÷��̾�� �ε��� �Ǵ�
        //RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        //if (ray.collider)
        //{
        //    if (ray.collider.tag == "Player")
        //    {
        //        Player player = ray.collider.gameObject.GetComponent<Player>();
        //        if (player != null)
        //        {
        //            player.ChangeHealth(-damage); //�÷��̾� ü���� -damge��ŭ ���ҽ�Ŵ
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
        // �÷��̾�� �浹 ��
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
