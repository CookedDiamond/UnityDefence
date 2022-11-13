using MyBox;
using UnityEngine;

public class Projectile : ParticleObject {
	[Space()]
	[Header("Protectile")]
	[SerializeField] protected bool hitsOnlyPlayer = true;
	[SerializeField] protected float speed = 1;
	[SerializeField] protected int damage = 10;
	[SerializeField] protected DamageType damageType = DamageType.physical;
	[SerializeField] protected bool timeDeath;
	[ConditionalField("timeDeath"), SerializeField] protected float dieAfter = 5f;
	protected float lifeTime = 0f;

	[Separator("FlyPaths")]
	[SerializeField] protected FlyPath flyPath;
	[ConditionalField(nameof(flyPath), false, FlyPath.circle), SerializeField] bool counterClockRotation = true;
	[ConditionalField(nameof(flyPath), false, FlyPath.circle), SerializeField] float radius = 0f;
	[ConditionalField(nameof(flyPath), false, FlyPath.circle), SerializeField, Tooltip("Only affects radius if radius is equal 0.")] Vector2 randomRadius;
	[SerializeField] protected Vector3 center;

	Rigidbody rb;


	new protected void Start() {
		// Get References.
		if (rb == null) rb = GetComponent<Rigidbody>();
		center = transform.position;

		if (radius == 0) radius = Random.Range(randomRadius.x, randomRadius.y);

		base.Start();
	}


	void Update() {
		particleUpdate(); // Particle system.
		move(); // Velocity controller.
		life(); // LifeTime management.
	}

	void life() {
		lifeTime += Time.deltaTime;
		if (timeDeath && lifeTime >= dieAfter) {
			particleEnd();
			DestroyObject();
		}
	}

	void move() {
		if (flyPath == FlyPath.simple) rb.velocity = transform.forward * speed;

		else if (flyPath == FlyPath.circle) {
			float angle = transform.rotation.eulerAngles.y;

			if (counterClockRotation) {
				float x = Mathf.Cos((-angle - 15) * Mathf.Deg2Rad) * radius;
				float z = Mathf.Sin((-angle - 15) * Mathf.Deg2Rad) * radius;
				transform.position = new Vector3(center.x + x, transform.position.y, center.z + z);
				transform.rotation = Quaternion.Euler(0, angle - speed * Time.deltaTime * 100, 0);
			}
			else {
				float x = Mathf.Cos(360 - (angle - 90 + 15) * Mathf.Deg2Rad) * radius;
				float z = Mathf.Sin(360 - (angle - 90 + 15) * Mathf.Deg2Rad) * radius;
				transform.position = new Vector3(center.x + x, transform.position.y, center.z + z);
				transform.rotation = Quaternion.Euler(0, angle + speed * Time.deltaTime * 100, 0);
			}
		}
	}

	protected void OnTriggerEnter(Collider other) {
		if (lifeTime == 0) return;
		particleImact(other);
		dealDamage(other.gameObject);
	}

	new public void DestroyObject() {
		if (particleSystemsPlaying.Count == 0) {
			Destroy(gameObject);
		}
		else {
			destroyedButParticleIsPlaying = true;
			SetActiveProjectile(false);
			speed = 0;
			if (rb != null) rb.velocity = Vector3.zero;

		}

	}

	public void SetActiveProjectile(bool b) {
		GetComponentInChildren<MeshCollider>().enabled = b;
		GetComponentInChildren<MeshRenderer>().enabled = b;
	}

	void dealDamage(GameObject target) {
		if (target.tag != "Player") return;
		var player = target.GetComponent<Player>();
		player.GetDamage(damage, damageType);
	}
}

public enum FlyPath {
	simple,
	circle,
	cone,
	sideways
}
