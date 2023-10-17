using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthBar : MonoBehaviourPun
{
    public Slider slider;
    public Health playerHealth;

    private void Start()
    {
        // Проверяем, если объект принадлежит текущему игроку
        if (photonView.IsMine)
        {
            slider.gameObject.SetActive(true);
            // Устанавливаем максимальное здоровье
            SetMaxHealth(playerHealth.maxHealth);
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Проверяем, если объект принадлежит текущему игроку
        if (photonView.IsMine)
        {
            // Обновляем значение хиллбара на основе текущего здоровья игрока
            slider.value = playerHealth.currentHealth;
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}