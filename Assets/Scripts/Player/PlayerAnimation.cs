using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	[SerializeField] Animator animator;
	[SerializeField] Rigidbody playerRB;
	[SerializeField] PlayerMovement playerMovm;
	[SerializeField] Player player;

	const string WalkingState = "WalkingState";
	const string DamageTaken = "DamageTaken";


	void Start() {
		if(playerRB == null) playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
		if(animator == null) animator = GameObject.Find("Player").GetComponent<Animator>();
		if(playerMovm == null) playerMovm = GameObject.Find("Player").GetComponent<PlayerMovement>();
		if(player == null) player = GameObject.Find("Player").GetComponent<Player>();
	}

	void Update() {
		// WalkAnimation
		if (playerRB.velocity.magnitude == playerMovm.speed) animator.SetInteger(WalkingState, 2);
		else if (playerRB.velocity.magnitude > playerMovm.speed) animator.SetInteger(WalkingState, 3);
		else if (playerRB.velocity.magnitude < playerMovm.speed && playerRB.velocity.magnitude > 0) animator.SetInteger(WalkingState, 1);
		else animator.SetInteger(WalkingState, 0);
	}


	public void TriggerDamageTaken() {
		animator.SetTrigger(DamageTaken);
	}
}
