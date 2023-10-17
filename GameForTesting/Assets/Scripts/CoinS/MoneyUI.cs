// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections.Generic;

// public class MoneyUI : MonoBehaviour
// {
//     public Text moneyText;
//     private Dictionary<string, int> moneyDictionary = new Dictionary<string, int>();

    
//     public void CollectMoney(string characterID, int moneyCollected)
//     {
//         if (!moneyDictionary.ContainsKey(characterID))
//         {
//             moneyDictionary[characterID] = 0;
//         }
//         moneyDictionary[characterID] = moneyCollected;
//         UpdateMoneyText();
//     }

//    private void UpdateMoneyText()
// {
//     string displayText = "Money у игрока номер :";
//     foreach (var pair in moneyDictionary)
//     {
//         displayText += pair.Key + ": " + pair.Value + "\n";
//     }
//     moneyText.text = displayText;
// }
// }
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;

public class MoneyUI : MonoBehaviourPunCallbacks
{
    public Text moneyText;
    public Text winText;
    private Dictionary<string, int> moneyDictionary = new Dictionary<string, int>();
    public GameObject winTextObject;
    private int alivePlayers;

    public void CollectMoney(string characterID, int moneyCollected)
    {
        if (!moneyDictionary.ContainsKey(characterID))
        {
            moneyDictionary[characterID] = 0;
        }
        moneyDictionary[characterID] = moneyCollected;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        string displayText = "Money у игрока номер :";
        foreach (var pair in moneyDictionary)
        {
            displayText += pair.Key + ": " + pair.Value + "\n";
        }
        moneyText.text = displayText;
    }

    private void ShowWinText()
    {
        if (alivePlayers == 1)
        {
            var winner = moneyDictionary.Keys.First();
            var money = moneyDictionary[winner];

            winTextObject.SetActive(true);
            winText.text = $"Игрок номер {winner} заработал {money} Money и выиграл, поздравляем!";
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        // Когда новый игрок присоединяется, увеличиваем счетчик живых игроков
        alivePlayers++;
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        // Когда игрок покидает комнату, уменьшаем счетчик живых игроков
        alivePlayers--;

        // Проверка, остался ли только один игрок
        if (alivePlayers == 1)
        {
            ShowWinText();
        }
    }
}