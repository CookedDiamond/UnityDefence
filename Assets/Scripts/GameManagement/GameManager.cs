using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private GameState currentGameState;
	[SerializeField] private Player player;
	[SerializeField] private WaveManager waveManager;
	[SerializeField] private int currentWave = 0;

	void Start() {
		print("Set target Frame Rate to 165.");
		Application.targetFrameRate = 165;

		if (player == null) player = GameObject.Find("Player").GetComponent<Player>();
		LoadRound();
	}

	public void LoadRound() {
		if (currentGameState != GameState.Lobby) return;
		waveManager.StartWave(currentWave);
		currentGameState = GameState.InRound;
	}

	public void PlayerDied() {
		waveManager.InterruptWave(currentWave);
		RoundEnd();
	}

	public void RoundEnd() {
		currentGameState = GameState.Lobby;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.P)) LoadRound();
	}
}

public enum GameState {
	Lobby,
	LoadRound,
	InRound,
	LoadLobby
}
