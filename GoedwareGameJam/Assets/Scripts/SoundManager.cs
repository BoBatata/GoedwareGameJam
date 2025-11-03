using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    private void Awake()
    {
        _audioSource =  GetComponent<AudioSource>();
    }

    public void PlaySound(int clipIndex)
    {
        _audioSource.clip = _audioClips[clipIndex];
        _audioSource.Play();
    }

    public void StopSound()
    {
        _audioSource.Stop();
    }
}
