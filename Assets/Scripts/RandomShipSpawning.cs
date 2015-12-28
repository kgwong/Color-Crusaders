using UnityEngine;
using System.Collections;

public class RandomShipSpawning : MonoBehaviour {

    public GameObject shipToSpawn;

    public float spawnRate;

	void Start ()
    {
        InvokeRepeating("Spawn", 0f, spawnRate);
	}
	
    void Spawn()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0f);
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360));
        Instantiate(shipToSpawn, randomPosition, randomRotation);
    }
}
