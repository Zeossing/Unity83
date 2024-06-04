using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    public string nextSceneName;
    public int scoreToAdd;
    public bool resetScore;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (ScoreManager.instance != null)
        {
            if (resetScore)
            {
                ScoreManager.instance.ResetScore();
            }
            else
            {
                ScoreManager.instance.AddScore(scoreToAdd);
            }

            ScoreManager.instance.LoadScene(nextSceneName);
        }
    }
}
