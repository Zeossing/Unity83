using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VideoEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer; // อ้างถึง VideoPlayer ของคุณ

    void Start()
    {
        // สมัครฟังก์ชัน callback เมื่อวิดีโอจบ
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // โหลดฉากใหม่เมื่อวิดีโอจบ
        SceneManager.LoadSceneAsync("Total");
    }
}
