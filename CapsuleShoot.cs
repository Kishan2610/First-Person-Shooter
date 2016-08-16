using UnityEngine;
using System.Collections;

public class CapsuleShoot : MonoBehaviour {

    public int range = 1000;
    public LineRenderer laser = null;
   // public GameObject theArrow = null;
    public float speed = 10f;

    private Vector3 pos = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private Vector3 endpos = Vector3.zero;

    private RaycastHit hit;
    public bool isOut = false;



    void Start()
    {
        laser = this.gameObject.GetComponent<LineRenderer>();
	}

    void FixedUpdate()
    {
        pos = this.transform.position;
        direction = this.transform.TransformDirection(Vector3.forward);
        
        laser.SetPosition(0,pos);

        if (Physics.Raycast(pos, direction,out hit, range))
        {
            laser.SetPosition(1, hit.point);
        }
        endpos = pos + direction * range ;
        laser.SetPosition(1,endpos);
        
    }
    void Update()
    {
     //   if (Input.GetKeyDown(KeyCode.Mouse0))
       // {
         //   isOut = true;
        //}

     //   if (isOut)
       // {
         //   GameObject cloneArrow = null;
              
            

			//ScoreText.text = "Score:" + Score;
            //rob.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
            //rob.AddForce(this.transform.forward * speed);
           // print("rotation:"+this.transform.rotation);
          //  isOut = false;
       }

}

