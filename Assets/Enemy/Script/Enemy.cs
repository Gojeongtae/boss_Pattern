using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //적 체력
    public int maxHP;
    //적 현재 체력
    int currentHP;


    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP == 0)
        {
            gameObject.layer = 10;
            gameObject.tag = "EnemyDie";
            Destroy(gameObject, 2);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.ChangeHealth(-10);
        }
    }
    public void EnemyChangeHealth(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);

        Enemy_UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

}
