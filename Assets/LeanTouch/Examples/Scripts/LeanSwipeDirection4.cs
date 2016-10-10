using UnityEngine;
using UnityEngine.UI;

namespace Lean.Touch
{
	// This script will tell you which direction you swiped in
	public class LeanSwipeDirection4 : MonoBehaviour
	{
	
		protected virtual void OnEnable()
		{
			// Hook into the events we need
			LeanTouch.OnFingerSwipe += OnFingerSwipe;
		}
	
		protected virtual void OnDisable()
		{
			// Unhook the events
			LeanTouch.OnFingerSwipe -= OnFingerSwipe;
		}
	
		public void OnFingerSwipe(LeanFinger finger)
		{
			// Store the swipe delta in a temp variable
			var swipe = finger.SwipeDelta;
		
			if (swipe.x < -Mathf.Abs(swipe.y))
			{
				SiteManager.SwipeLeft ();
			}
		
			if (swipe.x > Mathf.Abs(swipe.y))
			{
				SiteManager.SwipeRight ();
			}
		
			if (swipe.y < -Mathf.Abs(swipe.x))
			{
				SiteManager.SwipeDown ();
			}
		
			if (swipe.y > Mathf.Abs(swipe.x))
			{
				SiteManager.SwipeUp ();
			}
		}
	}
}