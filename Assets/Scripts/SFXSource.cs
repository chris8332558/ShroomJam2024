using UnityEngine;

public class SFXSource : MonoBehaviour
{
    public static SFXSource Instance{ get; private set; }

    [SerializeField] AudioClip switchOnClip;
    [SerializeField] AudioClip switchOffClip;
    [SerializeField] AudioClip errorClip;
    [SerializeField] AudioClip scoreClip;
    [SerializeField] AudioClip countingScoreClip;

    private AudioSource source;

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

    public void PlaySwitchOn()
    {
        source.PlayOneShot(switchOnClip);
	}

    public void PlaySwitchOff()
    {
        source.PlayOneShot(switchOffClip);
	}

    public void PlayErrorClip()
    {
        source.PlayOneShot(errorClip);
	}

    public void PlayScoreClip()
    {
        source.PlayOneShot(scoreClip);
    }

    public void PlayCountingClip()
    {
        source.PlayOneShot(countingScoreClip);
	}

    public void SetLoop(bool isLoop)
    {
        source.loop = isLoop;
	}
}
