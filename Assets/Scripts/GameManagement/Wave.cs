using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	[SerializeField] private WaveSpawn[] spawns;
	[SerializeField] private int duration;
	private WaveManager waveManager;

	// clean up.
	private List<GameObject> removeOnWaveEnd = new List<GameObject>();

	private void Start() {
		if (waveManager == null) waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
	}

	public void StartWave() {
		for (int i = 0; i < spawns.Length; i++) {
			StartCoroutine(spawn(i));
		}
		StartCoroutine(end());
	}

	IEnumerator spawn(int index) {
		var waveSpawn = spawns[index];
		yield return new WaitForSeconds(waveSpawn.timeStamp);
		removeOnWaveEnd.Add(Instantiate(waveSpawn.spawner, new Vector3(waveSpawn.position.x, 0, waveSpawn.position.y), Quaternion.Euler(Vector3.zero), transform).gameObject);
	}

	IEnumerator end() {
		yield return new WaitForSeconds(duration);
		print("Round WON!");
		EndWave();
	}

	public void EndWave() {
		StopAllCoroutines();
		foreach (var go in removeOnWaveEnd) {
			Destroy(go);
		}
		removeOnWaveEnd.Clear();
	}


}


