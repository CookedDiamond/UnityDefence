using System;
using System.Collections.Generic;

internal interface IDefence {

	int getValue();

	float getDamage(float damage, List<DamageNegation> damageNegated);
}

