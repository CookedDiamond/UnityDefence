using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private FinalStats finalStats;
	public StatsList statsList;
	[SerializeField] private BaseStats baseStats;
	[SerializeField] private List<Stat> stats = new List<Stat>();

	[SerializeField] private GameManager gameManager;

	[SerializeField] private VisualPlayer visuals;

	public int health => finalStats.GetCurrentHealth;

	private void OnEnable() {
		if (statsList == null) print("StatsList is null");
		if (gameManager == null && GameObject.Find("GameManager").GetComponent<GameManager>() != null) {
			gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		}
		else {
			Console.Error.WriteLine("No GameManager was found and non was selected.");
		}

		visuals = GetComponent<VisualPlayer>();
		finalStats = new FinalStats(baseStats);
		foreach (var stat in stats) finalStats.AddBaseStats(stat);
		InitUpdateStats();
		visuals.UpdateHealthBar();
	}

	public void InitUpdateStats() {
		finalStats.InitUpdate();
		if (statsList != null) statsList.UpdateList(finalStats);
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.E)) GetDamage(10, DamageType.physical);
	}

	public FinalStats GetFinalStats() {
		return finalStats;
	}

	public void GetDamage(int damage, DamageType damageType) {
		List<DamageNegation> output;
		int dmgTaken = finalStats.DamageTaken(damage, damageType, false, out output);

		if(finalStats.GetCurrentHealth <= 0) {
			death();
		}

		visuals.DamageTaken();

		print($"Health {health} \n" +
			$"Damage Taken {dmgTaken} " +
			$"({string.Join(" ", output)})\n");
	}

	void death() {
		gameManager.PlayerDied();
		transform.position = Vector3.zero;
		finalStats.InitUpdate();
	}
}
