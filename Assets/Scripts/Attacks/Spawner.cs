using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField] GameObject prefab;
	[SerializeField] int delay = 5;
	int ticks = 0;

	private void Start() {
	}

	void FixedUpdate() {
		ticks++;
		if (ticks % delay == 0) {
			var go = Instantiate(prefab);
			go.transform.position = transform.position;
			go.transform.parent = transform;
		}

	}
}
