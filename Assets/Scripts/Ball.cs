using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    bool active = false;
    float speed = 1f;
    Rigidbody body;

	void Start () {
        body = GetComponent<Rigidbody>();

        
	}
	
	void Update () {
        //detect collision
        // detect what type (wall, paddle, backboard)

	    if (!active)
        {
            active = true;
            body.AddForce(new Vector3(300, 10, 1000));
        }
	}

    void oncCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "paddle")
        {
            //rigidbody.transform.
        }
    }
}
