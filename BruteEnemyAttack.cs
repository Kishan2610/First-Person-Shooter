using UnityEngine;
using System.Collections;

public class BruteEnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks=0.5f;
	public int attackDamage=10;

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	BruteEnemyHealth bruteEnemyHealth;
	bool playerInRange;
	float timer;
	float range=0;
	float chaseRange=20;

	public Transform target;
	NavMeshAgent agent ;

	void Start()
	{

		agent= GetComponent<NavMeshAgent>();
	}
	void Awake()
	{

		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		bruteEnemyHealth = GetComponent<BruteEnemyHealth> ();
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRange=true;
		
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRange=false;
		}
	}
	void Update ()
	{

		range = Vector3.Distance (transform.position, target.position);
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange && bruteEnemyHealth.currentHealth > 0) 
		{
			Attack();
		}
		if (playerHealth.health <= 0) 
		{
			anim.SetTrigger("PlayerDead");
		}

	}
	void FixedUpdate()
	{
		Animating ();
	}
	void Attack()
	{
		timer = 0f;
		if (playerHealth.health > 0) 
		{
			playerHealth.Takedamage(attackDamage);
		}
	}
	public void Animating()
	{
		bool Idle =true;
		if (Idle == true) 
		{
			anim.SetBool("BruteIsIdle",true);
		}
		if (target != null && range <= chaseRange) {
			//		nextTime = Time.time + timeRate;				

			agent.destination = target.position;
			transform.LookAt (target);
			Idle = false;
			anim.SetBool ("BruteIsWalking", true);
		}
		if (range <= 10) {
			anim.SetBool ("BruteIsWalking", false);
			anim.SetBool ("BruteIsAttackng", true);
		}

	}
}
