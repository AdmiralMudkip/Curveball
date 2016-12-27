using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    bool active = false;
    float speedBase;
    float speedMultiplier = 1;
    Rigidbody body;
    Vector3 velocity;

	void Start () {
        body = GetComponent<Rigidbody>();
        velocity = body.velocity;
        
	}
	
	void Update () {
        //detect collision
        // detect what type (wall, paddle, backboard)

	    if (!active)
        {
            active = true;
            body.AddForce(new Vector3(50, 10, 200));
            velocity = body.velocity;
            speedBase = velocity.z;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        //if(col.gameObject.tag == "Paddle")
        //{
        //GetComponent<Rigidbody>();
        if (col.gameObject.tag == "Paddle")
        {
            
            //velocity.z = speedBase * speedMultiplier;
            //body.AddForce(new Vector3(0, 0, -400));
            //body.velocity.Set(0, 0, 500);
        }
        
        //}
    }

    void OnCollisionExit()
    {
        //speedMultiplier += 0.1f;
    }
}
