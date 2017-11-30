using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiFi : MonoBehaviour
{
    public TMPro.TextMeshPro wifiStatus;
    public TMPro.TextMeshPro connectedDevices;
    public string[] badStatuses;
    public string[] recoveringStatus;
    public string[] pcNames;
    public GameObject[] viruses;
    public Transform origin;
    public Transform desination;
    // Use this for initialization
    void Start ()
    {
		EventManager.instance.events.Add(Damage);
        EventManager.instance.events.Add(Recover);
    }
	
	public void Damage()
    {
        wifiStatus.text = "WiFi Status: " + badStatuses[UnityEngine.Random.Range(0,badStatuses.Length-1)];
        connectedDevices.text = "Connected Device: " + pcNames[UnityEngine.Random.Range(0,pcNames.Length - 1)];
        //FlyingObjectHandler.instance.Send(viruses[UnityEngine.Random.Range(0, viruses.Length)], origin, desination, true);
    }

    public void Recover()
    {
        wifiStatus.text = "WiFi Status: " + recoveringStatus[UnityEngine.Random.Range(0, recoveringStatus.Length - 1)];
        connectedDevices.text = "Connected Device: None";
        //FlyingObjectHandler.instance.Send(viruses[UnityEngine.Random.Range(0, viruses.Length-1)], origin, desination, true);
    }
}
