using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    // Сначала подключитесь к Master-серверу
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Здесь проверяем статус подключения к Master-серверу
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server");
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected) // Проверяем, подключены ли к Master-серверу
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 3;
            PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        }
        else
        {
            Debug.LogError("Not connected to Master Server yet. Wait for the connection.");
        }
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected) // Проверяем, подключены ли к Master-серверу
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }
        else
        {
            Debug.LogError("Not connected to Master Server yet. Wait for the connection.");
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}