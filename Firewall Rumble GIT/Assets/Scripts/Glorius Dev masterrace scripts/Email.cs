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
    string mailFrom = "Mail from: \n";

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            YouGotMailNormal();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            YouGotMailDodgy();
        }
    }

    public void YouGotMailNormal()
    {
        int rand =Random.Range(0, normalMailAdresses.Length);
        DisplayMail(normalMailAdresses[rand],normalSubjects[rand]);
    }

    public void YouGotMailDodgy()
    {
        int rand = Random.Range(0, dodgyMailAdresses.Length);
        DisplayMail(dodgyMailAdresses[rand], dodgySubjects[rand]);
    }

    void DisplayMail(string adress, string subject)
    {
        emailInfo.text= (mailFrom + adress + "\n" + "Subject: " + subject);
    }

    public void SetInbox()
    {

    }
}
