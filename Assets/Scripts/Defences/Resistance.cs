using System.Collections.Generic;

public class Resistance : Defence, IDefence {
	public Resistance(List<Stat> _stats, BaseStats _baseStats) : base(_stats, _baseStats) {
	}

	public float getDamage(float damage, List<DamageNegation> damageNegation) {
		if (damage <= 0) { return 0; }
		return damage * (1f - (getValue() / 100f));
	}

	public int getValue() {
		int resistance = baseStats.Resistance;
		foreach (var stat in stats) { resistance += stat.Resistance; }
		return resistance;
	}
}

