using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public Transform player;
    public Transform hardDrive;
    public Transform currentTarget;
    public float speed;
    public bool downLoad = false;
    public bool goodFile = false;
    public CMDText lines;



    private void Update()
    {
        transform.position+=transform.forward*Time.deltaTime*speed;
        transform.LookAt(currentTarget);
        if(currentTarget==player && Vector3.Distance(transform.position,player.position)<2)
        {
            currentTarget=hardDrive;
        }
        if(currentTarget==hardDrive && Vector3.Distance(transform.position, hardDrive.position) < 3)
        {
            if(!goodFile)
            {
                if(lines!=null)
                {
                    TextAnimator.instance.ProcessTextImmidiate(lines);
                    MotherBoard.instance.Corrupt(10f);
                }
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        //FindObjectOfType<Internet>().RemoveDownload();

    }

}
