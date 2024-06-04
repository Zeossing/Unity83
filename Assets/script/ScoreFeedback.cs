using UnityEngine;
using UnityEngine.UI;

public class ScoreFeedback : MonoBehaviour
{
    public int twoStarScoreThreshold;
    public int threeStarScoreThreshold;
    public Image star1;
    public Image star2;
    public Image star3;
    public Text feedbackText;

    void Start()
    {
        DisplayScoreFeedback();
    }

    void DisplayScoreFeedback()
    {
        int score = ScoreManager.instance.score;

        if (score >= threeStarScoreThreshold)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = true;
            feedbackText.text = "สุดยอด!";
        }
        else if (score >= twoStarScoreThreshold)
        {
            star1.enabled = false;
            star2.enabled = true;
            star3.enabled = false;
            feedbackText.text = "พยายามต่อนะ!";
        }
        else
        {
            star1.enabled = true;
            star2.enabled = false;
            star3.enabled = false;
            feedbackText.text = "พยายามอีกหน่อย!";
        }
    }
}
