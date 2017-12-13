using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public GameObject killPart;
    public List<Action> events = new List<Action>();
    public Action leftGood,leftBad,middleGood,middleBad,rightGood,rightBad;
    // Use this for initialization
    void Awake ()
    {
		instance=this;
	}


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DoRandomEvent();
        }
    }

    public void StartLoop()
    {
        StartCoroutine(GameLoop());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    IEnumerator GameLoop()
    {
        System.Random rnd = new System.Random();
        yield return new WaitForSeconds(9f);
        StartCoroutine(DoWave(false,true,false));
        yield return new WaitForSeconds(8f);
        StartCoroutine(DoWave(true, false, false));
        yield return new WaitForSeconds(7.5f);
        StartCoroutine(DoWave(false, false, true));
        yield return new WaitForSeconds(7.25f);
        StartCoroutine(DoWave(true, false, true));
        yield return new WaitForSeconds(7f);
        while(true)
        {
            if(MotherBoard.instance.gameActive==true)
            {
                StartCoroutine(DoWave(IsEven(rnd.Next(100)), IsEven(rnd.Next(100)), IsEven(rnd.Next(100))));
                yield return new WaitForSeconds(UnityEngine.Random.Range(6.5f,7f));
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

    IEnumerator DoWave(bool left, bool middle, bool right)
    {
        List<Action> events = new List<Action>();
        if(left)
        {
            events.Add(leftBad);
        }
        else
        {
            events.Add(leftGood);
        }
        if (middle)
        {
            events.Add(middleBad);
        }
        else
        {
            events.Add(middleGood);
        }
        if (right)
        {
            events.Add(rightBad);
        }
        else
        {
            events.Add(rightGood);
        }
        events.Shuffle();
        foreach(Action action in events)
        {
            action.Invoke();
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.5f,2.25f));  
        }
    }

    bool IsEven(int value)
    {
        return value % 2 !=0;
    }

}
