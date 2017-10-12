using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public static bool active = false;
    float speedBase = 5;
    float speedMultiplier = 1;
    Rigidbody body;

    //Rigidbody player, computer;
    Vector3 _velocity;
    //bool _isColliding = false;

    

    //colType collision;
    
    void Start () {
        body = GetComponent<Rigidbody>();

        // remove this later
        
	}
	
	void Update () {

        // some bullshit to set up the inital spin, can remove this later
        if (!active)
        {
            active = true;
            body.velocity = new Vector3(0, 0, speedBase);
            body.AddTorque(0, 1, 1, ForceMode.Impulse);
            
            _velocity = body.velocity;
        }
    }

    void FixedUpdate()
    {
        // apply force based on rotation cuz dem curves
        body.AddForce(body.rotation.eulerAngles.y / 300, body.rotation.eulerAngles.x / 300, 0, ForceMode.Acceleration);

        // go for broke and manually calculate when we should be bouncing
        //have the ball notify the game manager when it reaches an endzone
        // game manager has responsibilities of keeping track

        Vector3 pos = body.transform.position;
        float x = body.velocity.x;
        float y = body.velocity.y;
        float z = body.velocity.z;

        
        if( pos.x >= 0.5f || pos.x <= 0.5f ) {
            x  = body.velocity.x * -1;
        }
        if( pos.y >= 25 || pos.y <= -25 ) {
            y = body.velocity.y * -1;
        }

        body.velocity.Set( x, y, body.velocity.z );

    }

    public void reverseZ() {
        float z = body.velocity.z;
        Debug.Log( "reverse" );
        body.velocity.Set( body.velocity.x, body.velocity.y, z = z * -1 );
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (_isColliding)
    //    {
    //        return;
    //    }
    //    _isColliding = true;
    //    RaycastHit hit;

        

    //    Physics.Raycast(new Ray(body.position, _velocity), out hit); // assuming this will connect with the thing that we're hitting, even if we're just colliding.
    //    _velocity = Vector3.Reflect(_velocity, hit.normal);
    //    //col.

    //    if (col.gameObject.tag == "Paddle") // a player hits it back
    //    {
    //        speedMultiplier += 0.1f;
    //        speedMultiplier *= -1;
    //        collision = colType.paddle;

    //        body.velocity = _velocity;
    //        //velocity.z = speedBase * speedMultiplier;
    //        //body.AddForce(new Vector3(0, 0, -400));
    //        //body.velocity.Set(0, 0, 500);
    //    }
    //    else if (col.gameObject.name == "Back1")
    //    {
    //        GameManager.updatePlayerScore(2);
    //    }
    //    else if (col.gameObject.tag == "Back2")
    //    {
    //        GameManager.updatePlayerScore(1);
    //    }
    //    else
    //    {
    //        collision = colType.wall;
    //        body.velocity = _velocity;
    //    }
    //}
    
    //void OnCollisionExit()
    //{
    //    _isColliding = false;
        
    //    if (collision == colType.paddle)
    //    {
    //        body.AddTorque(MouseTrack.velocity * 0.5f, ForceMode.Impulse);
    //    }
    //}
}
