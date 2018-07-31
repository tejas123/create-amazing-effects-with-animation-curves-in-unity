using UnityEngine;
using System.Collections;

public class RatingView : BaseView
{
	#region PUBLIC_VARS

	public ScalingEffect[] startEffect;

	#endregion

	#region PRIVATE_VARS

	private int totalNumberOfElements;
	private WaitForSeconds startDelay;
	private WaitForSeconds endDelay;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		totalNumberOfElements = startEffect.Length;
		startDelay = new WaitForSeconds (0.1f);
		endDelay = new WaitForSeconds (1.3f);
	}

	private void OnEnable ()
	{
		StartCoroutine (PlayStartEffect ());
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	#endregion

	#region CO-ROUTINES

	private IEnumerator PlayStartEffect ()
	{
		yield return startDelay;
		for (int i = 0; i < totalNumberOfElements; i++) {
			StartCoroutine (startEffect [i].EntryEffect ());
		}
	}

	private IEnumerator ResetEffects ()
	{
		for (int i = totalNumberOfElements - 1; i >= 0; i--) {
			StartCoroutine (startEffect [i].ExitEffect ());
		} 
		yield return endDelay;
		HideView ();
	}

	#endregion

	#region EVENT_HANDLERS

	#endregion

	#region UI_CALLBACKS

	public void CloseThisPanel ()
	{
		StartCoroutine (ResetEffects ());
	}

	#endregion
}