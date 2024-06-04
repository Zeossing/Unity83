using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // อ้างถึง VideoPlayer ของคุณ
    public GameObject objectToShow; // อ้างถึง GameObject ที่จะทำให้แสดง
    public AudioSource audioSource; // อ้างถึง AudioSource สำหรับเล่นเสียงเพลง
    public AudioClip musicClip; // อ้างถึง AudioClip เพื่อให้ AudioSource เล่น

    void Start()
    {
        // ซ่อน GameObject ในตอนแรก
        objectToShow.SetActive(false);

        // สมัครฟังก์ชัน callback เมื่อวิดีโอจบ
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // เล่นเสียงเพลง
        audioSource.clip = musicClip;
        audioSource.Play();

        // แสดง GameObject เมื่อวิดีโอจบ
        objectToShow.SetActive(true);
    }

}
