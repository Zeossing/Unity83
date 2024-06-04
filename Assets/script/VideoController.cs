using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // อ้างถึง VideoPlayer ของคุณ
    public GameObject objectToShow; // อ้างถึง GameObject ที่จะทำให้แสดง

    void Start()
    {
        // ซ่อน GameObject ในตอนแรก
        objectToShow.SetActive(false);

        // สมัครฟังก์ชัน callback เมื่อวิดีโอจบ
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // แสดง GameObject เมื่อวิดีโอจบ
        objectToShow.SetActive(true);
    }

}
