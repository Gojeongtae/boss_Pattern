using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //�� ü��
    public int maxHP;
    //�� ���� ü��
    int currentHP;

    public GameObject Qhit;

    Rigidbody2D rigid;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�� ü���� 0�̵Ǹ� ����ó��
        if (currentHP == 0)
        {
            gameObject.layer = 10;
            gameObject.tag = "EnemyDie";
            Destroy(gameObject, 2);
            anim.SetBool("isDead", true);
        }
        

    }

    //�÷��̾�� �ε����� ü�°��ҽ�Ŵ
    void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.ChangeHealth(-10);
        }

        if (other.gameObject.tag == "SkillQ")
        {
            Instantiate(Qhit,transform.position, Quaternion.identity);
            Destroy(gameObject,2);
        }
    }

    //�� ü��UI ����
    public void EnemyChangeHealth(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);

        Enemy_UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
        Debug.Log(currentHP);
    }

}
