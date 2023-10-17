using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneyCounter : MonoBehaviour
{
    public string characterID; 
    private void Start()
    {
        CollectMoney collectMoney = GetComponent<CollectMoney>();
        if (collectMoney != null)
        {
            collectMoney.characterID = characterID;
        }
    }
}