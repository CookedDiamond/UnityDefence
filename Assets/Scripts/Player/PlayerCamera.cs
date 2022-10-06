using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	[SerializeField] GameObject playerGameObject;
	[SerializeField] float height;
	[SerializeField] Vector2 offset;

	private void Start() {
		if (playerGameObject == null) playerGameObject = GameObject.Find("Player");
		height = transform.position.y;
	}

	private void Update() {
		transform.position = new Vector3(offset.x + playerGameObject.transform.position.x, height, offset.y + playerGameObject.transform.position.z);
	}
}
