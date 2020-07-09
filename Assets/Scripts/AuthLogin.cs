using HmsPlugin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AuthLogin : MonoBehaviour
{
    public Button btnLogin;
    public AccountManager myAccountManager;



    // Start is called before the first frame update
    void Start()
    {
        myAccountManager = GameObject.Find("AccountManager").GetComponent<AccountManager>();
        
        Button btn = btnLogin.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    public void TaskOnClick()
    {

        if (myAccountManager)
        {
            myAccountManager.SignIn();
        }
        else
        {
            myAccountManager = GameObject.Find("AccountManager").GetComponent<AccountManager>();
        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
