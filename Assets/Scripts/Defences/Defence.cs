using System;
using System.Collections.Generic;

public class Defence {

	protected List<Stat> stats;
	protected BaseStats baseStats;
	protected Random random;
	public Defence(List<Stat> _stats, BaseStats _baseStats) {
		if (_baseStats == null) throw new Exception("Base stats can't be null");
		stats = _stats;
		baseStats = _baseStats;
		random = new Random();
	}
}
