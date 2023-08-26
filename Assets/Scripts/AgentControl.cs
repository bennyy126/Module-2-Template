using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentControl : MonoBehaviour
{
    public float pushForce;
    public NavMeshAgent agent;
    public Animation anim;
    public float slowDownDistance;

    private Camera mainCamera;
    private float raycastRange = Mathf.Infinity;
    float orgSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        orgSpeed = agent.speed;
    }
    void OnFire()
    {
        print("hi");
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

    // Update is called once per frame
    void Update()
    {
        if (agent.destination != null){
            float distance = Vector3.Distance(transform.position, agent.destination);
            if (distance < slowDownDistance)
            {
                agent.speed = Mathf.Lerp(0, orgSpeed, distance / slowDownDistance);
            }
            else {
                agent.speed = orgSpeed;
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
