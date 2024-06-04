using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay3 : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component

    void Update()
    {
        // Check if the ScoreManager3 instance is available
        if (ScoreManager3.instance != null)
        {
            // Update the text with the current score
            scoreText.text = "Score: " + ScoreManager3.instance.score.ToString();
        }
    }
}
