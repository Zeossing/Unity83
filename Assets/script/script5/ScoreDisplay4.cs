using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay4 : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component

    void Update()
    {
        // Check if the ScoreManager4 instance is available
        if (ScoreManager4.instance != null)
        {
            // Update the text with the current score
            scoreText.text = "Score: " + ScoreManager4.instance.score.ToString();
        }
    }
}
