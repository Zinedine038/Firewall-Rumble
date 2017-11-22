using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class InitializeGame : MonoBehaviour {
    public CMDTextEntry intro;
    public TextAnimator tm;
    public TextMeshPro text;
    bool runTimer = true;
    public Timer timerTuto;
    public Timer timerGame;
    public string timerTutoMessage, timerTutoCompleted, timerGameMessage, timerGameCompleted;
    public void StartGame()
    {
        runTimer = true;
        StartCoroutine(StartTimer(timerGame.minutes, timerGame.seconds, timerGame.milleseconds, timerGameMessage, timerGameCompleted,MotherBoard.instance.WonGame));
        tm.queue.Add(intro);
    }

    IEnumerator StartTimer(float minute, float second, float millesecond, string timerMessage, string timerMessageCompleted,Action action)
    {
        float minutes = minute;
        float seconds = second;
        float miliseconds = millesecond;
        while (runTimer)
        {
            if (miliseconds <= 0)
            {
                if (seconds <= 0)
                {
                    minutes--;
                    seconds = 59;
                }
                else if (seconds >= 0)
                {
                    seconds--;
                }
                miliseconds = 100;
            }

            miliseconds -= Time.deltaTime * 100;
            
            int m = Mathf.RoundToInt(minutes);
            int s = Mathf.RoundToInt(seconds);
            int ms = Mathf.RoundToInt(miliseconds);
            if(minutes == 0 && seconds==0 && miliseconds <= 05)
            {
                runTimer=false;
                text.text = timerMessageCompleted;
                break;
            }
            text.text = timerMessage + "\n" + m.ToString("D2") + ":" + s.ToString("D2") + ":" + ms.ToString("D2");
            yield return null;
        }
        action.Invoke();
    } 
}



[System.Serializable]
public struct CMDTextEntry
{
    public CMDText cmdText;
    public float delay;
}

[System.Serializable]
public struct Timer
{
    public int minutes;
    public int seconds;
    public int milleseconds;
}
