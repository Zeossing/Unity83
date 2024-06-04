using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager4 : MonoBehaviour
{
    public static ScoreManager4 instance;
    public int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Load score from PlayerPrefs
        LoadScore();
    }

    public void AddScore(int value)
    {
        score += value;
        SaveScore();
    }

    public void ResetScore()
    {
        score = 0;
        SaveScore();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", score);
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            score = PlayerPrefs.GetInt("PlayerScore");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
