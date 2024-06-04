using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger1 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;
    public int scoreToAdd;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("VideoPlayer component not found!");
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (ScoreManager1.instance != null) // แก้จาก ScoreManager เป็น ScoreManager1
        {
            ScoreManager1.instance.AddScore(scoreToAdd); // แก้จาก ScoreManager เป็น ScoreManager1
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
