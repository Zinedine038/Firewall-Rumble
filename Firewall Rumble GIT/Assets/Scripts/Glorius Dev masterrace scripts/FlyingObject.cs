using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public List<Transform> TubeRims;
    public Transform player;
    public Transform hardDrive;
    public Transform currentTarget;
    public float speed;
    public bool downLoad = false;
    public bool goodFile = false;
    public CMDText lines;
    public string fileType;
    public bool toPlayer = true;
    public bool vague;
    private void Update()
    {

    }
    

    public IEnumerator FollowRims()
    {
        foreach(Transform tube in TubeRims)
        {
            while(Vector3.Distance(transform.position,tube.position)>1)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
                transform.LookAt(tube.GetComponent<Renderer>().bounds.center);
                if(Vector3.Distance(transform.position, tube.GetComponent<Renderer>().bounds.center)<1)
                {
                    break;
                }
                yield return null;
            }
        }
        if(toPlayer)
        {
            currentTarget=hardDrive;
            while(Vector3.Distance(transform.position, hardDrive.position) > 1)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
                transform.LookAt(hardDrive);
                yield return null;
            }
            if (!goodFile)
            {
                if (lines != null)
                {
                    TextAnimator.instance.ProcessTextImmidiate(lines);
                    MotherBoard.instance.Corrupt(10f);
                }
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Rim")
        {
            other.gameObject.GetComponent<Rim>().GlowRim(this);
        }
    }

    private void OnDestroy()
    {
        //FindObjectOfType<Internet>().RemoveDownload();

    }

}
