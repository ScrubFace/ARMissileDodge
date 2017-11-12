using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRockets : MonoBehaviour {
	public GameObject enemy;
	public List<GameObject> enemies = new List<GameObject>();
	public int score;
	public float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;
	public Time time;
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
		Vector3 spawnRotation = new Vector3 (90, 0, 0);
		while (PlayerController.dead != true) { 
			score = 0;
			Vector3 spawnPosition = new Vector3 ((float)Random.Range (-1,1), 4 ,(float)(Random.Range(-1,1)));
			Instantiate (enemy, spawnPosition,  Quaternion.Euler(spawnRotation));
			enemies.Add(enemy);
			/*for (int i = 0; i <= enemies.Count; i++) {
				if (enemies[i].transform.position.y <= 0) {
					Destroy(gameObject);
					enemies.Remove (enemies [i]);
					Instantiate (enemy, spawnPosition,  Quaternion.Euler(spawnRotation));
					score += 1;
				}
					
			}*/
			yield return new WaitForSeconds (spawnWait);
		}
	}
	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "trump_Ip_anim_iddle01") {
			Destroy (col.gameObject);
			PlayerController.dead = true;
		}
	}
}
