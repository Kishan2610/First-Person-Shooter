using UnityEngine;
using System.Collections;

public class SlugScript : MonoBehaviour 
{
	private GameObject player;
	private PlayerHealth playerhealth;
    public int slughealth;
	private float range;

	Animator anim;

	void Start () 
	{
        slughealth = 100;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerhealth = player.GetComponent<PlayerHealth> ();
		range = 30;
		anim = GetComponent<Animator> ();

		anim.SetBool ("SlugIsAttacking",false);
    //    print("slghstart"+slughealth);
	}


    void Update()
    {
     //   print("slghupdate" + slughealth);
		/*
        if (slughealth <= 0)
		{
         //   Destroy(gameObject);
            print("inside dead");
      //      GameObject.FindWithTag("Slug").SetActive(false);
        }

		Vector3 displacement = player.transform.position - transform.position;
		float distance = displacement.x * displacement.x + displacement.y * displacement.y + displacement.z * displacement.z;
		if (distance <= range) 
		{
			playerhealth.health -= 5f;
			yield return new WaitForSeconds (3);
		}
*/
    }
	void OnTriggerEnter (Collider other)
	{
    
		if (other.tag.Equals ("Player")) 
		{
		    playerhealth.health -= 5f;
			anim.SetBool("SlugIsAttacking",true);
		}

	}
	void OnTriggerExit (Collider other)
	{
		
		if (other.tag.Equals ("Player")) 
		{

			anim.SetBool("SlugIsAttacking",false);
		}
		
	}
}
