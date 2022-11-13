using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
	[SerializeField] private Wave[] waves;
	private GameManager gameManager;

	private void Start() {
		if (gameManager == null) gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void StartWave(int waveNumber) {
		if(waveNumber >= waves.Length) {
			Console.Error.WriteLine($"Wave nr.{waveNumber} does not exist.");
			return;
		}
		else { 
			waves[waveNumber].StartWave();
		}
	}

	public void InterruptWave(int waveNumber) {
		waves[waveNumber].EndWave();
	}

	public void WaveEnd() {
		gameManager.RoundEnd();
	}

}
