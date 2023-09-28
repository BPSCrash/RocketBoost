using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class SoundController : MonoBehaviour
{
    AudioSource _audioSource;
    private double _startTime;
    private double _soundDuration;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ToggleAudio(bool shouldEmit)
    {
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
