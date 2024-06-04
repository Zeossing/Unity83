using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger4 : MonoBehaviour
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
        if (ScoreManager4.instance != null) // แก้จาก ScoreManager3 เป็น ScoreManager4
        {
            ScoreManager4.instance.AddScore(scoreToAdd); // แก้จาก ScoreManager3 เป็น ScoreManager4
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
