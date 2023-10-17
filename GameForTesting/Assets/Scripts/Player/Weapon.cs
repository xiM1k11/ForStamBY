using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Weapon : MonoBehaviourPun
{
    public Transform shootPos;
    public GameObject bulletPrefab;
    public Button shootButton;

    private void Start()
    {
        // Скрываем кнопку выстрела при старте
        shootButton.gameObject.SetActive(false);

        // Проверяем количество игроков в комнате
        if (PhotonNetwork.InRoom)
        {
            CheckPlayerCount();
        }
    }

    private void CheckPlayerCount()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            // Если есть два игрока в комнате, показываем кнопку выстрела
            shootButton.gameObject.SetActive(true);
        }
    }

    private void OnPlayerEnteredRoom(Player newPlayer)
    {
        // Когда новый игрок входит в комнату, перепроверяем количество игроков
        CheckPlayerCount();
    }

    public void Shoot()
    {
        if (bulletPrefab != null)
        {
            // Создаем пулю и устанавливаем направление
            GameObject bullet = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation);

            Vector3 direction = transform.right;

            if (transform.localScale.x < 0)
            {
                direction = -transform.right;
            }

            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }
}