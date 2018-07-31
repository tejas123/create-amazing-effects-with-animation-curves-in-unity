using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadingColorEffect : MonoBehaviour
{
	#region PUBLIC_VARS

	[Header ("Animation-Curve")]
	public AnimationCurve colorCurve;
	public Image newImage;
	public float startDelay;

	#endregion

	#region PRIVATE_VARS

	private Color initialColor;
	private Color finalColor;
	private WaitForSeconds delay;
	private float time = 0.25f;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		finalColor = newImage.color;
		initialColor = Color.black;
		initialColor.a = 0;

		newImage.color = initialColor;

		delay = new WaitForSeconds (startDelay);
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	#endregion

	#region CO-ROUTINES

	public IEnumerator ChangeColor ()
	{
		float i = 0;
		float rate = 1 / time;

		yield return delay;

		while (i < 1) {
			i += rate * Time.deltaTime;
			newImage.color = Color.Lerp (initialColor, finalColor, colorCurve.Evaluate (i));
			yield return 0;
		}
		newImage.color = finalColor;
	}

	public IEnumerator SetInitialColor ()
	{
		float i = 0;
		float rate = 1 / time;

		yield return delay;

		while (i < 1) {
			i += rate * Time.deltaTime;
			newImage.color = Color.Lerp (finalColor, initialColor, colorCurve.Evaluate (i));
			yield return 0;
		}
		newImage.color = initialColor;
	}

	#endregion

	#region EVENT_HANDLERS

	#endregion

	#region UI_CALLBACKS

	#endregion
}