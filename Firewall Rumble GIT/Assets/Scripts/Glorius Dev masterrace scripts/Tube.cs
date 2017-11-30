using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tube : MonoBehaviour {
    public Transform startingPoint;
    public float speed;
    public List<Transform> rims = new List<Transform>();
    public GameObject[] randomObjects;
	// Use this for initialization
	void Start () {
		StartCoroutine("SendRandomObjects");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SendRandomObjects()
    {
        while(true)
        {

            yield return new WaitForSeconds(Random.Range(3, 6));
            SendObjects(Random.Range(0,randomObjects.Length-1));
            yield return null;
        }
    }

    void SendObjects(int i)
    {
        FlyingObjectHandler.instance.Send(randomObjects[i],startingPoint,rims,false,speed);
    }
}
