using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource source;

    public static Sound instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Play(AudioObject clip, float duration)
    {
        if(source.isPlaying)
        {
            source.Stop();

        }

        source.PlayOneShot(clip.clip);

        SubtitleUI.instance.SetSubtitle(clip.subtitle, duration);
    }
}
