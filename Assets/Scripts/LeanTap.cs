using UnityEngine;

namespace Lean.Touch
{
	// This script will spawn a prefab when you tap the screen
	public class LeanTap : MonoBehaviour
	{
		protected virtual void OnEnable()
		{
			// Hook into the events we need
			LeanTouch.OnFingerTap += OnFingerTap;
		}

		protected virtual void OnDisable()
		{
			// Unhook the events
			LeanTouch.OnFingerTap -= OnFingerTap;
		}

		private void OnFingerTap(LeanFinger finger)
		{
			Debug.Log ("flip dat shit");
		}
	}
}