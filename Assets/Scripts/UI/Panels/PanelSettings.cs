using UnityEngine;
using UnityEngine.UI;

public class PanelSettings : MonoBehaviour
{
    [SerializeField] private Image _buttonSoundImage;
    [SerializeField] private Sprite _spriteSoundOn;
    [SerializeField] private Sprite _spriteSoundOff;
    [SerializeField] private AudioSource _buttonClickSound;

    private bool _isSoundOn = false;

    public void OnSoundButtonClick()
    {
        _buttonClickSound.Play();

        if (_isSoundOn == false)
        {
            AudioListener.volume = 1f;
            _buttonSoundImage.sprite = _spriteSoundOn;
            _isSoundOn = true;
        }
        else
        {
            AudioListener.volume = 0f;
            _buttonSoundImage.sprite = _spriteSoundOff;
            _isSoundOn = false;
        }
    }
}
