using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bgmVolumeSlider;
    public Text bgmVolumeText;
    public Slider sfxVolumeSlider;
    public Text sfxVolumeText;

    void Start()
    {
        // ตั้งค่าเริ่มต้นของ BGM Slider
        float bgmVolume;
        if (audioMixer.GetFloat("SoundBG", out bgmVolume))
        {
            bgmVolumeSlider.value = Mathf.Pow(10, bgmVolume / 20);
        }
        else
        {
            bgmVolumeSlider.value = 0.5f; // กำหนดค่าเริ่มต้นให้ Slider
        }
        UpdateVolumeText(bgmVolumeSlider.value, bgmVolumeText);
        
        // ตั้งค่าให้ BGM Slider เรียกฟังก์ชันเมื่อค่าเปลี่ยน
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);

        // ตั้งค่าเริ่มต้นของ SFX Slider
        float sfxVolume;
        if (audioMixer.GetFloat("SFXVolume", out sfxVolume))
        {
            sfxVolumeSlider.value = Mathf.Pow(10, sfxVolume / 20);
        }
        else
        {
            sfxVolumeSlider.value = 0.5f; // กำหนดค่าเริ่มต้นให้ Slider
        }
        UpdateVolumeText(sfxVolumeSlider.value, sfxVolumeText);
        
        // ตั้งค่าให้ SFX Slider เรียกฟังก์ชันเมื่อค่าเปลี่ยน
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetBGMVolume(float value)
    {
        // แปลงค่า Slider เป็นค่า dB
        float dB;
        if (value > 0.001f) {
            dB = Mathf.Log10(value) * 20;
        } else {
            dB = -80f; // หรือค่าที่ต้องการ
        }
        audioMixer.SetFloat("SoundBG", dB);
        UpdateVolumeText(value, bgmVolumeText);
    }

    void SetSFXVolume(float value)
    {
        // แปลงค่า Slider เป็นค่า dB
        float dB;
        if (value > 0.001f) {
            dB = Mathf.Log10(value) * 20;
        } else {
            dB = -80f; // หรือค่าที่ต้องการ
        }
        audioMixer.SetFloat("SFXVolume", dB);
        UpdateVolumeText(value, sfxVolumeText);
    }

    void UpdateVolumeText(float value, Text volumeText)
    {
        volumeText.text = (value * 100).ToString("F0");
    }
}
