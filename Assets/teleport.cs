using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    private bool canTeleport = true;
    public GameObject portalRED;
    public GameObject portalred;
    public GameObject portalBLUE;
    public GameObject portalblue;
    public GameObject portalYELLOW;
    public GameObject portalyellow;
    public GameObject portalGREEN;
    public GameObject portalgreen;
    public GameObject portalPURPLE;
    public GameObject portalpurple;


    // Start is called before the first frame update
    void Start()
    {



    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (canTeleport && other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("aa");
            switch (gameObject.name)
            {
                case "portalRED":
                    Debug.Log("Teleporting from RED to red");
                    other.transform.position = portalred.transform.position;
                    StartCoroutine(TeleportCooldown());
                    break;

                case "portalred":
                    Debug.Log("Teleporting from red to RED");
                    other.transform.position = portalRED.transform.position;
                    StartCoroutine(TeleportCooldown());
                    break;
                case "portalBLUE":
                        Debug.Log("Teleporting from BLUE to blue");
                        other.transform.position = portalblue.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;
                case "portalblue":
                        Debug.Log("Teleporting from blue to BLUE");
                        other.transform.position = portalBLUE.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;
                case "portalYellow":
                        Debug.Log("Teleporting from YELLOW to yellow");
                        other.transform.position = portalyellow.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;
                    case "portalyellow":
                        Debug.Log("Teleporting from yellow to YELLOW");
                        other.transform.position = portalYELLOW.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;
                    case "portalGREEN":
                        Debug.Log("Teleporting from GREEN to green");
                        other.transform.position = portalgreen.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;
                    case "portalgreen":
                        Debug.Log("Teleporting from green to GREEN");
                        other.transform.position = portalgreen.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;
                    case "portalPURPLE":
                        Debug.Log("Teleporting from PURPLE to purple");
                        other.transform.position = portalpurple.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;
                    case "portalpurple":
                        Debug.Log("Teleporting from purple to PURPLE");
                        other.transform.position = portalPURPLE.transform.position;
                        StartCoroutine(TeleportCooldown());
                        break;


                }
            }
        }

    }

    IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(3f);
        canTeleport = true;
    }
}
