using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

    public float timeLife;
    void Start ()
    {
        Destroy(gameObject, timeLife);
    }
}
