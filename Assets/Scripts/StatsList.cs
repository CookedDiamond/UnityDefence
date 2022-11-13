using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class StatsList : MonoBehaviour {

	ListView listView;
	Player player;

	private string[] lableTexts;

	private void Start() {
		var visualElement = GetComponent<UIDocument>().rootVisualElement.Q("Right");
		listView = visualElement.Q<ListView>("StatsList");
		listView.makeItem = MakeItem;
		listView.bindItem = BindItem;
		listView.itemsSource = lableTexts;
	}

	private VisualElement MakeItem() {
		var label = new Label();
		label.AddToClassList("list-element");
		label.focusable = false;
		return label;
	}

	private void BindItem(VisualElement e, int index) {
		var lable = (Label)e;
		lable.text = lableTexts[index];
	}
	public void UpdateList(FinalStats finalStats) {
		listView.Clear();
		List<string> texts = new List<string>();
		var all = finalStats.GetType().GetProperties();
		foreach (var prop in all) {
			print(" Name:" + prop.Name + " Value:" + prop.GetValue(finalStats));
			texts.Add(prop.Name + " " + prop.GetValue(finalStats));
		}
		lableTexts = texts.ToArray();
	}

}
