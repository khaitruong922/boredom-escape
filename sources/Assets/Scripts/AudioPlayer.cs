using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public void PlayAudio()
    {
        audioSource.Play();
    }
    
}
