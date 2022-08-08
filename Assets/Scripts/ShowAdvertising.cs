using InstantGamesBridge;
using UnityEngine;

public class ShowAdvertising : MonoBehaviour
{
	private bool ignoreDelay = false;

	public void ShowingAdvertising()
	{
		Bridge.advertisement.ShowInterstitial(
				ignoreDelay,
				success => {
					if (success)
					{
						Debug.Log("SHOWING ADVERTISING");
					}
					else
					{
						Debug.Log("Error Advertising");

					}
				});
	}
}