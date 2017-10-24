using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

    public GameObject Particlespawn;
    public float bulletSpeed = 10;
    public Rigidbody bullet;
   
    void Update()
    {
         //bullet = GetComponent<Rigidbody>();
        if (Input.GetButtonDown("Fire1"))
        Fire();
    }

    void Fire()
    {
        

        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bullet.AddForce(transform.forward * bulletSpeed);
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bulletshoot")
            print("hit");
        {
            Destroy(col.gameObject);
            Instantiate(Particlespawn, col.transform.position, transform.rotation);
        }

    }

}
