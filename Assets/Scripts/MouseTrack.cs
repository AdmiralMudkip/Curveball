using UnityEngine;

public class MouseTrack : MonoBehaviour {

    float minX, maxX, minY, maxY;

    const float HALF_PADDLE_WIDTH = 0.5f;
    const float HALF_PADDLE_HEIGHT = 0.375f;
    
    void Start()
    {
        minX = -4f;
        maxX = 4f;

        minY = -2.8f;
        maxY = 2f;
    }
    
	void Update () {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 3f;
        
        var paddlePosition = Camera.main.ScreenToWorldPoint( mousePosition );
        paddlePosition.y = paddlePosition.y - 0.5f;

        if ( paddlePosition.x + HALF_PADDLE_WIDTH > maxX ) {
            paddlePosition.x = maxX - HALF_PADDLE_WIDTH;
        }
        else if ( paddlePosition.x - HALF_PADDLE_WIDTH < minX ) {
            paddlePosition.x = minX + HALF_PADDLE_WIDTH;
        }

        if ( paddlePosition.y + HALF_PADDLE_HEIGHT > maxY ) {
            paddlePosition.y = maxY - HALF_PADDLE_HEIGHT;
        }
        else if ( paddlePosition.y - HALF_PADDLE_HEIGHT < minY ) {
            paddlePosition.y = minY + HALF_PADDLE_HEIGHT;
        }

        // offset for paddle height? im not sure why we need to do this

        transform.position = paddlePosition;
    }

    void FixedUpdate()
    {
        //velocity = lastPosition - transform.position / 0.0111111f;
        //lastPosition = transform.position;
    }
}
