using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip mainAudio;
    [SerializeField] AudioClip intenseAudio;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMainAudio()
    {
        PlayAudio(mainAudio);
    }

    public void PlayIntenseAudio()
    {
        PlayAudio(intenseAudio);
    }

    void PlayAudio(AudioClip audioClip)
    {
        audioSource.Pause();
        float timestamp = audioSource.time;
        audioSource.clip = audioClip;
        audioSource.time = timestamp;
        audioSource.Play();
    }
}