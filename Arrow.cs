using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public int speed = 50;

    void Start()
    {
        this.transform.Rotate(Vector3.left );
    }
    void Update()
    {
      
              this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
