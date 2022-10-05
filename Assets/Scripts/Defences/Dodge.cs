using System;
using System.Collections.Generic;

public class Dodge : Defence, IDefence {
	public Dodge(List<Stat> _stats, BaseStats _baseStats) : base(_stats, _baseStats) { }

	public float getDamage(float damage, List<DamageNegation> damageNegation) {
		if (damage <= 0) { return 0; }
		else if (random.NextDouble() <= getValue() / 100f) {
			damageNegation.Add(DamageNegation.dodged);
			return 0;
		}
		return damage;
	}

	public int getValue() {
		int dodgeChance = baseStats.DodgeChance;
		foreach (var stat in stats) { dodgeChance += stat.DodgeChance; }
		return Math.Clamp(dodgeChance, 0, baseStats.MaxDodgeChance);
	}
}

