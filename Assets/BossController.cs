using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public Transform player; // 플레이어 트랜스폼
    public GameObject missilePrefab; // 유도탄 프리팹
    public float missileSpeed = 5f; // 유도탄 속도
    public float missileRotationSpeed = 200f; // 유도탄 회전 속도

    void Start()
    {
        // 3초마다 FireMissile 함수를 호출
        InvokeRepeating("FireMissile", 0f, 3f);
    }

    void FireMissile()
    {
        // 플레이어 방향으로 유도탄을 발사
        Vector2 playerDirection = (player.position - transform.position).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg);
        GameObject missile = Instantiate(missilePrefab, transform.position, rotation);

        // 유도탄에 속도와 회전 속도를 설정
        Transform missileTransform = missile.transform;
        float missileTravelTime = Vector2.Distance(missileTransform.position, player.position) / missileSpeed;

        StartCoroutine(MoveMissile(missileTransform, player.position, missileTravelTime));
    }

    IEnumerator MoveMissile(Transform missileTransform, Vector2 targetPosition, float travelTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < travelTime)
        {
            // 유도탄을 직접 이동
            missileTransform.position = Vector2.Lerp(missileTransform.position, targetPosition, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 유도탄 제거
        Destroy(missileTransform.gameObject);
    }
}
