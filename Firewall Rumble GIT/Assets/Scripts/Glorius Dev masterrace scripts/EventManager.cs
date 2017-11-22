using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public GameObject killPart;
    public List<Action> events = new List<Action>();
    // Use this for initialization
    void Awake ()
    {
		instance=this;
	}

    public void StartLoop()
    {
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        while(true)
        {
            if(MotherBoard.instance.gameActive==true)
            {
                DoRandomEvent();
                yield return new WaitForSeconds(UnityEngine.Random.Range(1.5f,2f));
            }
            else
            {
                break;
            }
        }
    }
    void DoRandomEvent()
    {
        events[UnityEngine.Random.Range(0, events.Count)].Invoke();
    }
}
