using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Transform[] firePoints; // 포탄을 발사할 위치들
    public GameObject missilePrefab; // 포탄 프리팹
    public GameObject warningSprite; // 위험을 알리는 스프라이트
    public float missileSpeed = 5f; // 포탄 속도
    public float warningTime = 3f; // 알림 스프라이트가 보여지는 시간

    void Start()
    {
        StartCoroutine(FireMissilesWithDelay());
    }

    public IEnumerator FireMissilesWithDelay()
    {
        // 1, 2, 3 번째에서 포탄 발사
        for (int i = 0; i < 3; i++)
        {
            yield return StartCoroutine(FireMissileFromPoint(firePoints[i]));
            yield return new WaitForSeconds(1f);
        }

        // 4, 5, 6 번째에서 포탄 발사
        yield return new WaitForSeconds(3f);
        for (int i = 3; i < 6; i++)
        {
            yield return StartCoroutine(FireMissileFromPoint(firePoints[i]));
            yield return new WaitForSeconds(2f);
        }

        // 7, 8 번째에서 포탄 발사
        yield return new WaitForSeconds(5f);
        for (int i = 6; i < 8; i++)
        {
            yield return StartCoroutine(FireMissileFromPoint(firePoints[i]));
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator FireMissileFromPoint(Transform firePoint)
    {
        // 알림 스프라이트를 발사 위치에 맞춰서 3초 동안 보이도록 설정
        warningSprite.transform.position = firePoint.position;
        warningSprite.SetActive(true);

        // 일정 시간 대기
        yield return new WaitForSeconds(warningTime);

        // 알림 스프라이트를 비활성화
        warningSprite.SetActive(false);

        // 포탄을 발사할 위치에서의 방향을 기준으로 회전값 계산
        Vector2 direction = firePoint.right; // 발사 위치의 오른쪽 방향을 기준으로 설정
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 포탄을 발사할 위치에서 포탄 생성
        GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.Euler(0, 0, angle));

        // 포탄이 날아가는 동안 대기
        float elapsedTime = 0f;
        while (elapsedTime < warningTime)
        {
            // 포탄을 직접 이동
            missile.transform.Translate(missileSpeed * direction * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 포탄 제거
        Destroy(missile);
    }
}
