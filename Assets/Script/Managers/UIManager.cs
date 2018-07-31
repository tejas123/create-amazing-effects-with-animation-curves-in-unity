using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
 {
	#region PUBLIC_VARS

	public static UIManager Instance;

	public HomeView homeView;
	public SettingView settingView;
	public GamePlayView gamePlayView;
	public RatingView rateUsView;
	public ShareView shareView;
	public LevelView levelView;
	public GameOverView gameOverView;

    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
   
	void Awake()
	{
		Instance = this;
	}

	#endregion

    #region PUBLIC_FUNCTIONS
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion

    #region CO-ROUTINES
    #endregion

    #region EVENT_HANDLERS
    #endregion

	#region UI_CALLBACKS
	#endregion
}