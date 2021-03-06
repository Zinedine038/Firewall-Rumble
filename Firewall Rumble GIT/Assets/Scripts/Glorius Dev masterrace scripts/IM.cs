﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IM : MonoBehaviour {
    public TMPro.TextMeshPro newestMessage;
    public TMPro.TextMeshPro latestContact;
    public TMPro.TextMeshPro inbox;
    public string status;
    public string[] contactsNormal;
    public string[] contactsDodgy;
    public string[] messages;
    public string[] dodgyMessages;
    public int unreadMessages;

    public GameObject[] viruses;
    public GameObject chat;
    public Transform origin;
    public Transform desination;

    private void Start()
    {
        EventManager.instance.events.Add(GetMessage);
        EventManager.instance.events.Add(GetMessageDodgy);
    }

    public void GetMessage()
    {
        int rand = Random.Range(0, messages.Length-1);
        int rand2 = Random.Range(0, contactsNormal.Length - 1);
        DisplayMessage(messages[rand], contactsNormal[rand2]);
        FlyingObjectHandler.instance.Send(chat, origin, desination, true);
        unreadMessages++;
    }

    public void GetMessageDodgy()
    {
        int rand = Random.Range(0, dodgyMessages.Length-1);
        int rand2 = Random.Range(0, contactsDodgy.Length - 1);
        DisplayMessage(dodgyMessages[rand], contactsDodgy[rand2]);
        FlyingObjectHandler.instance.Send(viruses[UnityEngine.Random.Range(0, viruses.Length)], origin, desination, true);
        unreadMessages++;
    }

    void DisplayMessage(string message, string contact)
    {
        inbox.text = unreadMessages + " New Messages:";
        newestMessage.text = message;
        latestContact.text=contact + " Says:";
    }

}
