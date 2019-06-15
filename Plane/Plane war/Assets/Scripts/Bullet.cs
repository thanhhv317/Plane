using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

	void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
