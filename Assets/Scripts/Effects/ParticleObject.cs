using System.Collections.Generic;
using UnityEngine;

public class ParticleObject : MonoBehaviour {
	[Header("Particle")]
	[SerializeField] private ParticleSystem onStart;
	[SerializeField] private ParticleSystem onMoving;
	[SerializeField] private ParticleSystem onImpact;
	[SerializeField] private ParticleSystem onEnd;
	private bool playedParticleEnd = false;
	[SerializeField] private bool setParticleSystemPositionToImpact = false;
	[SerializeField] protected bool destroyedButParticleIsPlaying = false;
	[SerializeField] protected List<ParticleSystem> particleSystemsPlaying = new List<ParticleSystem>();
	private List<ParticleSystem> allParticleSystems = new List<ParticleSystem>();

	protected void Start() {
		// Fill allParticleSystems so you can easily iterate over it.
		if (onStart != null) allParticleSystems.Add(onStart);
		if (onMoving != null) allParticleSystems.Add(onMoving);
		if (onImpact != null) allParticleSystems.Add(onImpact);
		if (onEnd != null) allParticleSystems.Add(onEnd);

		particleStart(); // Plays start particles.
	}

	void particleStart() {
		if (onStart != null) {
			particlePlay(onStart);
		}
	}

	protected void particleImact(Collider collider) {
		if (onImpact == null) return;

		if (setParticleSystemPositionToImpact) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, collider.gameObject.transform.position - transform.position, out hit)) {
				onImpact.transform.position = hit.point;
			}
		}
		particlePlay(onImpact);

	}

	protected void particleUpdate() {
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
			DestroyObject();
		}
	}

	protected void particleEnd() {
		if (onEnd != null && !playedParticleEnd) {
			particlePlay(onEnd);
			playedParticleEnd = true;
		}
	}

	void particlePlay(ParticleSystem ps) {
		ps.gameObject.SetActive(true);
		ps.Play();
		particleSystemsPlaying.Add(ps);
	}

	protected void DestroyObject() {
		Destroy(gameObject);
	}
}
