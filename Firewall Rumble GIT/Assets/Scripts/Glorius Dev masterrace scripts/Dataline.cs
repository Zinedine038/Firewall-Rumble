using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class Dataline : MonoBehaviour
{
    public Transform origin;
    public Transform player;
    public Transform destination;
    public LineRenderer line;
    private void Start()
    {
        line.SetPosition(0, origin.position);
        line.SetPosition(1, player.position);
        line.SetPosition(2, destination.position);
    }

}
