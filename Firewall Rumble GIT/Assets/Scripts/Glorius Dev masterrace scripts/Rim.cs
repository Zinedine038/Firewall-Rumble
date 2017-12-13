using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rim : MonoBehaviour {
    public Color color;
    public float intensity;
    public Material reference;
    bool objEntered;
	// Use this for initialization
	void Start () {
        reference=GetComponent<Renderer>().material;
        StartCoroutine("RandomColors");
	}

    public virtual void Update()
    {
        reference.SetColor("_EmissionColor", new Color(color.r,color.b,color.g,1.0f) *intensity) ;
    }

    IEnumerator RandomColors()
    {
        while(true)
        {
            color.r = UnityEngine.Random.Range(0f, 1.0f);
            color.g = UnityEngine.Random.Range(0f, 1.0f);
            color.b = UnityEngine.Random.Range(0f, 1.0f);
            yield return new WaitForSeconds(1f);
        }
    }

    public virtual void GlowRim(FlyingObject fo)
    {
        StopAllCoroutines();
        StartCoroutine("Glow");
    }

    IEnumerator Glow()
    {
        while(true)
        {
            intensity+=2*Time.deltaTime;
            if(intensity>=2)
            {
                intensity=2;
                break;
            }
            yield return null;
        }
        while (true)
        {
            intensity -= 2 * Time.deltaTime;
            if (intensity <= 0)
            {
                intensity = 0;
                break;
            }
            yield return null;
        }
    }


}
