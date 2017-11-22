using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Email : MonoBehaviour
{
    int inboxAmount;
    int spamBox;
    public string[] dodgyMailAdresses;
    public string[] dodgySubjects;
    public string[] normalMailAdresses;
    public string[] normalSubjects;
    public TextMeshPro emailInfo;
    public TextMeshPro inboxText;
    public TextMeshPro spamBoxText;
    string mailFrom = "Mail from: \n";
    public GameObject normalEmail;
    public GameObject[] viruses;
    public Transform origin;
    public Transform desination;

    private void Start()
    {
        EventManager.instance.events.Add(YouGotMailNormal);
        EventManager.instance.events.Add(YouGotMailDodgy);

    }

    public void YouGotMailNormal()
    {
        int rand = Random.Range(0, normalMailAdresses.Length-1);
        DisplayMail(normalMailAdresses[rand],normalSubjects[rand]);
        SetInbox();
    }

    public void YouGotMailDodgy()
    {
        int rand = Random.Range(0, dodgyMailAdresses.Length-1);
        DisplayMail(dodgyMailAdresses[rand], dodgySubjects[rand]);
        FlyingObjectHandler.instance.Send(viruses[UnityEngine.Random.Range(0, viruses.Length)], origin, desination, true);
        SetInbox(true);
    }

    void DisplayMail(string adress, string subject)
    {
        emailInfo.text= (mailFrom + adress + "\n" + "Subject: " + subject);
    }

    public void SetInbox(bool dodgy = false)
    {
        if(dodgy)
        {
            spamBox++;
            spamBoxText.text = ("Spambox: " + spamBox);
        }
        else
        {
            inboxAmount++;
            inboxText.text = ("Inbox: " + inboxAmount);
        }
    }
}
