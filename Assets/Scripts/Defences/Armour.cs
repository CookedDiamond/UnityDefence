using System;
using System.Collections.Generic;

public class Armour : Defence, IDefence {
	public Armour(List<Stat> _stats, BaseStats _baseStats) : base(_stats, _baseStats) { }

	public float getDamage(float damage, List<DamageNegation> damageNegated) {
		throw new NotImplementedException();
	}

	public int getValue() {
		int flatArmour = baseStats.Armour;
		int increasedArmour = baseStats.IncreasedArmour;
		foreach (var stat in stats) flatArmour += stat.FlatArmour;
		foreach (var stat in stats) increasedArmour += stat.IncreasedArmour;
		return (int)Math.Clamp(flatArmour * (1+increasedArmour/100f), 0, baseStats.MaxArmour);
	}
}

