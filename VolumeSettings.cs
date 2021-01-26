using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10 (volume) * 20);
    }
}
