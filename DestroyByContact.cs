using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
//	public GameObject explosion;
//	public GameObject playerExplosion;


	public float health=100f;
	PlayerScore pscore;
	//PlayerWeapons pw;

    void Start()
    {
		GameObject gm = GameObject.FindWithTag ("Player");
		if(gm!=null)
		pscore =  gm.GetComponent<PlayerScore>();

	
		//  GameObject go = GameObject.FindWithTag("gun");
       // if (go != null)
        //{
          //  pw = go.GetComponent<PlayerWeapons>();
        //}
    }

	public void Die()
	{
		if (health <= 0)
			Destroy (gameObject);
	}

    void OnTriggerEnter(Collider other)
	{
   //     print("out") ;
        if (gameObject.tag.Equals("BruteZombie"))
		{
      //      print("in");
            //Capsules
            if (other.tag.Equals("capsule1"))
            {
            //    print("IN ME Cap1");
                health -= 10f;
                Destroy(other.gameObject);
				pscore.Score += 10;
            }
            else if (other.tag.Equals("capsule2"))
            {
                health -= 20f;
                Destroy(other.gameObject);
                pscore.Score += 20;
            }
		
            else if (other.tag.Equals("capsule3"))
            {
                health -= 30f;
                Destroy(other.gameObject);
                pscore.Score += 30;
            }
            else if (other.tag.Equals("capsule4"))
            {
                health -= 40f;
                Destroy(other.gameObject);
                pscore.Score += 40;
            }
 
            //Liquid Bombs
            if (other.tag.Equals("Liquid Bomb"))
            {
                health -= 70f;
                pscore.Score += 50;
            }
            else if (other.tag.Equals("Liquid Bomb2"))
            {
                health -= 80f;
                pscore.Score += 70;
            }
            else if (other.tag.Equals("Liquid Bomb3"))
            {
                health -= 90f;
                pscore.Score += 90;
            }
            else if (other.tag.Equals("Liquid Bomb4"))
            {
                health -= 100f;
                pscore.Score += 110;
            }

            //Bombs
            if (other.tag.Equals("bomb"))
            {
                health -= 30f;
                Destroy(other.gameObject);
                pscore.Score += 40;
            }
            else if (other.tag.Equals("bomb2"))
            {
                health -= 40f;
                Destroy(other.gameObject);
                pscore.Score += 60;
            }
            else if (other.tag.Equals("bomb3"))
            {
                health -= 50f;
                Destroy(other.gameObject);
                pscore.Score += 80;
            }
            else if (other.tag.Equals("bomb4"))
            {
                health -= 60f;
                Destroy(other.gameObject);
                pscore.Score += 100;
            }

		}
		else if (gameObject.tag.Equals("LargeZombie"))
		{
            //Capsules
            if (other.tag.Equals("capsule1"))
            {
                health -= 20f;
                Destroy(other.gameObject);
                pscore.Score += 10;
            }
            else if (other.tag.Equals("capsule2"))
            {
                health -= 30f;
                Destroy(other.gameObject);
                pscore.Score += 20;
            }
            else if (other.tag.Equals("capsule3"))
            {
                health -= 40f;
                Destroy(other.gameObject);
                pscore.Score += 30;
            }
            else if (other.tag.Equals("capsule4"))
            {
                health -= 50f;
                Destroy(other.gameObject);
                pscore.Score += 40;
            }
 
            //Liquid Bombs
            if (other.tag.Equals("Liquid Bomb"))
            {
                health -= 60f;
                pscore.Score += 50;
            }
            else if (other.tag.Equals("Liquid Bomb2"))
            {
                health -= 70f;
                pscore.Score += 70;
            }
            else if (other.tag.Equals("Liquid Bomb3"))
            {
                health -= 80f;
                pscore.Score += 90;
            }
            else if (other.tag.Equals("Liquid Bomb4"))
            {
                health -= 90f;
                pscore.Score += 110;
            }
			
            //Bombs
            if(other.tag.Equals("bomb")) 
			{
				health-=40f;
				Destroy (other.gameObject);
                pscore.Score += 40;
            }
            else if (other.tag.Equals("bomb2"))
            {
                health -= 50f;
                Destroy(other.gameObject);
                pscore.Score += 60;
            }
            else if (other.tag.Equals("bomb3"))
            {
                health -= 60f;
                Destroy(other.gameObject);
                pscore.Score += 80;
            }
            else if (other.tag.Equals("bomb4"))
            {
                health -= 70f;
                Destroy(other.gameObject);
                pscore.Score += 100;
            }
        }
		else if(gameObject.tag.Equals("SmallZombie"))
		{
			//Capsules
            if (other.tag.Equals("capsule1"))
			{
				health -= 30f;
				Destroy (other.gameObject);
                pscore.Score += 10;
            }
            else if(other.tag.Equals("capsule2"))
            {
                health-=40f;
				Destroy (other.gameObject);
                pscore.Score += 20;
            }
            else if (other.tag.Equals("capsule3"))
            {
                health -= 50f;
                Destroy(other.gameObject);
                pscore.Score += 30;
            }
            else if (other.tag.Equals("capsule4"))
            {
                health -= 60f;
                Destroy(other.gameObject);
                pscore.Score += 40;
            }

            //Liquid Bombs
            if (other.tag.Equals("Liquid Bomb"))
            {
                health -= 50f;
                pscore.Score += 50;
            }
            else if (other.tag.Equals("Liquid Bomb2"))
            {
                health -= 60f;
                pscore.Score += 70;
            }
            else if (other.tag.Equals("Liquid Bomb3"))
            {
                health -= 70f;
                pscore.Score += 90;
            }
            else if (other.tag.Equals("Liquid Bomb4"))
            {
                health -= 80f;
                pscore.Score += 110;
            }

            //Bombs
            if (other.tag.Equals("bomb"))
            {
                health -= 50f;
                Destroy(other.gameObject);
                pscore.Score += 40;
            }
            else if (other.tag.Equals("bomb2"))
            {
                health -= 60f;
                Destroy(other.gameObject);
                pscore.Score += 60;
            }
            else if (other.tag.Equals("bomb3"))
            {
                health -= 70f;
                Destroy(other.gameObject);
                pscore.Score += 80;
            }
            else if (other.tag.Equals("bomb4"))
            {
                health -= 80f;
                Destroy(other.gameObject);
                pscore.Score += 100;
            }
		} 
	    else if (other.tag != "Boundary" && other.tag != "floor" && gameObject.tag!="enemy") 
		{
		//	Instantiate (explosion, transform.position, transform.rotation);
			if(other.tag=="Player")
			{
			//	Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		Die ();
	/*	if(health<=0f)
		{
			Destroy (gameObject);
		}*/

        if (other.tag.Equals("Arrow"))
        {
            health -= 25;
            Destroy(other.gameObject);
			pscore.Score += 100;
        }
	}

}
