using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : Projectile {
	[SerializeField] bool destroyOnImpact = true;
	[SerializeField] bool setRandomDirectionOnStart = true;

	new private void Start() {
		base.Start();
		if (setRandomDirectionOnStart) transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
	}

	new private void OnTriggerEnter(Collider other) {
		if (hitsOnlyPlayer && other.gameObject.tag != "Player") return;

		base.OnTriggerEnter(other);
		if (destroyOnImpact) DestroyProjectile();
	}
}
