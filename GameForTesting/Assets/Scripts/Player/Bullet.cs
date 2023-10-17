using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Start()
    {
        // Настроим направление движения пули на основе переданного направления
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // Обработчик столкновения
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // При столкновении с игроком, уничтожаем пулю
            Destroy(gameObject);
        }
    }
}