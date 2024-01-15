using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab; // ����ź ������
    public Transform target; // ��ǥ��(�÷��̾� ��)�� Transform

    public float fireInterval = 2f; // �߻� ����
    public float bulletSpeed = 5f; // ����ź �ӵ�
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // ���� �������� �߻�
        if (timer >= fireInterval)
        {
            // ����ź �߻� ���� ȣ��
            FireGuidedBullet();

            // Ÿ�̸� �ʱ�ȭ
            timer = 0f;
        }
    }

    void FireGuidedBullet()
    {
        // ��ǥ���� ���ٸ� �߻����� ����
        if (target == null)
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
}
