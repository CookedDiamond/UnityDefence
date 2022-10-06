using CartoonFX;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[Header("Particle")]
	[SerializeField] ParticleSystem onStart;
	[SerializeField] ParticleSystem onMoving;
	[SerializeField] ParticleSystem onImpact;
	[SerializeField] bool setParticleSystemPositionToImpact = false;
	[SerializeField] bool destroyedButParticleIsPlaying = false;
	[SerializeField] List<ParticleSystem> particleSystemsPlaying = new List<ParticleSystem>();
	List<ParticleSystem> allParticleSystems = new List<ParticleSystem>();

	[Header("Protectile")]
	[SerializeField] protected bool hitsOnlyPlayer = true;
	[SerializeField] protected float speed = 1;
	Rigidbody rb;


	protected void Start() {
		particleStart();

		// Get References.
		if (rb == null) rb = GetComponent<Rigidbody>();

		// Fill allParticleSystems so you can easily iterate over it.
		if (onStart != null) allParticleSystems.Add(onStart);
		if (onMoving != null) allParticleSystems.Add(onMoving);
		if (onImpact != null) allParticleSystems.Add(onImpact);
	}


	void Update() {
		particleUpdate(); // Particle

		// Start Movement.
		rb.velocity = transform.forward * speed;
	}

	void particlePlay(ParticleSystem ps) {
		ps.gameObject.SetActive(true);
		ps.Play();
		particleSystemsPlaying.Add(ps);
	}

	void particleStart() {
		if (onStart != null) {
			particlePlay(onStart);
		}
	}

	void particleUpdate() {
		if (onMoving != null) {
			if (!onMoving.isPlaying) {
				particlePlay(onMoving);
			}
		}

		// Create new list so you can remove
		List<ParticleSystem> list = new List<ParticleSystem>(particleSystemsPlaying);
		foreach (ParticleSystem p in particleSystemsPlaying) {
			if (!p.isPlaying) list.Remove(p);
		}
		// Set the new old list to the new one so changes apply.
		particleSystemsPlaying = list;

		// disables ParticleSystem if it's not used.
		foreach (ParticleSystem p in allParticleSystems) {
			if (particleSystemsPlaying.Contains(p)) continue;
			p.gameObject.SetActive(false);
		}

		// Checks if all ParticlySystems stopped playing so you can Destroy the whole Object.
		if (destroyedButParticleIsPlaying && particleSystemsPlaying.Count == 0) {
			DestroyProjectile();
		}
	}

	void particleImact(Collider collider) {
		if (onImpact == null) return;

		if (setParticleSystemPositionToImpact) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, collider.gameObject.transform.position - transform.position, out hit)) {
				onImpact.transform.position = hit.point;
			}
		}
		particlePlay(onImpact);

	}

	protected void OnTriggerEnter(Collider other) {
		particleImact(other);
	}

	public void DestroyProjectile() {
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
}
