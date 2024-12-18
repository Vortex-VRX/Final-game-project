using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton to ensure only one instance exists
    public AudioSource backgroundMusic; // Reference to the Audio Source
    public Slider volumeSlider; // Reference to the Slider UI

    private void Awake()
    {
        // Ensure only one AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate AudioManagers
        }
    }

    private void Start()
    {
        // Load saved volume or set default
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = savedVolume;
        }

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;
            PlayerPrefs.SetFloat("MusicVolume", volume); // Save the volume setting
        }
    }
}
