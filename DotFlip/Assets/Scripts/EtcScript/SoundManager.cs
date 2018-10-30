using UnityEngine;
using System.Collections;

[System.Serializable]
public class EffectSound
{
    public AudioClip clip;
    public float volume;
}

public class SoundManager : MonoBehaviour
{
    public EffectSound[] effect_;

    public static SoundManager instance
    {
        get;
        private set;
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }

    void setVolume(float volume)
    {
        gameObject.GetComponent<AudioSource>().volume = gameObject.GetComponent<AudioSource>().volume * volume;
    }

    public void setClip(AudioClip clip, float volume)
    {
        setVolume(volume);
        gameObject.GetComponent<AudioSource>().clip = clip;
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
