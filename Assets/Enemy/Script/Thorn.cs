using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    //���� ���� Ÿ�� Ƚ��
    public int curThornhitcount;
    //���� Ÿ�ݿ� �ʿ��� Ƚ��
    public int maxThornhitcount;

    //ui
    //[SerializeField] GameObject hpbar;

    void Start()
    {
        curThornhitcount = maxThornhitcount;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //public void hitThorn()
    //{
    //    curThornhitcount++;
    //}
    public void ChangeHealth(int amount)
    {
       curThornhitcount = Mathf.Clamp(curThornhitcount + amount, 0, maxThornhitcount);
       ThornHPbar.instance.SetValue(curThornhitcount / (float)maxThornhitcount);
    }

}