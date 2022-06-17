using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] 
    private AudioClip[] melodies;

    private AudioSource audioGame;
    private AudioSource audioPlayer;

    private bool isPause;

    private void Awake()
    {
        if (FindObjectsOfType<SoundsManager>().Length > 1)
        {
            gameObject.SetActive(false);
            this.enabled = false;
            return;
        }

        foreach (var source in GetComponents<AudioSource>())
        {
            if (source.clip == null)
            {
                audioGame = source;
            }
            else
            { 
                audioPlayer = source;
            }
        }
        DontDestroyOnLoad(gameObject);
        InvokeRepeating(nameof(PlayMelodies),1f,1f);
    }
    public void PlayMelodies()
    {
        if (isPause) return;
        
        if (!audioGame.isPlaying)
        {
            audioGame.PlayOneShot(melodies[Random.Range(0, melodies.Length)]);
        }
    }
    public void PlayDestroyTree()
    {
        audioPlayer.PlayOneShot(audioPlayer.clip);
    }

    public void ChangeStateMusic(bool isPlay)
    {
        if (audioGame == null)
        {
            SoundsManager sounds = FindObjectOfType<SoundsManager>();
            ControlState(isPlay,ref sounds.isPause,sounds.audioGame);
        }
        else if(gameObject.activeInHierarchy)
        {
            ControlState(isPlay,ref isPause,audioGame);
        }
    }

    public void ControlState(bool isPlay,ref bool isPause,AudioSource audioSource)
    {
        if (!isPlay)
        {
            isPause = true;
            audioSource.Pause();
        }
        else
        {
            isPause = false;
            audioSource.UnPause();
        }
    }

    public void GetCurrentValueVolume(Slider setTo)
    {
        float newValue = 0f;
        audioGame.outputAudioMixerGroup.audioMixer.GetFloat("Volume",out newValue);
        setTo.value = newValue;
    }
}
