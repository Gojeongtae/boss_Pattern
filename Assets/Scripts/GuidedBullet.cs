using UnityEngine;

public class GuidedBullet : MonoBehaviour
{
    private Vector2 direction;
    private float speed;


    void Start()
    {
        // 일정 시간 후에 유도탄 파괴
        Destroy(gameObject, 3f);
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }

    void Update()
    {
        // 목표 방향으로 이동
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 충돌 시
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.ChangeHealth(-5);
                Destroy(gameObject);
            }
        }
    }

}