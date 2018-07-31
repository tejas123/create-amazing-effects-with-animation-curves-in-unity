using UnityEngine;
using System.Collections;

public class SlidingEffect : MonoBehaviour
{
	#region PUBLIC_VARS

	[Header ("Animation-Curve")]
	public AnimationCurve slideCurve;
	public Vector3 finalPosition;
	public float startDelay;
	public float exitDelay;

	#endregion

	#region PRIVATE_VARS

	private Vector3 initialPosition;
	private WaitForSeconds startingDelay;
	private WaitForSeconds endingDelay;
	private float time = 0.275f;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		startingDelay = new WaitForSeconds (startDelay);
		endingDelay = new WaitForSeconds (exitDelay);
		initialPosition = transform.localPosition;
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	#endregion

	#region CO-ROUTINESprivate

	public IEnumerator EntryEffect ()
	{
		float i = 0;
		float rate = 1 / time;

		yield return startingDelay;

		while (i < 1) {
			i += rate * Time.deltaTime;
			transform.localPosition = Vector3.Lerp (initialPosition, finalPosition, slideCurve.Evaluate (i));
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
			transform.localPosition = Vector3.Lerp (finalPosition, initialPosition, slideCurve.Evaluate (i));
			yield return 0;
		}
	}

	#endregion

	#region EVENT_HANDLERS

	#endregion

	#region UI_CALLBACKS

	#endregion
}