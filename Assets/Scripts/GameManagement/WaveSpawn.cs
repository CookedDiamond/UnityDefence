using UnityEngine;

[CreateAssetMenu(fileName = "WaveSpawns", menuName = "ScriptableObjects/WaveSpawns", order = 2)]
public class WaveSpawn : ScriptableObject {

	public float timeStamp = 0f;
	public Spawner spawner = null;
	public Vector2 position = Vector2.zero;
}