using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance = null;

    [SerializeField] AudioSource _BackTrack = null;
    [SerializeField] AudioSource _CorrectAudio = null;
    [SerializeField] AudioSource _WrongAudio = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(instance);
        }
    }
    private void Start()
    {
        _BackTrack.Play();
    }

    public void PlayCorrectAudio()
    {
        _CorrectAudio.Play();
    }
    public void PlayWrongAudio()
    {
        _WrongAudio.Play();
    }
    public void PlayBackTrack()
    {
        _BackTrack.Play();
    }
    public void StopCorrectAudio()
    {
        _CorrectAudio.Stop();
    }
    public void StopWrongAudio()
    {
        _WrongAudio.Stop();
    }
    public void StopBackTrack()
    {
        _BackTrack.Stop();
    }
}
