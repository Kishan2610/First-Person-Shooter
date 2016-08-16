using UnityEngine;
using System.Collections;

public class SmallEnemy : MonoBehaviour {

	
	private GameObject smallAnim = null;
	void Start () {
		smallAnim = GameObject.FindGameObjectWithTag("SmallZombie");
	}
	
	
	void Update () {
		smallAnim.gameObject.GetComponent<Animation>().Play("Walk");
		
		
	}
}
