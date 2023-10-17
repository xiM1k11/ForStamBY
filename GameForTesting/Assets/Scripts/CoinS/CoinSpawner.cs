using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Префаб монетки
    public float spawnInterval;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

  

    private void Start()
    {
            InvokeRepeating("SpawnCoin", 0.0f, spawnInterval);
        
    }

    private void SpawnCoin()
    {
        // Генерируйте случайные координаты в заданных пределах
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        // Создайте экземпляр монетки в случайной позиции
        Instantiate(coinPrefab, randomPosition, Quaternion.identity);
    }
}