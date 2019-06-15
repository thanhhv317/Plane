using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Material bg;
    public Transform target;

    public float speed;

    public Vector3 offset;

	// Use this for initialization
	void Update () {
        bg.mainTextureOffset = new Vector2(Time.time * speed, 0);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPos = target.position + offset;
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;
        transform.position = newPos;
	}
}
