using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePhase : MonoBehaviour
{
    //������ ���� �� Ȱ��ȭ�Ǵ� ����
    public GameObject Thorn;
    public GameObject arrow;   
    //���� �� ����Ʈ
    public GameObject BigThorn;
    public Transform thornUpPos;

    public GameObject Player;

    //������ ���� �� Ȱ��ȭ�Ǵ� ��
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;

    //������ �ð�
    public float PhaseTimer;

    //uiȰ��ȭ
    public GameObject puzzletimer; //�����ð�
    //public GameObject thornHPbar; //����

    //�÷��̾� ���� �̵� ��ǥ
    public Transform PuzzlePhasePos;

    //�ڷ�ƾ
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
        //���ø� maxȸ�������� ����������
        if (Thorn.GetComponent<Thorn>().curThornhitcount <= 0)
        {
            FinPhase();
            Thorn.GetComponent<Thorn>().curThornhitcount = 0;
            StopCoroutine(puzzleco);
        }

    }

    //���������� ����
    public void PhaseStart()
    {
        //uiȰ��ȭ
        puzzletimer.SetActive(true);//�����ð�
        //thornHPbar.SetActive(true);//����hp

        //�� Ȱ��ȭ
        Wall1.SetActive(true);
        Wall2.SetActive(true);
        Wall3.SetActive(true);
        Wall4.SetActive(true);

        //���� Ȱ��ȭ
        Thorn.SetActive(true);
        arrow.SetActive(true);

        //�÷��̾� �����̵�
        Player.transform.position = PuzzlePhasePos.position;

        //n�� �ڿ� ������
        StartCoroutine(puzzleco);
        
    }
    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(PhaseTimer);
        FinPhase();

        GameObject thorneffect = Instantiate(BigThorn, thornUpPos.position, thornUpPos.rotation);
        Destroy(thorneffect, 0.9f);

        //���� ����� ����Ǹ� �÷��̾� �ǰ�,ü�´��
        GameObject.Find("Player").GetComponent<Player>().OnDamaged(gameObject.transform.position);
        GameObject.Find("Player").GetComponent<Player>().ChangeHealth(-30);//ü�°���
    }

    void FinPhase()
    {
        //ui��Ȱ��ȭ
        puzzletimer.SetActive(false);//�����ð�
        //thornHPbar.SetActive(false); //����

        //�� ��Ȱ��ȭ
        Wall1.SetActive(false);
        Wall2.SetActive(false);
        Wall3.SetActive(false);
        Wall4.SetActive(false);

        //���� ��Ȱ��ȭ
        Thorn.SetActive(false);
        arrow.SetActive(false);

        //���� ������,�ݶ��̴� �ٽ� ���ֱ�
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;

        //���������� ����ȣ��
        gameObject.GetComponent<Bossccontro>().isPattern3 = false;
    }

}
