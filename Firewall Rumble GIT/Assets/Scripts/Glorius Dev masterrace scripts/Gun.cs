using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource))]
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
    public VRTK_ControllerEvents vrtkce;
    public GameObject fireParticle;
    public AudioClip shootSFX;
    AudioSource source;
    //public ParticleSystem fireParticle;
    // Update is called once per frame
    void Awake()
    {
        vrtkce.TriggerTouchStart += FireBullet;
        source=GetComponent<AudioSource>();
    }

    private void FireBullet(object sender, ControllerInteractionEventArgs e)
    {
        StartCoroutine(Fire());
    }

    public IEnumerator Fire()
    {
        //GameObject spawnedFakeBullet = Instantiate(placeHolderbullet,bulletReset.transform.position,bulletReset.transform.rotation);
        //spawnedFakeBullet.transform.SetParent(transform);
        //spawnedFakeBullet.transform.localPosition=Vector3.zero;
        //placeHolderbullet.transform.position=bulletReset.position;
        gunAnimator.SetTrigger("Fire");
        yield return null;
        //yield return new WaitForSeconds(gunFireAnimation.length-0.1f);
        source.PlayOneShot(shootSFX);
        //Destroy(spawnedFakeBullet);
        GameObject spawnedBullet = Instantiate(bullet,firePoint.transform.position,firePoint.transform.rotation);
        Instantiate(fireParticle,firePoint.transform.position,firePoint.transform.rotation);
        Destroy(spawnedBullet,10f);
    }
}
