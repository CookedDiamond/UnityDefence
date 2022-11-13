using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	[SerializeField] public float speed;
	[SerializeField] float rotationSpeed;
	[SerializeField] float sprintSpeed = 0.8f;

	public const KeyCode MoveForward = KeyCode.W;
	public const KeyCode MoveBackward = KeyCode.S;
	public const KeyCode MoveLeft = KeyCode.A;
	public const KeyCode MoveRight = KeyCode.D;
	public const KeyCode MoveSprint = KeyCode.LeftShift;

	private void Start() {
		rb = GetComponent<Rigidbody>();
	}

	private void Update() {

		var dir = new Vector3(0, 0, 0);

		if (Input.GetKey(MoveForward)) dir += new Vector3(0, 0, 1);
		if (Input.GetKey(MoveBackward)) dir += new Vector3(0, 0, -1);
		if (Input.GetKey(MoveLeft)) dir += new Vector3(-1, 0, 0);
		if (Input.GetKey(MoveRight)) dir += new Vector3(1, 0, 0);

		dir = dir.normalized * speed * ((Input.GetKey(MoveSprint) ? (1 + sprintSpeed) : 1));
		if (dir != Vector3.zero) rotatePlayer(dir);

		rb.velocity = dir;
	}

	void rotatePlayer(Vector3 direction) {
		float future = Quaternion.LookRotation(direction).eulerAngles.y;
		float current = transform.rotation.eulerAngles.y;

		float rotation = Mathf.LerpAngle(current, future, rotationSpeed);
		transform.rotation = Quaternion.Euler(0, rotation, 0);
	}




}
