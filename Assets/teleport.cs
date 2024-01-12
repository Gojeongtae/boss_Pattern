using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    private bool canTeleport = true;
    public GameObject portalA;
    public GameObject portalB;


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
                case "portalA":
                    Debug.Log("Teleporting from A to B");
                    other.transform.position = portalB.transform.position;
                    StartCoroutine(TeleportCooldown());
                    break;

                case "portalB":
                    Debug.Log("Teleporting from B to A");
                    other.transform.position = portalA.transform.position;
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
