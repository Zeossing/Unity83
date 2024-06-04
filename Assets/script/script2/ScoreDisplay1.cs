using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay1 : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        if (ScoreManager1.instance != null) // แก้จาก ScoreManager เป็น ScoreManager1
        {
            scoreText.text = "Score: " + ScoreManager1.instance.score.ToString(); // แก้จาก ScoreManager เป็น ScoreManager1
        }
    }
}
