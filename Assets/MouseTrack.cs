using UnityEngine;
using System.Collections;

public class MouseTrack : MonoBehaviour {

    float offsetX, offsetY;

    void Start()
    {
        var temp = GameObject.Find("Paddle").GetComponent<Collider>().bounds.size;

        offsetX = 5 - temp.x / 2;
        offsetY = 2.65f - temp.y / 2;
    }


	void Update () {
        Vector3 temp = Input.mousePosition;
        temp.z = 3f;
        transform.position = Camera.main.ScreenToWorldPoint(temp);

        var pos = transform.position;
        
        pos.x = (pos.x > offsetX) ? offsetX : pos.x;
        pos.x = (pos.x < -offsetX) ? -offsetX : pos.x;

        pos.y = (pos.y > offsetY) ? offsetY : pos.y;
        pos.y = (pos.y < -offsetY) ? -offsetY : pos.y;

        transform.position = pos;
    }
}
