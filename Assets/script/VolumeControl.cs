using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public VideoPlayer videoPlayer;
    private AudioSource audioSource;

    void Start()
    {
        // ตั้งค่า AudioSource
        audioSource = videoPlayer.GetTargetAudioSource(0);
        // ตั้งค่า Slider ให้มีการเรียกฟังก์ชันเมื่อค่าเปลี่ยน
        volumeSlider.onValueChanged.AddListener(SetVolume);
        // ตั้งค่าเริ่มต้นของเสียง
        volumeSlider.value = audioSource.volume;
    }

    void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
