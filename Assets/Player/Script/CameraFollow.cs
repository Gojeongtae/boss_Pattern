using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{// ī�޶� ����ٴ� ���
    public Transform target;

    // ī�޶� ����� ���󰡴� �ӵ�
    public float smooth = 0.1f;

    // ī�޶� ��ġ ����
    public Vector3 adjustCamPos;

    // ī�޶� ��� ����
    public Vector2 minCamLimit;
    public Vector2 maxCamLimit;
    ////ī�޶� �ӵ�
    //public float cameraSpeed = 5f;

    ////ī�޶� ���
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

        // ī�޶��� ��� ��ġ���� ����
        Vector3 pos = Vector3.Lerp(transform.position, target.position, smooth);

        // ���� �Ѱ� ��ġ�� ���� ī�޶� ��ġ
        transform.position = new Vector3(
           Mathf.Clamp(pos.x, minCamLimit.x, maxCamLimit.x) + adjustCamPos.x,
           Mathf.Clamp(pos.y, minCamLimit.y, maxCamLimit.y) + adjustCamPos.y,
           -10f + adjustCamPos.z);
    }



}
