using UnityEngine;
using System.Collections;
using System.Threading;
public class parabolic : MonoBehaviour {
     	Vector3 target;
		public float range;
	    public float playerRange=100f;
		PlayerWeapons projectilePos;
	    
		public float nextFire;
		public float fireRate;
		public float firingAngle = 45.0f;
		public float gravity = 9.8f;
		public Texture2D cursorTexture;

		public int priority=0;	

		public GameObject Projectile;      
		private Transform myTransform;

		void Awake()
		{
			myTransform = transform;      
		}

		void OnTriggerEnter(Collider other)	
		{
			if (other.tag == "enemy")
			{
				Destroy(gameObject);
				Destroy (other);
			}
			
		}

	GameObject FindClosestEnemy() {
		GameObject[] goS;
		GameObject[] goY;
		GameObject[] goM;
		goS = GameObject.FindGameObjectsWithTag("BruteZombie");
		goY = GameObject.FindGameObjectsWithTag("LargeZombie");
		goM = GameObject.FindGameObjectsWithTag("SmallZombie");

		GameObject closest;
		GameObject closestS = null;
		float distanceS = Mathf.Infinity;
		GameObject closestY = null;
		float distanceY = Mathf.Infinity;
		GameObject closestM = null;
		float distanceM = Mathf.Infinity;

		Vector3 position = transform.position;

		foreach (GameObject go in goS) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;

			if (curDistance < distanceS) {
				closestS = go;
				distanceS = curDistance;
			}
		}

		foreach (GameObject go in goY) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			
			if (curDistance < distanceY) {
				closestY = go;
				distanceY = curDistance;
			}
		}

		foreach (GameObject go in goM) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			
			if (curDistance < distanceM) {
				closestM = go;
				distanceM = curDistance;
			}
		}

		if (distanceS < distanceY) {
			if (distanceS < distanceM) 
				closest = closestS;
			 else 
				closest = closestM;
		} else {
			if(distanceY<distanceM)
				closest = closestY;
			else
				closest = closestM;
		}

		return closest;
	}



		void Update()
		{   
		GameObject target = FindClosestEnemy ();
		if(target!=null)
		StartCoroutine (SimulateProjectile (target.transform.position));
	// check	if (GameObject.FindGameObjectWithTag ("me") == null)
	//		print ("No mature enemy");
	/* OLD

		if ( GameObject.FindGameObjectWithTag ("se") != null ) {
			target = GameObject.FindGameObjectWithTag ("se").transform.position;
			range = Vector3.Distance(projectilePos.shotSpawn.position, target);

			if(range<=playerRange)
			priority = 1;
		} 
		if (GameObject.FindGameObjectWithTag ("ye") != null) {
			target = GameObject.FindGameObjectWithTag ("ye").transform.position;
			range = Vector3.Distance(projectilePos.shotSpawn.position, target);
		//	print ("pr"+playerRange);
			if(range<=playerRange)
			priority = 2;
		} 
		if (GameObject.FindGameObjectWithTag ("me") != null) {
			target = GameObject.FindGameObjectWithTag ("me").transform.position;
			range = Vector3.Distance (projectilePos.shotSpawn.position, target);
			print ("pr" + playerRange);
			if (range <= playerRange) {
				priority = 3;
				print ("yes");
			}
		}
		if(GameObject.FindGameObjectWithTag ("me") == null && GameObject.FindGameObjectWithTag ("ye") == null && GameObject.FindGameObjectWithTag ("se") == null )
			priority = 0;

		//  Cursor.SetCursor (cursorTexture, Vector2.one, CursorMode.Auto);
		//	Cursor.visible = true;
	
	//	range = Vector3.Distance(projectilePos.shotSpawn.position, target);
	
		//Shooting according to the priority of enemy

		if (priority == 3)
			StartCoroutine (SimulateProjectile (target));
		else if (priority == 2)
			StartCoroutine (SimulateProjectile (target));
		else if (priority == 1)
			StartCoroutine (SimulateProjectile (target));
		else if (priority == 0) {
			print ("In priority 0");
			target = new Vector3(0,0,0);
		}
		
       	 Destroy(gameObject,5);*/
        }
		
		void Start()
		{
			GameObject gm = GameObject.FindGameObjectWithTag ("gun");
			projectilePos= gm.GetComponent<PlayerWeapons>();
			//StartCoroutine (SimulateProjectile (target));
			
		}
		

		IEnumerator SimulateProjectile(Vector3 tg)
		{
			float target_Distance = Vector3.Distance(transform.position,tg);

			
			// Calculate the velocity needed to throw the object to the target at specified angle.
			float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
			
			// Extract the X  Y componenent of the velocity
			float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
			float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
            Vx = Vx - 10;
            Vy = Vy - 10;

			// Calculate flight time.
			float flightDuration = target_Distance / Vx;
			// Rotate projectile to face the target.
			transform.rotation = Quaternion.LookRotation(tg - transform.position);
			
			float elapse_time = 0;
			
			while (elapse_time < flightDuration || transform.position.y>0.5f)
			{
				transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
				elapse_time += Time.deltaTime;
				yield return null;
			}
			if (transform.position.y < 0f)
				Destroy (gameObject);
		}  
}

