using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public GameObject Qon;
    public GameObject Qoff;
    public GameObject Won;
    public GameObject Woff;
    public GameObject Eon;
    public GameObject Eoff;
    public GameObject Ron;
    public GameObject Roff;
    public GameObject Von;
    public GameObject Voff;



    //Q��/����
    public void Qchange(bool isQActive)
    {
        if (!isQActive)
        {
            Qon.SetActive(false);
            Qoff.SetActive(true);
        }
        else
        {
            Qoff.SetActive(false);
            Qon.SetActive(true);
        }

    }
    //W��/����
    public void Wchange(bool isWActive)
    {
        if (!isWActive)
        {
            Won.SetActive(false);
            Woff.SetActive(true);
        }
        else
        {
            Woff.SetActive(false);
            Won.SetActive(true);
        }
    }
    //E��/����
    public void Echange(bool isEActive)
    {
        if (!isEActive)
        {
            Eon.SetActive(false);
            Eoff.SetActive(true);
        }
        else
        {
            Eoff.SetActive(false);
            Eon.SetActive(true);
        }
    }
    //R��/����
    public void Rchange(bool isRActive)
    {
        if (!isRActive)
        {
            Ron.SetActive(false);
            Roff.SetActive(true);
        }
        else
        {
            Roff.SetActive(false);
            Ron.SetActive(true);
        }
    }
    //V��/����
    public void Vchange(bool isVActive)
    {
        if (!isVActive)
        {
            Von.SetActive(false);
            Voff.SetActive(true);
        }
        else
        {
            Voff.SetActive(false);
            Von.SetActive(true);
        }
    }

}

