using UnityEngine;

public interface IProgressBar {

	public void UpdateBar();

	public void SetValues(float value, float maxValue);

	public void SetColor(Color color);

}

