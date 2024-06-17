using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoQTETrigger1 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public QTESystem1 qteSystem;
    public float delay = 3.0f; // Delay in seconds before starting the QTE

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.started += OnVideoStarted;
        }
        else
        {
            Debug.LogError("VideoPlayer component not found!");
        }
    }

    void OnVideoStarted(VideoPlayer vp)
    {
        Invoke("StartQTE", delay);
    }

    void StartQTE()
    {
        if (qteSystem != null)
        {
            qteSystem.StartQTE();
        }
    }
}
