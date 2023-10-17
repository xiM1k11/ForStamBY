using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    // public GameObject playerPrefab1;
    // public GameObject playerPrefab2;
    // public GameObject playerPrefab3;
    // public float minX, minY, maxX, maxY;

    // public override void OnJoinedRoom()
    // {
    //     base.OnJoinedRoom();

    //     Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

    //     // Определяем, какой префаб игрока спавнить в зависимости от количества игроков в комнате
    //     if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
    //     {
    //         PhotonNetwork.Instantiate(playerPrefab1.name, randomPosition, Quaternion.identity);
    //     }
    //     else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
    //     {
    //         PhotonNetwork.Instantiate(playerPrefab2.name, randomPosition, Quaternion.identity);
    //     }
    //     else if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
    //     {
    //         PhotonNetwork.Instantiate(playerPrefab3.name, randomPosition, Quaternion.identity);
    //     }
    // }
     public GameObject playerPrefab1; // Префаб первого персонажа
    public GameObject playerPrefab2; // Префаб второго персонажа
    public GameObject playerPrefab3; // Префаб третьего персонажа
    public float minX, minY, maxX, maxY;

    void Start()
    {
        
            Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            GameObject playerToInstantiate;

            // Выбираем префаб в зависимости от условий
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                playerToInstantiate = playerPrefab1;
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                playerToInstantiate = playerPrefab2;
            }
            else
            {
                playerToInstantiate = playerPrefab3;
            }

            // Создаем игрока из выбранного префаба
            PhotonNetwork.Instantiate(playerToInstantiate.name, randomPosition, Quaternion.identity);
        
    }

}
   
