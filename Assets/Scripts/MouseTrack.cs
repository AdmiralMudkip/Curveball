using UnityEngine;
using System.Collections;

public class MouseTrack : MonoBehaviour {

    float offsetX, offsetY;
    public Vector3 lastPosition;
    public static Vector3 velocity;

    void Start()
    {
        //var temp = GameObject.Find("playerOne").GetComponent<Collider>().bounds.size;

        offsetX = 4.3f;
        offsetY = 1.7f;
    }
    
	void Update () {
        Vector3 temp = Input.mousePosition;
        temp.z = 3f;
        transform.position = Camera.main.ScreenToWorldPoint(temp);

        var pos = transform.position;
        
        // gross elseifs but are probably more efficent than a bunch of ternary operators.  
        // maybe.  if c# isn't smart.
        if (pos.x > offsetX)
        {
            pos.x = offsetX;
        }
        else if (pos.x < -offsetX)
        {
            pos.x = -offsetX;
        }

        if (pos.y > offsetY)
        {
            pos.y = offsetY;
        }
        else if (pos.y < -offsetY)
        {
            pos.y = -offsetY;
        }
        
        transform.position = pos;
    }

    void FixedUpdate()
    {
        velocity = lastPosition - transform.position / 0.0111111f;
        lastPosition = transform.position;
    }
}
