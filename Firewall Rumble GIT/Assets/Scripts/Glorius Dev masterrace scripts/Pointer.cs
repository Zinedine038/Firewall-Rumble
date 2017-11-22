using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Pointer : MonoBehaviour {
    public VRTK.VRTK_StraightPointerRenderer pointer;
    public VRTK.VRTK_ControllerEvents vrtkce;
    RaycastHit hit;
    string hitString;
	// Use this for initialization
	void Start () {
		vrtkce.TriggerTouchStart+=Click;
	}

    private void Click(object sender, ControllerInteractionEventArgs e)
    {
        if(pointer.validCollisionColor==Color.green)
        {
            if(hitString=="RebootButton")
            {
                MotherBoard.instance.EndGame();
                print("reboot");
            }
            else if(hitString=="StartButton")
            {
                MotherBoard.instance.StartGame();
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500f))
        {
            hitString=hit.transform.tag;
            if (hit.transform.tag == "RebootButton" || hit.transform.tag == "StartButton")
            {
                pointer.validCollisionColor = Color.green;
                pointer.invalidCollisionColor = Color.green;
            }
            else
            {
                pointer.validCollisionColor = Color.red;
                pointer.invalidCollisionColor = Color.red;
            }
        }
    }


  
}

