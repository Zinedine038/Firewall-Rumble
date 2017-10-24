using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Animator gunAnimator;
    [SerializeField]
    private AnimationClip gunFireAnimation;

    [Header("Projectile Variables")]
    public GameObject bullet;
    public GameObject placeHolderbullet;
    public Transform firePoint;
    public Transform bulletReset;
    //public ParticleSystem fireParticle;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Fire());
        }
    }

    public IEnumerator Fire()
    {
        //fireParticle.Play();
        GameObject spawnedFakeBullet = Instantiate(placeHolderbullet,bulletReset.transform.position,bulletReset.transform.rotation);
        spawnedFakeBullet.transform.SetParent(transform);
        spawnedFakeBullet.transform.localPosition=Vector3.zero;
        placeHolderbullet.transform.position=bulletReset.position;
        gunAnimator.SetTrigger("Fire");
        yield return new WaitForSeconds(gunFireAnimation.length-0.1f);
        Destroy(spawnedFakeBullet);
        GameObject spawnedBullet = Instantiate(bullet,firePoint.transform.position,firePoint.transform.rotation);
        Destroy(spawnedBullet,10f);
    }
}
