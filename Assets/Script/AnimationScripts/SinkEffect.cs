using UnityEngine;
using System.Collections;

public class SinkEffect : MonoBehaviour
{
	#region PUBLIC_VARS

	[Header ("Animation Curve")]
	public AnimationCurve scaleCurve;


	public float scaleFactor;

	#endregion

	#region PRIVATE_VARS

	private Vector3 initialScale;
	private Vector3 finalScale;
	private float time = 0.25f;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{ 
		finalScale = Vector3.one;
		initialScale = finalScale * scaleFactor;
		transform.localScale = initialScale;
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	#endregion

	#region CO-ROUTINES

	public IEnumerator OpeningAction ()
	{

		float i = 0;
		float rate = 1 / time;

		while (i < 1) {
			i += rate * Time.deltaTime;
			transform.localScale = Vector3.Lerp (initialScale, finalScale, scaleCurve.Evaluate (i));
			yield return null;
		}
	}

	public IEnumerator ClosingAction ()
	{

		float i = 0;
		float rate = 1 / time;

		while (i < 1) {
			i += rate * Time.deltaTime;
			transform.localScale = Vector3.Lerp (finalScale, initialScale, scaleCurve.Evaluate (i));
			yield return null;
		}
		gameObject.SetActive (false);
	}

	#endregion

	#region EVENT_HANDLERS

	#endregion

	#region UI_CALLBACKS

	#endregion

}