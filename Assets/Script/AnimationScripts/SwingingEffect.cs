using UnityEngine;
using System.Collections;

public class SwingingEffect : MonoBehaviour
 {
	#region PUBLIC_VARS

	[HeaderAttribute ("Animation Curve")]
	public AnimationCurve animationCurve;

	public float speed;

	#endregion

	#region PRIVATE_VARS

	private Vector3 initialRotation;
	private Vector3 finalRotation;
	private float graphValue;


	#endregion

	#region UNITY_CALLBACKS

	private void Awake()
	{
		initialRotation = transform.localEulerAngles;
		finalRotation = Vector3.one;
		animationCurve.postWrapMode = WrapMode.Loop;
	}

	private void Update()
	{
		graphValue = animationCurve.Evaluate (Time.time);
		initialRotation.z = finalRotation.z * graphValue *speed;
		transform.localEulerAngles = initialRotation;
	}
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