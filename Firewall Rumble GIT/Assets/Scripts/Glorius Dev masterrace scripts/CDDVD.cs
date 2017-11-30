using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDDVD : MonoBehaviour
{
    public TMPro.TextMeshPro CDDVDEntered;
    public TMPro.TextMeshPro artist;
    public string[] normalCdArtists;
    public string[] normalCds;
    public string[] normalDvds;
    public string[] dodgyCds;
    public string[] cdArtistDodgy;
    public string[] dodgyDvds;

    public GameObject[] viruses;
    public Transform origin;
    public Transform desination;


    private void Start()
    {
        EventManager.instance.events.Add(InsertCDNormal);
        EventManager.instance.events.Add(InsertCDDodgy);
        EventManager.instance.events.Add(InsertDVDNormal);
        EventManager.instance.events.Add(InsertDVDDodgy);
    }

    public void InsertCDNormal()
    {
        int rand = Random.Range(0, normalCds.Length-1);
        DisplayMessage(normalCds[rand], normalCdArtists[rand]);
    }

    public void InsertDVDNormal()
    {
        int rand = Random.Range(0, normalCds.Length-1);
        DisplayMessage(normalDvds[rand]);
    }

    public void InsertCDDodgy()
    {
        int rand = Random.Range(0, dodgyCds.Length-1);
        DisplayMessage(dodgyCds[rand], cdArtistDodgy[rand]);
        //FlyingObjectHandler.instance.Send(viruses[UnityEngine.Random.Range(0, viruses.Length)], origin, desination, true);
    }

    public void InsertDVDDodgy()
    {
        int rand = Random.Range(0, dodgyDvds.Length-1);
        DisplayMessage(dodgyDvds[rand]);
        //FlyingObjectHandler.instance.Send(viruses[UnityEngine.Random.Range(0, viruses.Length)], origin, desination, true);
    }

    void DisplayMessage(string name, string byArtist = "")
    {
        CDDVDEntered.text = name;
        artist.text = byArtist;
    }
}
