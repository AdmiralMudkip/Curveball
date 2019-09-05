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
    
    public static Vector3 player1StartPosition, player2StartPosition;


    static int playerOneScore;
    static int playerTwoScore;

    private enum GameState {
        Ready,
        Playing
    }

    GameState gameState;

	// Use this for initialization
	void Start () {

        player1StartPosition = new Vector3( 0, 0, 5f );
        player2StartPosition = new Vector3( 0, 0, -5f );
                
        //p1 = new Vector3(0, 0, -4.7f);
        //p2 = new Vector3(0, 0, 4.7f);

        player1Turn = Random.value > 0.5; 
        
        if ( player1Turn ) {
            ball.transform.position = player1StartPosition;
        }
        else {
            ball.transform.position = player2StartPosition;
        }

        ball.StopBall();

        gameState = GameState.Ready;
        // start on p1 or p2 randomly
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

    public void placeBall(bool player1)
    {
        ball.StopBall();

        //ball.transform.position = player1 == true ? p1 : p2;
    }

    public static void updatePlayerScore(int player)
    {
        //playerscores[player - 1]++;
        //placeBall(player == 1);
    }
}
