using UnityEngine;
using System.Collections;

public class BallTrack : MonoBehaviour {
    GameObject ball;
	
	void Start () {
        ball = GameObject.Find("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
        var ballZ = ball.transform.position.z;
        var localTransform = transform.position;

        localTransform.z = ballZ;

        transform.position = localTransform;
	}
}
