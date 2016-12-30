using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // start ui

    // place ball on p1 and p2 alternating
    // scoring
    // endgame
    GameObject ball;
    bool player1Turn;
    Vector3 p1, p2;


	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Sphere");
        
        p1 = new Vector3(0, 0, -4.7f);
        p2 = new Vector3(0, 0, 4.7f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void placeBall(bool player1)
    {
        Ball.active = false;

        ball.transform.position = player1 == true ? p1 : p2;
    }

    void updatePlayerScore()
    {

    }
}
