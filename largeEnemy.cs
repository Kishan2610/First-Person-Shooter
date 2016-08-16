using UnityEngine;
using System.Collections;

public class largeEnemy : MonoBehaviour {
	
	private GameObject largeAnim = null;
	void Start () {
		largeAnim = GameObject.FindGameObjectWithTag("LargeZombie");
	}
	
	
	void Update () {
		largeAnim.gameObject.GetComponent<Animation>().Play("Walk");
		
		
	}
}
