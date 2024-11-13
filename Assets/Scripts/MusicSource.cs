using UnityEngine;

public class MusicSource : MonoBehaviour
{
    public static MusicSource Instance{ get; private set; }
    private AudioSource source;
    public AudioClip chargingClip;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void StopMusic()
    {
        source.Stop();
    }

    public void PlayMusic()
    {
        source.Play();
	}

    public void UseChargingClip()
    {
        source.clip = chargingClip;
	}


}
