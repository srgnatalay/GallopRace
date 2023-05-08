using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAccount : MonoBehaviour
{
    public Text myAccount;
    private string account;

    void Start()
    {
        if (PlayerPrefs.GetString("Account") != "")
        {
            account = PlayerPrefs.GetString("Account");
        }

        myAccount.text = account;
    }
}