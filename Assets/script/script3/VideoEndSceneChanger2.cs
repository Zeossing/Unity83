using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger2 : MonoBehaviour
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
        if (ScoreManager2.instance != null) // แก้จาก ScoreManager เป็น ScoreManager2
        {
            ScoreManager2.instance.AddScore(scoreToAdd); // แก้จาก ScoreManager เป็น ScoreManager2
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
