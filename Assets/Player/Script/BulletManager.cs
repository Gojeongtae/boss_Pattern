using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //스킬프리팹
    public GameObject Normal;
    public GameObject PrefabQ;
    public GameObject PrefabW;
    public GameObject PrefabE;
    public GameObject PrefabR;
    public GameObject PrefabV;

    public Transform spawnPos;


    //일반공격
    public void normalAttack()
    {
        GameObject bullet = Instantiate(Normal , spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 10; //일반공격 데미지
    }
    
    //Q스킬
    public void SkillQ()
    {
        GameObject bullet = Instantiate(PrefabQ, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 20; //Q스킬 데미지
    }

    //W스킬
    public void SkillW()
    {
        GameObject bullet = Instantiate(PrefabW, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 40; //W스킬 데미지
    }

    //E스킬
    public void SkillE()
    {
        GameObject bullet = Instantiate(PrefabE, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 60; //E스킬 데미지
    }

    //W스킬
    public void SkillR()
    {
        GameObject bullet = Instantiate(PrefabR, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 100; //R스킬 데미지
    }

    public void SkillV()
    {
        GameObject bullet = Instantiate(PrefabV, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 200; //V스킬 데미지
    }

}
