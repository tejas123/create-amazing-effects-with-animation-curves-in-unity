using UnityEngine;
using System.Collections;

public class HomeView : BaseView
{
	#region PUBLIC_VARS

	public SlidingEffect[] startingEffect;
	public ScalingEffect scaleEffect;

	#endregion

	#region PRIVATE_VARS

	private WaitForSeconds startDelay;
	private WaitForSeconds disableDelay;

	#endregion

	#region UNITY_CALLBACKS

	private void Awake ()
	{
		startDelay = new WaitForSeconds (0.15f);
		disableDelay = new WaitForSeconds (0.6f);
	}

	private void OnEnable ()
	{
		StartCoroutine (PlayPostBattleEffects ());
	}

	#endregion

	#region PUBLIC_FUNCTIONS

	#endregion

	#region PRIVATE_FUNCTIONS

	private void PlayStartEffects ()
	{
		StartCoroutine (scaleEffect.EntryEffect ());
		for (int i = 0; i < startingEffect.Length; i++) {
			StartCoroutine (startingEffect [i].EntryEffect ());
		}
	}

	private void PlayEndEffect ()
	{
		StartCoroutine (scaleEffect.ExitEffect ());
		for (int i = 0; i < startingEffect.Length; i++) {
			StartCoroutine (startingEffect [i].ExitEffect ());
		}
	}

	#endregion

	#region CO-ROUTINES

	private IEnumerator PlayPostBattleEffects ()
	{
		yield return startDelay;
		PlayStartEffects ();
	}

	private IEnumerator PlayPreBattleEffects ()
	{
		PlayEndEffect ();
		yield return disableDelay;
		UIManager.Instance.gamePlayView.ShowView ();
		HideView ();

	}

	#endregion

	#region EVENT_HANDLERS

	#endregion

	#region UI_CALLBACKS

	public void OpenSettings ()
	{
		UIManager.Instance.settingView.ShowView ();
	}

	public void OpenLevelView ()
	{
		UIManager.Instance.levelView.ShowView ();
	}

	public void OpenShareView ()
	{
		UIManager.Instance.shareView.ShowView ();
	}

	public void StartBattle ()
	{
		StartCoroutine (PlayPreBattleEffects ());
	}

	public void OpenRateUsPanel ()
	{
		UIManager.Instance.rateUsView.ShowView ();
	}

	#endregion
}