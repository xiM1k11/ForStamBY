using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviourPun
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int playerID; // Уникальный идентификатор игрока

    // Передаем уникальный идентификатор игрока
    public void Initialize(int playerID)
    {
        this.playerID = playerID;
        currentHealth = maxHealth;
    }

    public void TakeHit(int damage)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            PhotonNetwork.Disconnect();
            
            
        }

        // Отправляем информацию о полученном уроне всем игрокам
        photonView.RPC("UpdateHealth", RpcTarget.All, currentHealth);
    }

    public void SetHealth(int bonusHealth)
    {
        if (!photonView.IsMine)
        {
            return;
        }

        currentHealth += bonusHealth;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Отправляем информацию о изменении здоровья всем игрокам
        photonView.RPC("UpdateHealth", RpcTarget.All, currentHealth);
    }

    [PunRPC]
    private void UpdateHealth(int newHealth)
    {
        currentHealth = newHealth;
    }
}