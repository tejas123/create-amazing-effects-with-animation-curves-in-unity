using UnityEngine;
using System.Collections;

public class ScalingEffect : MonoBehaviour
{
	#region PUBLIC_VARS

	[HeaderAttribute ("Animation Curve")]
	public AnimationCurve scalingCurve;
	public float scaleMultiplier;
	public float startDelay;
	public float endDelay;

	#endregion

	#region PRIVATE_VARS

	private Vector3 initialScale;
	private Vector3 finalScale;

	private float time = 0.25f;

	private WaitForSeconds startingDelay;
	private WaitForSeconds endingDelay;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		initialScale = Vector3.zero;
		finalScale = Vector3.one * scaleMultiplier;

		transform.localScale = initialScale;

		startingDelay = new WaitForSeconds (startDelay);
		endingDelay = new WaitForSeconds (endDelay);
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	#endregion

	#region CO-ROUTINES

	public IEnumerator EntryEffect ()
	{
		float i = 0;
		float rate = 1 / time;

		yield return startingDelay;

		while (i < 1) {
			i += rate * Time.deltaTime;
			transform.localScale = Vector3.Lerp (initialScale, finalScale, scalingCurve.Evaluate (i));
			yield return 0;
		}
	}

	public IEnumerator ExitEffect ()
	{
		float i = 0;
		float rate = 1 / time;

		yield return endingDelay;

		while (i < 1) {
			i += rate * Time.deltaTime;
			transform.localScale = Vector3.Lerp (finalScale, initialScale, i);
			yield return 0;
		}
	}

	#endregion

	#region EVENT_HANDLERS

	#endregion

	#region UI_CALLBACKS

	#endregion
}