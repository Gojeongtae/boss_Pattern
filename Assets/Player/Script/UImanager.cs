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


    //Q온/오프
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
    //W온/오프
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
    //E온/오프
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
    //R온/오프
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
}

