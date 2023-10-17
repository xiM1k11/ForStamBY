// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class MoneyManager : MonoBehaviour
// {
    
//    public static int money = 0;
//    public Text moneyText;

//      void Start()
//     {
//         moneyText = GetComponent<Text>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         moneyText.text = "В вашей копилке " + money;
//     }

   
// }
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using Photon.Pun;
// using Photon.Realtime;
// using ExitGames.Client.Photon;
// using Hashtable = ExitGames.Client.Photon.Hashtable; // Используем using static для Hashtable

// public class MoneyManager : MonoBehaviourPun
// {
//     private Text moneyText;

//     private void Start()
//     {
//         moneyText = GetComponent<Text>();
//         UpdateMoneyText();
//     }

//     private void UpdateMoneyText()
//     {
//         moneyText.text = "В вашей копилке: " + PhotonNetwork.LocalPlayer.CustomProperties["Money"];
//     }

//     public void UpdateMoney(int newAmount)
//     {
//         Hashtable moneyProp = new Hashtable();
//         moneyProp["Money"] = newAmount;
//         PhotonNetwork.LocalPlayer.SetCustomProperties(moneyProp);
//     }
// }
