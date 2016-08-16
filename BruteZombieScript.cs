using UnityEngine;
using System.Collections;

public class BruteZombieScript : MonoBehaviour {
	public Transform target;
	public bool death=false;
	NavMeshAgent agent ;
	
	//var
	public float minTarX = 1;
	public float maxTarX = 100;
	public float minTarZ = 1;
	public float maxTarZ = 100;
	public float dampx;
	public float dampz;
	public float timeSwitch = 10;
	public float chaseRange = 30;
	
	private float range = 0.0f;
	public float TarX;
	public float TarZ;
	
	//shooting 
	public GameObject projectile;
	public Transform bulletSpawn;
	public int countDown = 10;
	
	//float nextTime;
	//float timeRate = 15;
	private GameObject bruteAnim = null;
	
	
	void Start()
	{
		agent= GetComponent<NavMeshAgent>();
		bruteAnim = GameObject.FindGameObjectWithTag("BruteZombie");   
	}
	public void CreateTarPoint()
	{
		dampx = Random.Range(1,3);
		dampz = Random.Range(1, 3);
		
		TarX = Random.Range(minTarX,maxTarX) - dampx;
		// print("tarx:"+TarX);
		TarZ = Random.Range(minTarZ, maxTarZ) - dampz;
		//   print("tarz:" + TarZ);
	}
	
	void Update()
	{
		//	bruteAnim.gameObject.GetComponent<Animation>().Play("Walk");
		CreateTarPoint();
		
		if (target != null)
		{
			range = Vector3.Distance(transform.position, target.position);
		}
		else
		{
			range = 0.0f;
		}
		if (target != null && range <= chaseRange) {
			//		nextTime = Time.time + timeRate;				
			agent.destination = target.position;
			transform.LookAt (target);
			while(countDown>0)
			{
				countDown--;
				
				if (countDown <= 0) {
					
					//	Instantiate (projectile, bulletSpawn.position, bulletSpawn.rotation);
					bruteAnim.gameObject.GetComponent<Animation> ().Play ("Death");
					
					
				}
				
			}	
			countDown = 100;
			
			
		}
		else if (timeSwitch <= 0)
			timeSwitch = 10;
		
		else
		{
			agent.destination = new Vector3(TarX, TarZ);
			timeSwitch -= 1 * Time.deltaTime;
			//   print("timeswitch:"+timeSwitch);
			//  print("Time.time:"+Time.time);
			//   print("Time.deltatime:"+Time.deltaTime);
		}
		
		if(death)
		{
			// GUITextHandler.score += 100;
			Destroy(gameObject);
		}
		
	}
	void OnTriggerEnter(Collider col)
	{
		//	if (col.gameObject.tag == "Bullet") {
		//		death = true;
		//	}
		
		if (col.gameObject.tag == "Player") {
			target = col.transform;
			
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			target = null;
		}
		
	}
}
