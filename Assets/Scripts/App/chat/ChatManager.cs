using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public Transform startChat;

    public User user;
    public InputField inputField;

    public GameObject[] Messages;


    public bool firstMessage;
    public bool sendMessage;
    private void Start()
    {
        sendMessage = false;
        firstMessage = false;
    }
    private void Update()
    {
        if (user.searchChat)
        {
            if (!firstMessage)
            {
                MakeBotMessage("Стартапер:\n Привет, не хочешь перед началом работы сыграть в игру?)");
                firstMessage = true;
            }
            if (sendMessage)
            {
                MakeInvite();
                sendMessage = false;
            }
        }
    }
    public void MakeBotMessage(string message)
    {
        CreateMessage(message, Messages[0]);
    }

    public void MakeMessage()
    {
        if(inputField.text != null)
        {
            CreateMessage("Ты: \n" + Convert.ToString(inputField.text), Messages[1]);
            inputField.text = "";
            sendMessage = true;
        }
    }
    public void MakeInvite()
    {
        CreateMessage("Приглашение(Стартапер)", Messages[2]);
    }
     
    void CreateMessage(string message, GameObject messagea)
    {
        GameObject mes = Instantiate(messagea, startChat);
        mes.GetComponent<Text>().text = message;
    }

}
