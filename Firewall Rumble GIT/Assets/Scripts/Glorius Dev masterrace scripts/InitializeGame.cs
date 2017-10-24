using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour {
    public CMDTextEntry intro;
    public CMDTextEntry manualFirewallInitialazation;
    public TextAnimator tm;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        tm.queue.Add(intro);
        tm.queue.Add(manualFirewallInitialazation);
    }

}

[System.Serializable]
public struct CMDTextEntry
{
    public CMDText cmdText;
    public float delay;
}
