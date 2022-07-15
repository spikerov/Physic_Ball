using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

public class ManagerPanels : MonoBehaviour
{
    [SerializeField] private PanelMainMenu _panelMainMenu;
    [SerializeField] private PanelSettings _panelSettings;
    [SerializeField] private PanelPause _panelPause;
    [SerializeField] private PanelPlay _panelPlay;
    [SerializeField] private PanelGameOver _panelGameOver;
    [SerializeField] private ShapesMover _shapesMover;
    [SerializeField] private AudioSource _buttonClockSound;
    [SerializeField] private PlaceChoiceDirection _placeChoiceDirection;
    [SerializeField] private Ball _ball;

    public void OnButtonClickPauseMenu()
    {
        _buttonClockSound.Play();
        Time.timeScale = 0;
        _panelPause.gameObject.SetActive(true);
        _placeChoiceDirection.gameObject.SetActive(false);
    }

    public void OnButtonClickContinue()
    {
        _buttonClockSound.Play();
        _panelPause.gameObject.SetActive(false);
        Time.timeScale = 1;
        _placeChoiceDirection.gameObject.SetActive(true);
    }

    public void OnButtonClickPlay()
    {
        _buttonClockSound.Play();
        DOTween.KillAll();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnButtonClickSettings()
    {
        _buttonClockSound.Play();
        _panelMainMenu.gameObject.SetActive(false);
        _panelSettings.gameObject.SetActive(true);
    }

    public void OnButtonClickQuit()
    {
        _buttonClockSound.Play();
        Application.Quit();
    }

    public void OnButtonClickMainMenu()
    {
        _buttonClockSound.Play();
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }

    public void OpenGameOverPanel()
    {
        _placeChoiceDirection.gameObject.SetActive(false);
        _panelGameOver.gameObject.SetActive(true);
    }
}
