using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour {

	FinalStats finalStats;
	public StatsList statsList;
	public PlayerAnimation anim;
	[SerializeField] private BaseStats baseStats;
	[SerializeField] private List<Stat> stats = new List<Stat>();

	public int health => finalStats.GetCurrentHealth;

	private void OnEnable() {
		if (anim == null) anim = GameObject.Find("Player").GetComponent<PlayerAnimation>();
		if (statsList == null) print("StatsList is null");

		finalStats = new FinalStats(baseStats);
		foreach (var stat in stats) finalStats.AddBaseStats(stat);
		InitUpdateStats();
	}

	public void InitUpdateStats() {
		finalStats.InitUpdate();
		if (statsList != null) statsList.UpdateList(finalStats);
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.E)) DealDamage(10, DamageType.physical);
	}

	public void DealDamage(int damage, DamageType damageType) {
		List<DamageNegation> output;
		int dmgTaken = finalStats.DamageTaken(damage, damageType, false, out output);
		anim.TriggerDamageTaken();

		print($"Health {health} \n" +
			$"Damage Taken {dmgTaken} " +
			$"({string.Join(" ", output)})\n");
	}
}
