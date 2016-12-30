using UnityEngine;
using System.Collections;

public class MouseTrack : MonoBehaviour {

    float offsetX, offsetY;
    Vector3 lastPosition;
    float speedX, speedY;

    void Start()
    {
        var temp = GameObject.Find("Paddle").GetComponent<Collider>().bounds.size;

        offsetX = 5 - temp.x / 2;
        offsetY = 2.45f - temp.y / 2;
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
        lastPosition = pos;


    }
}
