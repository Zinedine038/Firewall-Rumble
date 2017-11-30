using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjectHandler : MonoBehaviour
{
    public static FlyingObjectHandler instance;
    public Transform player;
	// Use this for initialization
	void Start () {
		instance=this;
	}

    public void Send(GameObject objectToSend, Transform origin, Transform hardDrive, List<Transform> tube , bool toHardDrive ,bool download = false)
    {
        GameObject instantiatedObject = Instantiate(objectToSend, origin.transform.position, origin.transform.rotation);
        instantiatedObject.transform.LookAt(tube[0]);
        FlyingObject fo = instantiatedObject.GetComponent<FlyingObject>();
        fo.TubeRims=tube;
        fo.toPlayer=toHardDrive;
        fo.currentTarget=tube[0];
        fo.player=player;
        fo.hardDrive=hardDrive;
        if(download)
        {
            fo.downLoad=true;
        }
        fo.StartCoroutine("FollowRims");
    }

    public void Send(GameObject objectToSend, Transform origin, List<Transform> tube, bool toHardDrive,float speed)
    {
        GameObject instantiatedObject = Instantiate(objectToSend, origin.transform.position, origin.transform.rotation);
        instantiatedObject.transform.LookAt(tube[0]);
        FlyingObject fo = instantiatedObject.GetComponent<FlyingObject>();
        fo.TubeRims = tube;
        fo.toPlayer = toHardDrive;
        fo.speed=speed;
        fo.currentTarget = tube[0];
        fo.player = player;
        fo.StartCoroutine("FollowRims");
    }

}
