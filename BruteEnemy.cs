using UnityEngine;
using System.Collections;

public class BruteEnemy : MonoBehaviour {

	private GameObject bruteAnim = null;
	void Start () {
		bruteAnim = GameObject.FindGameObjectWithTag("BruteZombie");
	}
	

	void Update () {
		bruteAnim.gameObject.GetComponent<Animation>().Play("Walk");

	
	}
}
