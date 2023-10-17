using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class ConnectToServer : MonoBehaviourPunCallbacks
{
  
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
      Debug.Log("Подключен");
      
    
      SceneManager.LoadScene("Lobby");

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
      Debug.Log("Отключено");
    }
}