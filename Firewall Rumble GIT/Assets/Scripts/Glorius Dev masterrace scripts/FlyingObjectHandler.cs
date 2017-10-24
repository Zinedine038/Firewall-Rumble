using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjectHandler : MonoBehaviour {
    public static FlyingObjectHandler instance;
    public Transform player;
	// Use this for initialization
	void Start () {
		instance=this;
	}

    public void Send(GameObject objectToSend, Transform origin, Transform hardDrive, bool download = false)
    {
        GameObject instantiatedObject = Instantiate(objectToSend, origin.transform.position, origin.transform.rotation);
        instantiatedObject.transform.LookAt(player.transform);
        FlyingObject fo = instantiatedObject.GetComponent<FlyingObject>();
        fo.currentTarget=player;
        fo.player=player;
        fo.hardDrive=hardDrive;
        if(download)
        {
            fo.downLoad=true;
        }
    }

}
