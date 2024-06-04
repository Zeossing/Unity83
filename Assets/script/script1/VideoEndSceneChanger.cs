using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger : MonoBehaviour
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
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreToAdd);
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
