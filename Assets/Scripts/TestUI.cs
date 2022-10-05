using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestUI : MonoBehaviour {

	private VisualElement ve;
	public Player player;

	void Start() {
		UIDocument uiDocument = GetComponent<UIDocument>();
		ve = uiDocument.rootVisualElement;
		ve.Q<Button>("TestButton").clickable.clicked += onButtonClick;
		var tf = ve.Q<TextField>("TestTextField");
		tf.RegisterValueChangedCallback(onTextField);
		Button b = new();
		b.clickable.clicked += updateStats;
		b.text = "update";
		ve.Add(b);
	}

	int damage = 0;

	private void updateStats() {
		player.InitUpdateStats();
		print("Reset Changes");
	}

	private void onButtonClick() {
		player.DealDamage(damage, DamageType.physical);
	}

	private void onTextField(ChangeEvent<string> str) {
		int.TryParse(str.newValue, out damage);
	}
}
