using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab; // 유도탄 프리팹
    public Transform target; // 목표물(플레이어 등)의 Transform

    public float fireInterval = 2f; // 발사 간격
    public float bulletSpeed = 5f; // 유도탄 속도
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // 일정 간격으로 발사
        if (timer >= fireInterval)
        {
            // 유도탄 발사 로직 호출
            FireGuidedBullet();

            // 타이머 초기화
            timer = 0f;
        }
    }

    void FireGuidedBullet()
    {
        // 목표물이 없다면 발사하지 않음
        if (target == null)
            return;

        // 보스에서 목표물까지의 상대 위치 벡터 계산
        Vector2 relativePosition = target.position - transform.position;

        // 유도탄 생성
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 발사 방향 설정 (방향 벡터를 정규화하여 사용)
        bullet.GetComponent<GuidedBullet>().SetDirection(relativePosition.normalized);

        // 발사 속도, 파워 등 설정 (필요에 따라 조절)
        bullet.GetComponent<GuidedBullet>().SetSpeed(bulletSpeed);
    }
}
