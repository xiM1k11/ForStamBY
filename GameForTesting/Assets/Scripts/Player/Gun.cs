using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform gunTransform;          // Трансформ объекта, откуда выпускаются пули
    public GameObject bulletPrefab;         // Префаб пули
    public float bulletSpeed = 10.0f;       // Скорость полета пули
    public LayerMask enemyLayer;            // Слой, на котором находятся враги
    public Button shootButton;              // Ссылка на кнопку выстрела

    public int maxAmmo = 10;                // Максимальное количество патронов
    private int currentAmmo;                // Текущее количество патронов
    public Text ammoText;                   // Ссылка на текстовое поле, отображающее количество патронов

    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
        shootButton.onClick.AddListener(Shoot);
    }

    private void Update()
    {
        // Проверяем, была ли нажата кнопка выстрела
        if (currentAmmo > 0 && Input.GetButtonDown("Fire1")) // Здесь используется пример кнопки "Fire1" (левая кнопка мыши), вы можете изменить на свой вариант
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (currentAmmo > 0)
        {
            // Находим ближайшего врага
            Transform nearestEnemy = FindNearestEnemy();

            if (nearestEnemy != null)
            {
                // Определяем направление к ближайшему врагу
                Vector3 direction = (nearestEnemy.position - gunTransform.position).normalized;

                // Создаем пулю
                GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, Quaternion.identity);

                // Направляем пулю в сторону врага
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed;

                // Тратим патрон
                currentAmmo--;

                // Обновляем отображение патронов на канвасе
                UpdateAmmoUI();
            }
        }

        // Если патроны закончились, отключаем выстрел
        if (currentAmmo <= 0)
        {
            shootButton.interactable = false; // Отключаем кнопку выстрела
        }
    }

    private void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo + " / " + maxAmmo;
        }
    }

    private Transform FindNearestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gunTransform.position, 10.0f, enemyLayer);

        Transform nearestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D collider in colliders)
        {
            float distance = Vector3.Distance(gunTransform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = collider.transform;
            }
        }

        return nearestEnemy;
    }
}