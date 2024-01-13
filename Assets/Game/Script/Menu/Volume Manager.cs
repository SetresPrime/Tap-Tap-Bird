using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mute;
    [SerializeField]
    private GameObject _volume;

    [SerializeField]
    private Slider _volumeSlider;

    [Header("Audio Clip")]
    [SerializeField]
    private AudioClip _soundClick;
    [SerializeField]
    private AudioClip _soundSwing;


    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        VolumeSetting(PlayerPrefs.GetFloat("volume"));

        _volumeSlider.value = PlayerPrefs.GetFloat("volume");
        _volumeSlider.gameObject.SetActive(false);
    }
    public void SwichSliderVisble()
    {
        if (_volumeSlider.gameObject.activeSelf)
        {
            _volumeSlider.gameObject.SetActive(false);
        }
        else
        {
            _volumeSlider.gameObject.SetActive(true);
        }        
    }
    public void VolumeSetting(float value)
    {
        _audioSource.volume = value;

        IconSwich(value);

        PlayerPrefs.SetFloat("volume", value);
    }

    #region Sounds
    public void ClickSound()
    {
        _audioSource.Stop(); 
        _audioSource.PlayOneShot(_soundClick);
    }
    public void SwingSound()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_soundSwing);
    }
    #endregion

    void IconSwich(float value)
    {
        if (value == 0)
        {
            _volume.SetActive(false);
            _mute.SetActive(true);
        }
        else
        {
            _volume.SetActive(true);
            _mute.SetActive(false);
        }
    }
}
