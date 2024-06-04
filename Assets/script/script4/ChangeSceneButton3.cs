using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton3 : MonoBehaviour
{
    public string nextSceneName; // The name of the scene to load
    public int scoreToAdd; // The amount of score to add when the button is clicked
    public bool resetScore; // Whether to reset the score when the button is clicked

    void Start()
    {
        // Add a listener to the button's onClick event
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // Check if the ScoreManager3 instance is available
        if (ScoreManager3.instance != null)
        {
            // Reset the score if resetScore is true
            if (resetScore)
            {
                ScoreManager3.instance.ResetScore();
            }
            // Otherwise, add to the score
            else
            {
                ScoreManager3.instance.AddScore(scoreToAdd);
            }

            // Load the next scene
            ScoreManager3.instance.LoadScene(nextSceneName);
        }
    }
}
