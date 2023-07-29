using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentControl : MonoBehaviour
{
    public float pushForce;
    public NavMeshAgent agent;
    public Animation anim;

    private Camera mainCamera;
    private float raycastRange = 100;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastRange))
            {
                Vector3 newDestination = hit.point;
                agent.SetDestination(newDestination);
                if (anim != null)
                {
                    anim?.Play();
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if(rb!=null)
        {
            Vector3 direction = (collision.collider.transform.position - transform.position).normalized;
            rb.AddForce(direction * pushForce);
        }

    }
}
