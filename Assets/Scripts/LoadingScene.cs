using InstantGamesBridge;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private int _secondsBetweenAdvertising = 40;

    private void Start()
    {
        Bridge.Initialize(OnBridgeInitializationCompleted);
    }

    private void OnBridgeInitializationCompleted(bool isInitialized)
    {
        if (isInitialized)
        {
            Bridge.advertisement.SetMinimumDelayBetweenInterstitial(_secondsBetweenAdvertising);

            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Error");
        }
    }
}