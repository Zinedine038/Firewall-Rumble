using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomNoiseManager : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();
    private AudioSource aSource;
    private void Start()
    {
        clips = Resources.LoadAll<AudioClip>("SFX").ToList();
        aSource=GetComponent<AudioSource>();
        StartCoroutine("RandomNoises");
    }
    private IEnumerator RandomNoises()
    {
        while(true)
        {
            int randomClipIndex = Random.Range(0,clips.Count-1);
            aSource.PlayOneShot(clips[randomClipIndex]);
            yield return new WaitForSeconds(clips[randomClipIndex].length+Random.Range(1,5));
        }
    }
}
