using UnityEngine;
using System.Collections;

public class AxeShoot : MonoBehaviour {

    public int range;
    public int force = 100;     //force to apply to rigid body
    public float damage = 100.0f;
    public float animationTime = 1.5f;
    public AudioClip airHit;
    public AudioClip humanHit;
    AudioSource audio;

    Vector2 screenPoint;
    private GameObject animatedArm = null;
    public float hitRate = 1.0f;
    private float timer = 0.0f;
    private bool isHitting = false;

    //Slug Variables
    GameObject gm;
    SlugScript sgs;

    //particle mechanisms
    public GameObject blood;
    public ParticleSystem sparks;

	DestroyByContact dbcm,dbcy,dbcs;
	PlayerScore pscore;




	void Start () {
        screenPoint = new Vector2(Screen.width/2,Screen.height/2);
       // print("b4s:"+Time.time);
       
       /// print("afters:" + Time.time);
        animatedArm = GameObject.Find("FpsArmsAxe");
	    audio= GetComponent<AudioSource>();

		GameObject gm = GameObject.FindWithTag ("me");
		if(gm!=null)
			dbcm = gm.GetComponent<DestroyByContact> ();
  
		GameObject gy = GameObject.FindWithTag ("ye");
		if(gy!=null)
			dbcy = gy.GetComponent<DestroyByContact> ();

		GameObject gs = GameObject.FindWithTag ("se");
		if(gs!=null)
			dbcs = gs.GetComponent<DestroyByContact> ();

		//for score
		GameObject go = GameObject.FindWithTag ("Player");
		if(go!=null)
			pscore =  go.GetComponent<PlayerScore>();


        gm = GameObject.FindGameObjectWithTag ("Slug");
		//sgs = gm.GetComponent<SlugScript> ();
	}
    

	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isHitting)
           // delay(animationTime);
            StartCoroutine(Hit());

        if (isHitting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isHitting = false;
                timer = hitRate;

            }

        }
    }
 
    
        
   IEnumerator Hit()
	{
	
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        
        animatedArm.gameObject.GetComponent<Animation>().Play();
        isHitting = true; 
       // print("b4"+Time.time);
        
        yield return new WaitForSeconds(0.5f);
      //  print("After" + Time.time);
        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Slug"))
            {
            //    hit.collider.GetComponent<Rigidbody>().AddTorque(Vector3.right, ForceMode.Impulse);

              //  Instantiate(sparks, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            
            
            //else if (hit.collider.CompareTag("enemy"))
            //{
                   hit.collider.GetComponent<Rigidbody>().AddTorque(Vector3.right, ForceMode.Impulse);
                   Instantiate(blood, hit.point,Quaternion.FromToRotation(Vector3.forward,hit.normal)) ;
                   sgs.slughealth -= 50;
                  
                   if(sgs.slughealth<=0)
                   GameObject.FindWithTag("Slug").SetActive(false);
                   
                   audio.PlayOneShot(humanHit);
            }
			else if(hit.collider.CompareTag("se"))
			{
				hit.collider.GetComponent<Rigidbody>().AddTorque(Vector3.right, ForceMode.Impulse);
				Instantiate(blood, hit.point,Quaternion.FromToRotation(Vector3.forward,hit.normal)) ;
				dbcs.health-=50;
				if(dbcs.health<=0)
					GameObject.FindWithTag("se").SetActive(false);
				pscore.Score+=100;
				audio.PlayOneShot(humanHit);
			}
			else if(hit.collider.CompareTag("ye"))
			{
				hit.collider.GetComponent<Rigidbody>().AddTorque(Vector3.right, ForceMode.Impulse);
				Instantiate(blood, hit.point,Quaternion.FromToRotation(Vector3.forward,hit.normal)) ;
				dbcy.health-=40;
				if(dbcy.health<=0)
					GameObject.FindWithTag("ye").SetActive(false);
				pscore.Score+=100;
				audio.PlayOneShot(humanHit);
			}
	
			else if(hit.collider.CompareTag("me"))
			{
				hit.collider.GetComponent<Rigidbody>().AddTorque(Vector3.right, ForceMode.Impulse);
				Instantiate(blood, hit.point,Quaternion.FromToRotation(Vector3.forward,hit.normal)) ;
				dbcm.health-=30;
				if(dbcm.health<=0)
					GameObject.FindWithTag("me").SetActive(false);
				pscore.Score+=100;
				audio.PlayOneShot(humanHit);
			}

			else if(hit.collider.CompareTag("cube"))
			{
				print ("cubehit");
			
				hit.collider.GetComponent<Rigidbody>().AddTorque(Vector3.right, ForceMode.Impulse);
				Instantiate(blood, hit.point,Quaternion.FromToRotation(Vector3.forward,hit.normal)) ;
				//dbc.health-=50;
				
				audio.PlayOneShot(humanHit); 
			}
			else
			{
				audio.PlayOneShot(airHit);
			}
		}
        
      
}
}
