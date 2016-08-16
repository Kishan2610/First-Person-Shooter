using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed = 100f;
	Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		rb= GetComponent<Rigidbody>();
		rb.velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag.Equals ("Boundary")) 
		{
			Destroy(GetComponent<CapsuleCollider>().gameObject);
		}
		if (other.tag.Equals ("Slug")) 
		{
			Destroy(GetComponent<CapsuleCollider>().gameObject);
			Destroy(other.gameObject);
			float radius = 30.0f;
			float power = 200.0f;
			Vector3 explosionPos = other.transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) 
			{
				if (hit && hit.GetComponent<Rigidbody>())
					hit.GetComponent<Rigidbody>().AddExplosionForce (power, explosionPos, radius, 3.0F);
			}
		}
	}
}
