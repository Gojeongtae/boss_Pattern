using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{

    void Start()
    {
        // 일정 시간 후에 유도탄 파괴
        Destroy(gameObject,3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 충돌 시
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