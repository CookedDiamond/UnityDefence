using System.Collections.Generic;

/// <summary>
/// Stores all the Stats for the player and calculates damage taken 
/// and calculates the damage taken and regeneration.
/// </summary>
public class FinalStats {

	private BaseStats baseStats;

	// Defences
	private Dodge dodge;
	private Resistance resistance;

	public FinalStats(BaseStats _baseStats) {
		baseStats = _baseStats;
	}

	private void createDefences() {
		dodge = new Dodge(stats, baseStats);
		resistance = new Resistance(stats, baseStats);
	}

	private List<Stat> stats = new List<Stat>();

	public void AddBaseStats(Stat baseStats) {
		stats.Add(baseStats);
		InitUpdate();
	}

	// Recalculates all the values on how they should be in the beginning.
	public void InitUpdate() {
		createDefences();
		currentHealth = MaxHealth;
	}

	// Health
	public int FlatHealth {
		get {
			int _flatHealth = 0;
			foreach (var stat in stats) { _flatHealth += stat.FlatHealth; }
			return _flatHealth;
		}
	}

	public int IncreasedHealth {
		get {
			int _increasedHealth = 0;
			foreach (var stat in stats) { _increasedHealth += stat.IncreasedHealth; }
			return _increasedHealth;
		}
	}
	private float currentHealth; // Is a float because health regeneration isn't calculated just every second so values get floaty.
	public int GetCurrentHealth => (int)(currentHealth); // is still outputted as a int.

	public int MaxHealth => (int)((baseStats.Health + FlatHealth) * (1f + (IncreasedHealth / 100f)));

	// Dodge
	public int DodgeChance => dodge.getValue();

	// Resistance
	public int Resistance => resistance.getValue();


	/// <summary>
	/// Calculates the damage taken for the player.
	/// </summary>
	/// <param name="d">The inition raw damage number.</param>
	/// <param name="dot">true if the damage is damage over time.</param>
	/// <param name="damageType">The curresponding damage type.</param>
	/// <param name="damageNegation">States if what Negated the damage.</param>
	/// <returns></returns>
	public int DamageTaken(int d, DamageType damageType, bool dot, out List<DamageNegation> damageNegation) {
		float damage = d;
		// Set default values
		damageNegation = new List<DamageNegation>();
		// !dot Dodge
		if (!dot) damage = dodge.getDamage(damage, damageNegation);
		// Block

		// Resistance
		damage = resistance.getDamage(damage, damageNegation);

		// ! dot Armour

		d = (damage > 0) ? (int)damage : 0; //cuts the float to round it always down and keeps it positive or zero!
		currentHealth -= d;
		return d;
	}

	/// <summary>
	/// Calculates the values on how they should change over time while playing.
	/// </summary>
	public void TickUpdate() {

	}

}

public enum DamageNegation {
	none,
	dodged,
	blocked
}

public enum DamageType {
	physical,
	fire,
	lightning,
	cold,
	chaos,
}

public enum Ailments {
	brokenarmour, // less armour
	shock, //more damage taken
	freeze, //less movement speed
	deathmark, //less resistance
}
