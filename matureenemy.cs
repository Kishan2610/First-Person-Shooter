using UnityEngine;
using System.Collections;

public class matureenemy : MonoBehaviour {

	// Use this for initialization
	//public Transform target;
	//NavMeshAgent agent;

	private int flag1=0;
	private int flag2;
	public float xmax;
	public float xmin;
	public float zmax;
	public float zmin;
	public float speed=2f;
	public float chaseRange=10 ;
	private float range=20;
	public float movementspeed;
	public Transform leader;
	public Transform follower;
	private float count;
	
	private Vector3 tempAxis;

	void Start () {

	//	agent = GetComponent<NavMeshAgent> ();

		tempAxis = new Vector3 (0f, 1f, 0f);
		count = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	//	agent.SetDestination (target.position);

		range = Vector3.Distance( follower.position,leader.position );
		
		if (range <= chaseRange) {
			
			// If the follower is close enough to the leader, then chase!
			follower.LookAt (leader);
			
			follower.Translate (speed * Vector3.forward * Time.deltaTime);
			
		} // End if (range <= chaseRange)
		
		else {
			
			if (flag1 == 0 && transform.position.z > zmin) {
				transform.position -= transform.forward.normalized * Time.deltaTime * movementspeed;
				flag2 = 1;
				
			} else if (flag2 == 0 && transform.position.x > xmin) {
				
				transform.position -= transform.right.normalized * Time.deltaTime * movementspeed;
				flag1 = 1;
				
				
			} else if (flag2 == 1 && transform.position.z < zmax) {
				
				transform.position += transform.forward.normalized * Time.deltaTime * movementspeed;
				flag2 = 1;
				
			} else if (flag2 == 1 && transform.position.x > xmax) {
				
				transform.position -= transform.right.normalized * Time.deltaTime * movementspeed;
				
			}
		}
	}
	void spin(){
		if(count>1f){
			transform.Rotate(0f,90*Time.deltaTime,0f);
			count+=Time.deltaTime;
		}
	}	
}
