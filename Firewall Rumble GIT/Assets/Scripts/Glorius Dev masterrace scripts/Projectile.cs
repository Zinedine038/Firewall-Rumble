using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;
    private RaycastHit hit;
    public GameObject particleGreen;
    public GameObject particleRed;
    private void Start()
    {
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update () {
		transform.position+=transform.forward*Time.deltaTime*bulletSpeed;
        if(Physics.Raycast(transform.position,transform.forward,out hit, 2f))
        {
            if(hit.transform.tag=="File")
            {
                var fo = hit.transform.GetComponent<FlyingObject>();
                if(fo!=null)
                {
                    if (fo.goodFile)
                    {
                        MotherBoard.instance.Corrupt(5f);
                        Destroy(hit.transform.gameObject);
                        Instantiate(particleGreen, transform.position, transform.rotation);
                    }
                    else
                    {
                        Destroy(hit.transform.gameObject);
                        Instantiate(particleRed, transform.position, transform.rotation);
                    }
                }
                Destroy(this.gameObject);
            }
            if(!hit.collider.isTrigger)
            {
                Instantiate(particleGreen, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}