using UnityEngine;


public class Music : MonoBehaviour
{

    public AudioSource introAudioSource, musicAudioSource;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (introAudioSource.isPlaying || musicAudioSource.isPlaying)
        {
            return;
        }


        musicAudioSource.Play();
        introAudioSource.Stop();
    }
}
