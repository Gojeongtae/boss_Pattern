using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //��ų������
    public GameObject Normal;
    public GameObject PrefabQ;
    public GameObject PrefabW;
    public GameObject PrefabE;
    public GameObject PrefabR;
    public GameObject PrefabV;

    public Transform spawnPos;


    //�Ϲݰ���
    public void normalAttack()
    {
        GameObject bullet = Instantiate(Normal , spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 10; //�Ϲݰ��� ������
    }
    
    //Q��ų
    public void SkillQ()
    {
        GameObject bullet = Instantiate(PrefabQ, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 20; //Q��ų ������
    }

    //W��ų
    public void SkillW()
    {
        GameObject bullet = Instantiate(PrefabW, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 40; //W��ų ������
    }

    //E��ų
    public void SkillE()
    {
        GameObject bullet = Instantiate(PrefabE, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 60; //E��ų ������
    }

    //W��ų
    public void SkillR()
    {
        GameObject bullet = Instantiate(PrefabR, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 100; //R��ų ������
    }

    public void SkillV()
    {
        GameObject bullet = Instantiate(PrefabV, spawnPos.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().damage = 200; //V��ų ������
    }

}
