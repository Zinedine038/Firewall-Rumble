using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoiseManager : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();
    private void Start()
    {
        StartCoroutine("RandomNoises");
    }

}
