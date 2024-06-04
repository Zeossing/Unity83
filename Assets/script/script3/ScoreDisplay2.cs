using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay2 : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component

    void Update()
    {
        // Check if the ScoreManager2 instance is available
        if (ScoreManager2.instance != null)
        {
            // Update the text with the current score
            scoreText.text = "Score: " + ScoreManager2.instance.score.ToString();
        }
    }
}
