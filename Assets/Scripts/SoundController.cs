using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class SoundController : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField] private AudioClip _crashSFX;
    [SerializeField] private AudioClip _winSFX;
    [SerializeField] private AudioClip _engineSFX;
    private double _startTime;
    private double _soundDuration;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCrashSFX()
    {
        Debug.Log("SHOULD PLAY CRASH SOUND BUT IT DOESN'T FOR SOME REASON");
        _audioSource.clip = _crashSFX;
        _audioSource.PlayOneShot(_crashSFX, 0.8f);
    }
    public void PlayWinSFX()
    {
        _audioSource.clip = _winSFX;
        _audioSource.Play();
    }

    public void ToggleAudio(bool shouldEmit)
    {
        _audioSource.clip = _engineSFX;
        if (shouldEmit && !_audioSource.isPlaying)
        {
            _startTime = AudioSettings.dspTime;
            _audioSource.PlayScheduled(_startTime);

            _soundDuration = _audioSource.clip.samples / _audioSource.clip.frequency;

            if (AudioSettings.dspTime < _soundDuration)
            {
                _audioSource.timeSamples = _audioSource.clip.samples / 2;
                _audioSource.PlayScheduled(_startTime);
            }
        }
        else
        {
            _audioSource.Stop();
        }

    }

}
