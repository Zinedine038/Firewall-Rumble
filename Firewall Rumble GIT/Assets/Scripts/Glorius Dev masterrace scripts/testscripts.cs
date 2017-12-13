using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position+=transform.forward*15*Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Rim")
        {
            other.gameObject.GetComponent<Rim>().GlowRim(new FlyingObject());
        }
    }
}
