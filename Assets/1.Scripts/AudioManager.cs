using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider BgmSlider;
    public Slider SfxSlider;
    public GameObject mute;

    public void Sfx()
    {
        AudioSource sfxButton1 = GetComponent<AudioSource>();
        sfxButton1.Play();
    }

    public void BGMAudioControl()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);

    }

    public void SFXAudioControl()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);

    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

}
