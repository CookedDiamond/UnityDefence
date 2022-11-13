using MyBox;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealthBar : MonoBehaviour, IProgressBar {

	protected float value;
	protected float maxValue;

	[SerializeField] protected bool healthAnimation;
	[ConditionalField("healthAnimation"), SerializeField] float slowSpeed = 2f;
	[SerializeField] protected Image healthBar;

	public void SetValues(float _value, float _maxValue) {
		value = Mathf.Clamp(_value, 0, _maxValue);
		maxValue = _maxValue;
	}

	public void UpdateBar() {
		if (healthAnimation) healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, (value / maxValue), (slowSpeed * Time.deltaTime));
		else healthBar.fillAmount = value / maxValue;
	}

	public void SetColor(Color color) {
		healthBar.color = color;
	}
}

