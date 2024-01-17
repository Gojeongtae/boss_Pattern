using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    //현재 가시 타격 횟수
    public int curThornhitcount;
    //가시 타격에 필요한 횟수
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