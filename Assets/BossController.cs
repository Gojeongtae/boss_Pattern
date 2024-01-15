using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public Transform player; // �÷��̾� Ʈ������
    public GameObject missilePrefab; // ����ź ������
    public float missileSpeed = 5f; // ����ź �ӵ�
    public float missileRotationSpeed = 200f; // ����ź ȸ�� �ӵ�

    Animator anim;

    void Start()
    {
        // 4�ʸ��� FireMissile �Լ��� ȣ��
        InvokeRepeating("FireMissile", 0f, 4f);
        anim = gameObject.GetComponent<Animator>();
    }

    void FireMissile()
    {
        // �÷��̾� �������� ����ź�� �߻�
        Vector2 playerDirection = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg);
        GameObject missile = Instantiate(missilePrefab, transform.position, rotation);
        anim.SetBool("isAttacking", true);
        Invoke("StopAttackAnim", 2f);

        // ����ź�� �ӵ��� ȸ�� �ӵ��� ����
        Transform missileTransform = missile.transform;
        float missileTravelTime = Vector2.Distance(missileTransform.position, player.position) / missileSpeed;

        StartCoroutine(MoveMissile(missileTransform, player.position, missileTravelTime));
    }
    //���ݾִϸ��̼� ����
    void StopAttackAnim()
    {
        anim.SetBool("isAttacking", false);
    }

    IEnumerator MoveMissile(Transform missileTransform, Vector2 targetPosition, float travelTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < travelTime)
        {
            // ����ź�� ���� �̵�
            missileTransform.position = Vector2.Lerp(missileTransform.position, targetPosition, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ����ź ����
        Destroy(missileTransform.gameObject);
    }
}
