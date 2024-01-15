using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{

    void Start()
    {
        // ���� �ð� �Ŀ� ����ź �ı�
        Destroy(gameObject,3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾�� �浹 ��
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.ChangeHealth(-5);
                Destroy(gameObject);
            }
        }
    }

}