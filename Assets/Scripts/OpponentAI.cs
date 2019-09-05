using UnityEngine;
using System.Collections;

public class OpponentAI : MonoBehaviour {
    public GameObject ball;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        var ballTransform = ball.transform.position;
        var localTransform = transform.position;

        localTransform.x = ballTransform.x;
        localTransform.y = ballTransform.y;

        transform.position = localTransform;
    }
}
