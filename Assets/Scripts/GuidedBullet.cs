using UnityEngine;

public class GuidedBullet : MonoBehaviour
{
    private Vector2 direction;
    private float speed;


    void Start()
    {
        // ���� �ð� �Ŀ� ����ź �ı�
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
        // ��ǥ �������� �̵�
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾�� �浹 ��
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