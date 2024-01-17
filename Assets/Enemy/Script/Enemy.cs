using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //적 체력
    public int maxHP;
    //적 현재 체력
    public int currentHP;
    public bool isPuzzlePhase;

    public GameObject Qhit;

    Rigidbody2D rigid;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        anim = GetComponent<Animator>();
        isPuzzlePhase = false;
    }

    // Update is called once per frame
    void Update()
    {
        //적 체력이 0이되면 죽음처리
        if (currentHP == 0)
        {
            gameObject.layer = 10;
            gameObject.tag = "EnemyDie";
            Destroy(gameObject, 2);
            anim.SetBool("isDead", true);
        }

    }

    //플레이어랑 부딪히면 체력감소시킴
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

        //SkillV를 맞으면 피격애니메이션 재생(작동안함)
        else if (other.gameObject.tag == "SkillV")
        {
            anim.SetBool("isHit", true);
        }
        else anim.SetBool("isHit", false);
    }

    //적 체력UI 변경
    public void EnemyChangeHealth(int amount)
    {
        anim.SetBool("isHit", true);
        Invoke("ChangeAnimationAfterDelay", 0.15f);
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);

        Enemy_UIHealthBar.instance.SetValue(currentHP / (float)maxHP);
    }

    private void ChangeAnimationAfterDelay()
    {
        // 3초 후에 애니메이션 상태 변경

        // 변경된 Bool 값을 Animator에 전달
        anim.SetBool("isHit", false);
    }
}
