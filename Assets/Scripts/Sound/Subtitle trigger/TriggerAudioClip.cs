using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioClip : MonoBehaviour
{
    public AudioObject clipToPlay;
    public float duration;
    public bool readyToPlay; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Sound.instance.Play(clipToPlay, duration);
    }
}
