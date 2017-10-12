using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // start ui

    // place ball on p1 and p2 alternating
    // scoring
    // endgame
    public Ball ball;
    //static GameObject ball;
    public GameObject playerOne, playerTwo;
    bool player1Turn;
    bool bouncing = false;
    static Vector3 p1, p2;

    static int[] playerscores = new int[2];

	// Use this for initialization
	void Start () {
        //ball = (Ball)GameObject.Find("Sphere").GetComponent("MonoBehavior");
        //playerOne = GameObject.Find( "playerOne" );
        //playerTwo = GameObject.Find( "playerTwo" );

        
        p1 = new Vector3(0, 0, -4.7f);
        p2 = new Vector3(0, 0, 4.7f);

        player1Turn = Random.value > 0.5; // start on p1 or p2 randomly
        //placeBall(player1Turn);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        if( !bouncing ) {
            if( ball.transform.position.z >= 4.5 ) {
                ball.reverseZ();
                // playerTwo collision
                bouncing = true;
            }
            else if ( ball.transform.position.z <= -4.5 ) {
                ball.reverseZ();
                //if ( )
                bouncing = true;
            }
        }
    }

    static void placeBall(bool player1)
    {
        Ball.active = false;

        //ball.transform.position = player1 == true ? p1 : p2;
    }

    public static void updatePlayerScore(int player)
    {
        playerscores[player - 1]++;
        placeBall(player == 1);
    }
}
