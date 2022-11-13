using UnityEngine;

/// <summary>
/// Handles the visual effects triggered by a script for the player.
/// </summary>
public class VisualPlayer : MonoBehaviour {
	[SerializeField] private WorldHealthBar healthBar;
	[SerializeField] private PlayerAnimation anim;
	[SerializeField] private Player player;

	private void OnEnable() {
		if (healthBar == null) healthBar = GameObject.Find("Player").GetComponentInChildren<WorldHealthBar>();
		if (anim == null) anim = GameObject.Find("Player").GetComponent<PlayerAnimation>();
		if (player == null) player = GameObject.Find("Player").GetComponent<Player>();
	}

	public void UpdateHealthBar() {
		healthBar.SetValues(player.GetFinalStats().GetCurrentHealth, player.GetFinalStats().MaxHealth);
	}

	public void DamageTaken() {
		anim.TriggerDamageTaken();
		UpdateHealthBar();
	}
}
