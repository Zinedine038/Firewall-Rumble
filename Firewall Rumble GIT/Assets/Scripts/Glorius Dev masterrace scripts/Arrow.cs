using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arrow : MonoBehaviour {
    public SpriteRenderer mySprite;
	// Use this for initialization
	void Start ()
    {
        mySprite=GetComponentInChildren<SpriteRenderer>();
	}
	
	public void PointAt(Transform target)
    {
        transform.LookAt(target);
        StopAllCoroutines();
        StartCoroutine("FadeIn");
    }

    public IEnumerator FadeIn()
    {
        mySprite.DOKill();
        mySprite.DOFade(1,1);
        yield return new WaitForSeconds(3f);
        FadeOut();
    }

    void FadeOut()
    {
        mySprite.DOKill();
        mySprite.DOFade(0, 1);
    }

}
