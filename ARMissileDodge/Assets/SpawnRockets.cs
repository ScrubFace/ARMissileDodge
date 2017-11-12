using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRockets : MonoBehaviour {
	public GameObject[] enemy;
	public Vector3 spawnValues;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;
	// Use this for initialization
	void Start () {
		StartCoroutine (Spawner ());
	}
	
	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
	}
	IEnumerator Spawner(){
		yield return new WaitForSeconds (startWait);
		while (!stop) {
			int randEnemy = Random.Range (0, 4);
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x,spawnValues.x),5,Random.Range(-spawnValues.z,spawnValues.z));

			Instantiate (enemy[randEnemy], spawnPosition + transform.TransformPoint (0, 0, 0), gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}
