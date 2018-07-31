using UnityEngine;
using System.Collections;

public class GamePlayView : BaseView
{
	#region PUBLIC_VARS

	public  FadingColorEffect fadingEffect;
	public  ScalingEffect scalingEffect;
	public GameOverView gameOverView;

	#endregion

	#region PRIVATE_VARS

	private WaitForSeconds startDelay;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		startDelay = new WaitForSeconds (0.5f);
	}

	private void OnEnable ()
	{
		PlayStartingEffects ();
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	private void PlayStartingEffects ()
	{
		StartCoroutine (fadingEffect.ChangeColor ());
		StartCoroutine (scalingEffect.EntryEffect ());
	}

	#endregion

	#region CO-ROUTINES

	private IEnumerator PlayEndEffects ()
	{
		StartCoroutine (fadingEffect.SetInitialColor ());
		StartCoroutine (scalingEffect.ExitEffect ());
		UIManager.Instance.gameOverView.ShowView ();
		yield return startDelay;
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