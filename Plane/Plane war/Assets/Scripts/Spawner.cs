using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    public Transform[] positions;

    public float timeSpawn;
    private float spawn;

    private int pos;

    public Transform camera;
    public Vector3 offset;

    void Start()
    {
        spawn = timeSpawn;
        pos = Random.Range(0, 6);
    }

	void Update () {
        spawn -= Time.deltaTime;
        if (spawn < 0 && GameManager.tap)
        {
            Instantiate(enemy, positions[pos].position, transform.rotation);
            pos = Random.Range(0, 6);
            spawn = timeSpawn;
        }

        Vector3 newPos = camera.position + offset;
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;
        transform.position = newPos;
	}
}
