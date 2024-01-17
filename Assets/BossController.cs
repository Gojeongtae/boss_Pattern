using UnityEngine;

public class BossController : MonoBehaviour
{

    public GameObject bulletPrefab; // 유도탄 프리팹
    public Transform target; // 목표물(플레이어 등)의 Transform

    public float fireInterval = 2f; // 발사 간격
    public float bulletSpeed = 5f; // 유도탄 속도
    private float timer = 0f;

    bool isPatter2 = false; //패턴 2의 여부


    Enemy enemy; //에너미 스크립트 참조
    CannonController cannon; //캐논 컨트롤러 스크립트 참조


    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        cannon = FindObjectOfType<CannonController>();


   
    }

    void Update()
    {
        // 기존 Update 메서드 코드...
        timer += Time.deltaTime;

        // 일정 간격으로 발사
        if (timer >= fireInterval)
        {
            // 유도탄 발사 로직 호출
            FireGuidedBullet();

            // 타이머 초기화
            timer = 0f;
        }
        // 체력이 2/3 이하인 경우
        if (enemy.currentHP <= enemy.maxHP * 3 / 4)
        {
            DoPattern1();
        }
        // 체력이 1/3 이하인 경우
        else if (enemy.currentHP <= enemy.maxHP / 3)
        {
            // 다른 스크립트에서 호출할 함수2 호출
            DoPattern2();
        }
    }

    void FireGuidedBullet() // 패턴 1
    {
        // 목표물이 없다면 발사하지 않음
        if (target == null)
            return;
        
        //퍼즐페이즈가 true일때 공격하지 않음
        if (gameObject.GetComponent<Enemy>().isPuzzlePhase == true)
        {
            return;
        }
        if (isPatter2 == true)
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

    // 체력이 2/3 이하일 때의 동작
    void DoPattern1()
    {
        if(isPatter2 == false)
        {
            // 유도탄 발사 또는 필요한 작업 수행
            StartCoroutine(cannon.FireMissilesWithDelay());
            isPatter2 = true;
        }
    }

    // 체력이 1/3 이하일 때의 동작
    void DoPattern2()
    {
        // 다른 함수 호출 또는 필요한 작업 수행
    }

}

   