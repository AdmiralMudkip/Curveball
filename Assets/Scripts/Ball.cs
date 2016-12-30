using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public static bool active = false;
    float speedBase;
    float speedMultiplier = 1;
    Rigidbody body;
    Vector3 velocity;

    private enum colType { paddle, wall };

    colType collision;



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
            body.AddForce(new Vector3(0, 200, 200));
            velocity = body.velocity;
            speedBase = velocity.z;
        }
	}

    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Paddle") // a player hits it back
        {
            speedMultiplier *= -1.1f;
            collision = colType.paddle;

            //velocity.z = speedBase * speedMultiplier;
            //body.AddForce(new Vector3(0, 0, -400));
            //body.velocity.Set(0, 0, 500);
        }
        else if (col.gameObject.name == "Back1")
        {
            // player 2 scores
        }
        else if (col.gameObject.tag == "Back2")
        {
            // player 1 scores
        }
        else
        {
            collision = colType.wall;
        }
        //}
    }

    void OnCollisionExit()
    {
        //speedMultiplier += 0.1f;

        //        body.velocity.Set(body.velocity.x, body.velocity.y, speedBase * speedMultiplier);
        //var vel = body.velocity;
        if (collision == colType.paddle)
        {
            body.AddForce(0, 0, 1 * speedMultiplier, ForceMode.Impulse);
        }
    }
}
