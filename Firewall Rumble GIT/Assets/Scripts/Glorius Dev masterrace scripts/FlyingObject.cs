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
        print(Vector3.Distance(transform.position, player.position) < 2);
        print(currentTarget);
        if(currentTarget==player && Vector3.Distance(transform.position,player.position)<2)
        {
            currentTarget=hardDrive;
        }
        if(currentTarget==hardDrive &&  goodFile == false && Vector3.Distance(transform.position, hardDrive.position) < 2)
        {
            TextAnimator.instance.ProcessTextImmidiate(lines);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<Internet>().RemoveDownload();
        if(goodFile)
        {
            //penalty!
            print("shit");
        }
        else
        {

        }
    }

}
