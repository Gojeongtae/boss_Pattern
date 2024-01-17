using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePhase : MonoBehaviour
{
    //페이즈 시작 시 활성화되는 가시
    public GameObject Thorn;
    public GameObject arrow;   
    //실패 시 이펙트
    public GameObject BigThorn;
    public Transform thornUpPos;

    public GameObject Player;

    //페이즈 시작 시 활성화되는 벽
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;

    //페이즈 시간
    public float PhaseTimer;

    //ui활성화
    public GameObject puzzletimer; //남은시간
    //public GameObject thornHPbar; //가시

    //플레이어 강제 이동 좌표
    public Transform PuzzlePhasePos;

    //코루틴
    public IEnumerator puzzleco;

    // Start is called before the first frame update
    void Start()
    {
        puzzleco = TimeOut();
        Player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //가시를 max회때렸을때 페이즈종료
        if (Thorn.GetComponent<Thorn>().curThornhitcount <= 0)
        {
            FinPhase();
            Thorn.GetComponent<Thorn>().curThornhitcount = 0;
            StopCoroutine(puzzleco);
        }

    }

    //퍼즐페이즈 시작
    public void PhaseStart()
    {
        //ui활성화
        puzzletimer.SetActive(true);//남은시간
        //thornHPbar.SetActive(true);//가시hp

        //벽 활성화
        Wall1.SetActive(true);
        Wall2.SetActive(true);
        Wall3.SetActive(true);
        Wall4.SetActive(true);

        //가시 활성화
        Thorn.SetActive(true);
        arrow.SetActive(true);

        //플레이어 강제이동
        Player.transform.position = PuzzlePhasePos.position;

        //n초 뒤에 끝난다
        StartCoroutine(puzzleco);
        
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(PhaseTimer);
        FinPhase();

        GameObject thorneffect = Instantiate(BigThorn, thornUpPos.position, thornUpPos.rotation);
        Destroy(thorneffect, 0.9f);

        //퍼즐 페이즈가 종료되면 플레이어 피격,체력닳게
        GameObject.Find("Player").GetComponent<Player>().OnDamaged(gameObject.transform.position);
        GameObject.Find("Player").GetComponent<Player>().ChangeHealth(-30);//체력감소
    }

    void FinPhase()
    {
        //ui비활성화
        puzzletimer.SetActive(false);//남은시간
        //thornHPbar.SetActive(false); //가시

        //벽 비활성화
        Wall1.SetActive(false);
        Wall2.SetActive(false);
        Wall3.SetActive(false);
        Wall4.SetActive(false);

        //가시 비활성화
        Thorn.SetActive(false);
        arrow.SetActive(false);

        //보스 렌더링,콜라이더 다시 켜주기
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;

        //퍼즐페이즈 종료호출
        gameObject.GetComponent<Bossccontro>().isPattern3 = false;
    }

}
