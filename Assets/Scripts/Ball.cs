using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public static bool active = false;
    float speedBase;
    float speedMultiplier = 1;
    float direction;
    Rigidbody body;
    Vector3 _velocity;
    bool _isColliding = false;

    private enum colType { paddle, wall };

    colType collision;



    void Start () {
        body = GetComponent<Rigidbody>();
        
        
	}
	
	void Update () {
        //detect collision
        // detect what type (wall, paddle, backboard)

	    if (!active)
        {
            active = true;
            body.velocity = new Vector3(1, 2, 7);
            _velocity = new Vector3(1, 2, 7);    
        
        }
        
    }

    void FixedUpdate()
    {
        
        // apply force based on rotation cuz dem curves
    }

    void OnCollisionEnter(Collision col)
    {
        if (_isColliding)
        {
            return;
        }
        _isColliding = true;
        RaycastHit hit;

        Physics.Raycast(new Ray(body.position, _velocity), out hit); // assuming this will connect with the thing that we're hitting, even if we're just colliding.
        _velocity = Vector3.Reflect(_velocity, hit.normal);
        //col.

        if (col.gameObject.tag == "Paddle") // a player hits it back
        {
            speedMultiplier += 0.1f;
            speedMultiplier *= -1;
            collision = colType.paddle;

            body.velocity = _velocity;
            //velocity.z = speedBase * speedMultiplier;
            //body.AddForce(new Vector3(0, 0, -400));
            //body.velocity.Set(0, 0, 500);
        }
        else if (col.gameObject.name == "Back1")
        {
            GameManager.updatePlayerScore(2);
        }
        else if (col.gameObject.tag == "Back2")
        {
            GameManager.updatePlayerScore(1);
        }
        else
        {
            collision = colType.wall;
            body.velocity = _velocity;
        }
    }
    
    void OnCollisionExit()
    {
        _isColliding = false;
        //speedMultiplier += 0.1f;

        //        body.velocity.Set(body.velocity.x, body.velocity.y, speedBase * speedMultiplier);
        //var vel = body.velocity;
        if (collision == colType.paddle || collision == colType.wall)
        {
            body.velocity = _velocity;
            
            //body.AddForce(0, 0, 1 * speedMultiplier, ForceMode.Impulse);
        }
        
    }
}
