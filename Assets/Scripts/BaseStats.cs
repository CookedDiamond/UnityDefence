using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It stores all base stats every player has wihtout any cost.
/// </summary>
[CreateAssetMenu(fileName = "BaseStats", menuName = "ScriptableObjects/BaseStats", order = 1)]
public class BaseStats : ScriptableObject {
	public int Health = 50;
	public int HealthRegeneration = 2;


	public int Regeneration = 0;

	public int DodgeChance = 0;
	public int MaxDodgeChance = 90;

	public int BlockChance = 10;
	public int MaxBlockChance = 200;
	public int BlockNegation = 30;

	public int Resistance = 0;

	public int Armour = 5;
	public int IncreasedArmour = 0;
	public int MaxArmour = 2000;

	public int DotRessistance = 0;

	public int CritAvoidance = 0;
	public int ReducedCrit = 0;
}
