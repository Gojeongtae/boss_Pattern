using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossccontro : MonoBehaviour
{
    //����ź ����
    public GameObject bulletPrefab; // ����ź ������
    public Transform target; // ��ǥ��(�÷��̾� ��)�� Transform
    public float fireInterval = 2f; // ����ź �߻� ����
    public float bulletSpeed = 5f; // ����ź �ӵ�
    private float timer = 0f; //����ź Ÿ�̸�

    bool isPatter2 = false; //���� 2�� ����
    public bool isPattern3 = false; //����3
    bool nomorepuzzle = true; //���� ����
    
    //ȣ�ֹ̻��� ����
    public GameObject homingmissile; //ȣ�ֹ̻��� ������
    public float hominginterval = 5f; // ȣ�ֹ̻��� �߻簣��
    public float hommingtimer = 0f; //ȣ�� Ÿ�̸�

    Enemy enemy; //���ʹ� ��ũ��Ʈ ����
    CannonController cannon; //ĳ�� ��Ʈ�ѷ� ��ũ��Ʈ ����
    PuzzlePhase puzzle;//���������� ��ũ��Ʈ ����


    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        cannon = gameObject.GetComponent<CannonController>();
        puzzle = gameObject.GetComponent<PuzzlePhase>();

    }

    void Update()
    {
        // ���� Update �޼��� �ڵ�...
        timer += Time.deltaTime;

        // ���� �������� �߻�
        if (timer >= fireInterval)
        {
            // ����ź �߻� ���� ȣ��
            FireGuidedBullet();

            // Ÿ�̸� �ʱ�ȭ
            timer = 0f;
        }

        hommingtimer += Time.deltaTime;
        //ȣ�ֹ̻��Ϲ߻�
        if (hommingtimer >= hominginterval)
        {
            // ȣ�ֹ̻��� �߻� ���� ȣ��
            FireHoming();

            // Ÿ�̸� �ʱ�ȭ
            hommingtimer = 0f;
        }

        // ü���� 2/3 (60%)������ ���
        /*
        if ((float)enemy.currentHP / (float)enemy.maxHP <= 0.6 )
        {
            // �ٸ� ��ũ��Ʈ���� ȣ���� �Լ�2 ȣ��
            DoPattern1();
        }
        */
        // ü���� 1/3 (30%)������ ���
        if ((float)enemy.currentHP / (float)enemy.maxHP <= 0.3)
        {
            DoPattern2();
        }
    }

    void FireGuidedBullet() // ���� 1
    {
        // ��ǥ���� ���ٸ� �߻����� ����
        if (target == null)
            return;
        if (isPatter2 == true)
            return;
        if (isPattern3 == true)
            return;

        // �������� ��ǥ�������� ��� ��ġ ���� ���
        Vector2 relativePosition = target.position - transform.position;

        // ����ź ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // �߻� ���� ���� (���� ���͸� ����ȭ�Ͽ� ���)
        bullet.GetComponent<GuidedBullet>().SetDirection(relativePosition.normalized);

        // �߻� �ӵ�, �Ŀ� �� ���� (�ʿ信 ���� ����)
        bullet.GetComponent<GuidedBullet>().SetSpeed(bulletSpeed);
    }
    
    //ȣ�ֹ̻���(�ȵ�)
    void FireHoming()
    {        
        // ��ǥ���� ���ٸ� �߻����� ����
        if (target == null)
            return;
        if (isPatter2 == true)
            return;
        if (isPattern3 == true)
            return;

        //ȣ�ֹ̻��� ����
        GameObject newPrefabInstance = Instantiate(homingmissile, transform.position, Quaternion.identity);


    }


    // ü���� 2/3 ������ ���� ����
    void DoPattern1()
    {
        if (isPatter2 == false)
        {
            // ����ź �߻� �Ǵ� �ʿ��� �۾� ����
            StartCoroutine(cannon.FireMissilesWithDelay());
            isPatter2 = true;
        }
    }

    // ü���� 1/3 ������ ���� ����
    void DoPattern2()
    {
        if (isPattern3 == false && nomorepuzzle == true) 
        {        
            //������ ����ȣ��
            gameObject.GetComponent<PuzzlePhase>().PhaseStart();
            //���� ������,�ݶ��̴� ���ֱ�
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            isPattern3 = true;
            nomorepuzzle = false;
        }
    }

}
