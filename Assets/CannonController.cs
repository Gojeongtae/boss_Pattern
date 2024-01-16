using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Transform[] firePoints; // ��ź�� �߻��� ��ġ��
    public GameObject missilePrefab; // ��ź ������
    public GameObject warningSprite; // ������ �˸��� ��������Ʈ
    public float missileSpeed = 5f; // ��ź �ӵ�
    public float warningTime = 3f; // �˸� ��������Ʈ�� �������� �ð�

    void Start()
    {
        StartCoroutine(FireMissilesWithDelay());
    }

    public IEnumerator FireMissilesWithDelay()
    {
        // 1, 2, 3 ��°���� ��ź �߻�
        for (int i = 0; i < 3; i++)
        {
            yield return StartCoroutine(FireMissileFromPoint(firePoints[i]));
            yield return new WaitForSeconds(1f);
        }

        // 4, 5, 6 ��°���� ��ź �߻�
        yield return new WaitForSeconds(3f);
        for (int i = 3; i < 6; i++)
        {
            yield return StartCoroutine(FireMissileFromPoint(firePoints[i]));
            yield return new WaitForSeconds(2f);
        }

        // 7, 8 ��°���� ��ź �߻�
        yield return new WaitForSeconds(5f);
        for (int i = 6; i < 8; i++)
        {
            yield return StartCoroutine(FireMissileFromPoint(firePoints[i]));
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator FireMissileFromPoint(Transform firePoint)
    {
        // �˸� ��������Ʈ�� �߻� ��ġ�� ���缭 3�� ���� ���̵��� ����
        warningSprite.transform.position = firePoint.position;
        warningSprite.SetActive(true);

        // ���� �ð� ���
        yield return new WaitForSeconds(warningTime);

        // �˸� ��������Ʈ�� ��Ȱ��ȭ
        warningSprite.SetActive(false);

        // ��ź�� �߻��� ��ġ������ ������ �������� ȸ���� ���
        Vector2 direction = firePoint.right; // �߻� ��ġ�� ������ ������ �������� ����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��ź�� �߻��� ��ġ���� ��ź ����
        GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.Euler(0, 0, angle));

        // ��ź�� ���ư��� ���� ���
        float elapsedTime = 0f;
        while (elapsedTime < warningTime)
        {
            // ��ź�� ���� �̵�
            missile.transform.Translate(missileSpeed * direction * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ��ź ����
        Destroy(missile);
    }
}
