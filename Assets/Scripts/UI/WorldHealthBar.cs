using UnityEngine;

public class WorldHealthBar : BaseHealthBar {
	Camera cam;
	[SerializeField] private Color barColor;

	void Start() {
		cam = Camera.main;
		SetColor(barColor);
	}

	// Update is called once per frame
	void Update() {
		transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
		UpdateBar();
	}
}
