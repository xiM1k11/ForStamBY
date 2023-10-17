using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ReturnToLobby : MonoBehaviour
{
    public void ReturnToLobbyScene()
    {
        PhotonNetwork.Disconnect(); // Делаем дисконнект от Photon сервера
        SceneManager.LoadScene("Lobby"); // Загружаем сцену "Lobby"
    }
}