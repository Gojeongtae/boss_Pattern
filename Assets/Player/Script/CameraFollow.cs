using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{// 카메라가 따라다닐 대상
    public Transform target;

    // 카메라가 대상을 따라가는 속도
    public float smooth = 0.1f;

    // 카메라 위치 조정
    public Vector3 adjustCamPos;

    // 카메라 경계 설정
    public Vector2 minCamLimit;
    public Vector2 maxCamLimit;
    ////카메라 속도
    //public float cameraSpeed = 5f;

    ////카메라 대상
    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //    Vector3 dir = player.transform.position - this.transform.position;
        //   Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        //    this.transform.Translate(moveVector);
        if(target == null) return;

        // 카메라의 대상 위치간의 보간
        Vector3 pos = Vector3.Lerp(transform.position, target.position, smooth);

        // 대상과 한계 위치에 따른 카메라 위치
        transform.position = new Vector3(
           Mathf.Clamp(pos.x, minCamLimit.x, maxCamLimit.x) + adjustCamPos.x,
           Mathf.Clamp(pos.y, minCamLimit.y, maxCamLimit.y) + adjustCamPos.y,
           -10f + adjustCamPos.z);
    }



}
