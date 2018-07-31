using UnityEngine;
using System.Collections;

public class SettingView : BaseView
{
	#region PUBLIC_VARS

	public  FadingColorEffect fadingEffect;
	public  SinkEffect sinkEffect;
	public  SlidingEffect[] slidingEffects;

	#endregion

	#region PRIVATE_VARS

	private WaitForSeconds startDelay;
	private int totalElements;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		startDelay = new WaitForSeconds (0.25f);
		totalElements = slidingEffects.Length;
	}

	private void OnEnable ()
	{
		StartCoroutine (PlayStartingEffects ());
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	#endregion

	#region CO-ROUTINES

	private IEnumerator PlayStartingEffects ()
	{
		StartCoroutine (fadingEffect.ChangeColor ());
		StartCoroutine (sinkEffect.OpeningAction ());
		yield return startDelay;
		for (int i = 0; i < totalElements; i++) {
			StartCoroutine (slidingEffects [i].EntryEffect ());
		}
	}

	private IEnumerator PlayEndEffects ()
	{
		for (int i = 0; i < totalElements; i++) {
			StartCoroutine (slidingEffects [i].ExitEffect ());
		}
		yield return startDelay;
		StartCoroutine (fadingEffect.SetInitialColor ());
		StartCoroutine (sinkEffect.ClosingAction ());

	}

	#endregion

	#region EVENT_HANDLERS

	#endregion

	#region UI_CALLBACKS

	public void ExitThisMenu ()
	{
		StartCoroutine (PlayEndEffects ());
	}

	#endregion
}