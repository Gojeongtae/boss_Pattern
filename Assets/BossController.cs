using UnityEngine;

public class BossController : MonoBehaviour
{

    public GameObject bulletPrefab; // ����ź ������
    public Transform target; // ��ǥ��(�÷��̾� ��)�� Transform

    public float fireInterval = 2f; // �߻� ����
    public float bulletSpeed = 5f; // ����ź �ӵ�
    private float timer = 0f;

    bool isPatter2 = false; //���� 2�� ����


    Enemy enemy; //���ʹ� ��ũ��Ʈ ����
    CannonController cannon; //ĳ�� ��Ʈ�ѷ� ��ũ��Ʈ ����


    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        cannon = FindObjectOfType<CannonController>();


   
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
        // ü���� 2/3 ������ ���
        if (enemy.currentHP <= enemy.maxHP * 3 / 4)
        {
            DoPattern1();
        }
        // ü���� 1/3 ������ ���
        else if (enemy.currentHP <= enemy.maxHP / 3)
        {
            // �ٸ� ��ũ��Ʈ���� ȣ���� �Լ�2 ȣ��
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

        // �������� ��ǥ�������� ��� ��ġ ���� ���
        Vector2 relativePosition = target.position - transform.position;

        // ����ź ����
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // �߻� ���� ���� (���� ���͸� ����ȭ�Ͽ� ���)
        bullet.GetComponent<GuidedBullet>().SetDirection(relativePosition.normalized);

        // �߻� �ӵ�, �Ŀ� �� ���� (�ʿ信 ���� ����)
        bullet.GetComponent<GuidedBullet>().SetSpeed(bulletSpeed);
    }

    // ü���� 2/3 ������ ���� ����
    void DoPattern1()
    {
        if(isPatter2 == false)
        {
            // ����ź �߻� �Ǵ� �ʿ��� �۾� ����
            StartCoroutine(cannon.FireMissilesWithDelay());
            isPatter2 = true;
        }
    }

    // ü���� 1/3 ������ ���� ����
    void DoPattern2()
    {
        // �ٸ� �Լ� ȣ�� �Ǵ� �ʿ��� �۾� ����
    }

}

   