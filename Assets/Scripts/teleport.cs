using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    //private bool canTeleport;
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

    //포탈 좀 부드럽게하기위해 플레이어와 거리계산
    public GameObject Player;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");


    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if (distance <= 0.2f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switch (gameObject.name)
                {
                    case "portalRED":
                        if (Player.GetComponent<Player>().RedCooltime)
                        {
                            Player.GetComponent<Player>().RedCooltime = false;
                            Player.transform.position = portalred.transform.position;
                            Player.GetComponent<Player>().QCount++;

                            //빨간텔포를 3번이용하면 UI에서 Q활성화
                            if (Player.GetComponent<Player>().QCount >= 3)
                            {
                                Player.GetComponent<Player>().uImanager.Qchange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().QCount);
                            StartCoroutine(TeleportCooldown("Red", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalred":
                        if (Player.GetComponent<Player>().RedCooltime)
                        {
                            Player.GetComponent<Player>().RedCooltime = false;
                            Player.transform.position = portalRED.transform.position;
                            Player.GetComponent<Player>().QCount++;
                            if (Player.GetComponent<Player>().QCount >= 3)
                            {
                                Player.GetComponent<Player>().uImanager.Qchange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().QCount);
                            StartCoroutine(TeleportCooldown("Red", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalBLUE":
                        if (Player.GetComponent<Player>().BlueCooltime)
                        {
                            Player.GetComponent<Player>().BlueCooltime = false;
                            Player.transform.position = portalblue.transform.position;
                            Player.GetComponent<Player>().WCount++;

                            //파란텔포를 3번이용하면 UI에서 Q활성화
                            if (Player.GetComponent<Player>().WCount >= 3)
                            {
                                Player.GetComponent<Player>().uImanager.Wchange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().WCount);
                            StartCoroutine(TeleportCooldown("Blue", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalblue":
                        if (Player.GetComponent<Player>().BlueCooltime)
                        {
                            Player.GetComponent<Player>().BlueCooltime = false;
                            Player.transform.position = portalBLUE.transform.position;
                            Player.GetComponent<Player>().WCount++;

                            //파란텔포를 3번이용하면 UI에서 W활성화
                            if (Player.GetComponent<Player>().WCount >= 3)
                            {
                                Player.GetComponent<Player>().uImanager.Wchange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().WCount);
                            StartCoroutine(TeleportCooldown("Blue", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalYellow":
                        if (Player.GetComponent<Player>().YellowCooltime)
                        {
                            Player.GetComponent<Player>().YellowCooltime = false;
                            Player.transform.position = portalyellow.transform.position;
                            Player.GetComponent<Player>().ECount++;

                            //노란텔포를 3번이용하면 UI에서 E활성화
                            if (Player.GetComponent<Player>().ECount >= 4)
                            {
                                Player.GetComponent<Player>().uImanager.Echange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().ECount);
                            StartCoroutine(TeleportCooldown("Yellow", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalyellow":
                        if (Player.GetComponent<Player>().YellowCooltime)
                        {
                            Player.GetComponent<Player>().YellowCooltime = false;
                            Player.transform.position = portalYELLOW.transform.position;
                            Player.GetComponent<Player>().ECount++;

                            //노란텔포를 3번이용하면 UI에서 E활성화
                            if (Player.GetComponent<Player>().ECount >= 4)
                            {
                                Player.GetComponent<Player>().uImanager.Echange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().ECount);
                            StartCoroutine(TeleportCooldown("Yellow", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalGREEN":
                        if (Player.GetComponent<Player>().GreenCooltime)
                        {
                            Player.GetComponent<Player>().GreenCooltime = false;
                            Player.transform.position = portalgreen.transform.position;
                            Player.GetComponent<Player>().RCount++;

                            //초록텔포를 3번이용하면 UI에서 R활성화
                            if (Player.GetComponent<Player>().RCount >= 5)
                            {
                                Player.GetComponent<Player>().uImanager.Rchange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().RCount);
                            StartCoroutine(TeleportCooldown("Green", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalgreen":
                        if (Player.GetComponent<Player>().GreenCooltime)
                        {
                            Player.GetComponent<Player>().GreenCooltime = false;
                            Player.transform.position = portalGREEN.transform.position;
                            Player.GetComponent<Player>().RCount++;

                            //초록텔포를 3번이용하면 UI에서 R활성화
                            if (Player.GetComponent<Player>().RCount >= 5)
                            {
                                Player.GetComponent<Player>().uImanager.Rchange(true);
                            }

                            //Debug.Log(Player.GetComponent<Player>().RCount);
                            StartCoroutine(TeleportCooldown("Green", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalPURPLE":
                        if (Player.GetComponent<Player>().PurpleCooltime)
                        {
                            Player.GetComponent<Player>().PurpleCooltime = false;
                            Player.transform.position = portalpurple.transform.position;
                            StartCoroutine(TeleportCooldown("Purple", Player.GetComponent<Player>()));
                        }
                        break;

                    case "portalpurple":
                        if (Player.GetComponent<Player>().PurpleCooltime)
                        {
                            Player.GetComponent<Player>().PurpleCooltime = false;
                            Player.transform.position = portalPURPLE.transform.position;
                            StartCoroutine(TeleportCooldown("Purple", Player.GetComponent<Player>()));
                        }
                        break;
                }

            }
        }


        //텔레포트 쿨타임
        IEnumerator TeleportCooldown(string Color, Player player)
        {
            yield return new WaitForSeconds(1f);

            if (Color == "Red")
            {
                player.RedCooltime = true;
            }
            else if (Color == "Blue")
            {
                player.BlueCooltime = true;
            }
            else if (Color == "Yellow")
            {
                player.YellowCooltime = true;
            }
            else if (Color == "Green")
            {
                player.GreenCooltime = true;
            }
            else if (Color == "Purple")
            {
                player.PurpleCooltime = true;
            }
        }
    }
}
