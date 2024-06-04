using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneChanger3 : MonoBehaviour
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
        if (ScoreManager3.instance != null) // แก้จาก ScoreManager2 เป็น ScoreManager3
        {
            ScoreManager3.instance.AddScore(scoreToAdd); // แก้จาก ScoreManager2 เป็น ScoreManager3
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
