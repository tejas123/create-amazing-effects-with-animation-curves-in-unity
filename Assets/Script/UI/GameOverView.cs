using UnityEngine;
using System.Collections;

public class GameOverView : BaseView
{
	#region PUBLIC_VARS

	public ScalingEffect mainPanelScalingEffect;
	public  ScalingEffect[] buttonScalingEffects;

	#endregion

	#region PRIVATE_VARS

	private WaitForSeconds startDelay;
	private int totalElements;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		startDelay = new WaitForSeconds (.5f);
		totalElements = buttonScalingEffects.Length;
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
		yield return startDelay;

		StartCoroutine (mainPanelScalingEffect.EntryEffect ());
		for (int i = 0; i < totalElements; i++) {
			StartCoroutine (buttonScalingEffects [i].EntryEffect ());
		}
	}

	private IEnumerator PlayEndEffects ()
	{
		for (int i = 0; i < totalElements; i++) {
			StartCoroutine (buttonScalingEffects [i].ExitEffect ());
		}
		StartCoroutine (mainPanelScalingEffect.ExitEffect ());

		yield return startDelay;

		UIManager.Instance.homeView.ShowView ();
		HideView ();
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