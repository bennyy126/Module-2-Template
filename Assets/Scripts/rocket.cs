using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rocket : MonoBehaviour
{
    public float force = 1f;
    public GameObject obj;
    public Transform spawnobj;
    public TextMeshProUGUI text;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
	text.text = "speed: " + (int)(RB.velocity.magnitude * 2.237);
        if(Input.GetKey(KeyCode.W))
	{
		//Instantiate(obj, spawnobj.position, spawnobj.rotation);
		RB.AddForce(transform.up * force);
		Debug.Log("hi");
	}
        if(Input.GetKey(KeyCode.S))
	{
		//Instantiate(obj, spawnobj.position, spawnobj.rotation);
		RB.AddForce(-transform.up * force * 0.2f);
		Debug.Log("hi");
	}
    }
}
