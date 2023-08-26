using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLasers : MonoBehaviour
{
    public GameObject shootBall;
    public Transform shootLocation;
    public float speed = 100;
    public float shootTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0, shootTime); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {

            GameObject obj = Instantiate(shootBall, shootLocation.position, shootLocation.rotation);
            obj.GetComponent<Rigidbody>().AddForce(shootLocation.forward * speed, ForceMode.Impulse);

            //Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            //RaycastHit hit;
            //if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit,range))
            //{
            //    if (hit.collider.GetComponent<IDamagable>() != null)
            //    {
            //        hit.collider.GetComponent<IDamagable>().TakeDamage(damage);
            //    }
            //}
    }

}
