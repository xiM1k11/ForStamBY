using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    public string characterID; // Уникальный идентификатор персонажа
    private int moneyCollected = 0;
    private MoneyUI moneyUI; // Ссылка на скрипт MoneyUI

    private void Start()
    {
        moneyUI = FindObjectOfType<MoneyUI>();
        if (moneyUI == null)
        {
            Debug.LogError("MoneyUI script not found. Make sure it's in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Money"))
        {
            CollectMoneyObject(other.gameObject);
        }
    }

    private void CollectMoneyObject(GameObject moneyObject)
    {
        if (moneyObject != null)
        {
            moneyCollected++;
            if (moneyUI != null)
            {
                moneyUI.CollectMoney(characterID, moneyCollected);
            }
            else
            {
                Debug.LogError("MoneyUI script is null. Make sure it's correctly assigned in the Inspector.");
            }
            Destroy(moneyObject);
        }
        else
        {
            Debug.LogError("moneyObject is null");
        }
    }
}