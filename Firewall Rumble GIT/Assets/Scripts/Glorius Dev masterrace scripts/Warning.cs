using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour {
    public LensFlare flare;
    public Light spotLight;
    public bool loop;

    private void Start()
    {
        StartCoroutine("WarningLoop");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            GiveWarning();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            loop=!loop;
        }
    }

    public void GiveWarning()
    {
        StopCoroutine("WarningLight");
        spotLight.intensity = 0;
        flare.brightness = 0;
        StartCoroutine("WarningLight");
    }

    IEnumerator WarningLight()
    {
        float time=0;
        while(time<0.5f)
        {
            spotLight.intensity+=10*Time.deltaTime;
            flare.brightness+=2*Time.deltaTime;
            time+=1*Time.deltaTime;
            yield return null;
        }
        while(time<1f)
        {
            spotLight.intensity -= 10 * Time.deltaTime;
            flare.brightness -= 2 * Time.deltaTime;
            time += 1 * Time.deltaTime;
            yield return null;
        }
        spotLight.intensity=0;
        flare.brightness=0;
    }

    IEnumerator WarningLoop()
    {
        while(true)
        {
            while (loop)
            {
                float time = 0;
                while (time < 0.5f)
                {
                    spotLight.intensity += 10 * Time.deltaTime;
                    flare.brightness += 2 * Time.deltaTime;
                    time += 1 * Time.deltaTime;
                    yield return null;
                }
                while (time < 1f)
                {
                    spotLight.intensity -= 10 * Time.deltaTime;
                    flare.brightness -= 2 * Time.deltaTime;
                    time += 1 * Time.deltaTime;
                    yield return null;
                }
                spotLight.intensity = 0;
                flare.brightness = 0;
                yield return null;
            }
            yield return null;
        }

    }
}
