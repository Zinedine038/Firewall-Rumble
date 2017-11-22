using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using VRTK;

public class MotherBoard : MonoBehaviour {
    public static MotherBoard instance;
    public TextMeshPro corruptionText;
    public float corruptionLevel;
    public GameObject endGameObj;
    public VRTK_Pointer pointer;
    public VRTK_StraightPointerRenderer strp;
    public bool gameActive;
    public GameObject startbutton;
    public GameObject endGameObjWon;
    private void Awake()
    {
        instance=this;
    }

    public void Corrupt(float corruptionAmount)
    {
        corruptionLevel+=corruptionAmount;
        corruptionText.text=("System Corruption: " + corruptionLevel + "%");
        if(corruptionLevel>=100)
        {
            ShowEndGameScene();
        }
    }

    private void ShowEndGameScene()
    {
        foreach (FlyingObject fo in FindObjectsOfType<FlyingObject>())
        {
            Instantiate(EventManager.instance.killPart, fo.transform.position, fo.transform.rotation);
            Destroy(fo.gameObject);
        }
        Dirtyfix.instance.ToggleGuns(false);
        gameActive = false;
        endGameObj.SetActive(true);
        pointer.enabled=true;
        strp.enabled=true;

        //set pointer true;    
    }

    public void WonGame()
    {
        foreach (FlyingObject fo in FindObjectsOfType<FlyingObject>())
        {
            Instantiate(EventManager.instance.killPart, fo.transform.position, fo.transform.rotation);
            Destroy(fo.gameObject);
        }
        endGameObjWon.SetActive(true);
        Dirtyfix.instance.ToggleGuns(false);
        pointer.enabled = false;
        strp.enabled = false;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        pointer.enabled = false;
        strp.enabled = false;
        Dirtyfix.instance.ToggleGuns(true);
        gameActive=true;
        startbutton.SetActive(false);
        EventManager.instance.StartLoop();
        FindObjectOfType<InitializeGame>().StartGame();
    }
}
