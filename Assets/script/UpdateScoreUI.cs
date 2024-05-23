using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreUI : MonoBehaviour
{
    public Text scoreText; // ข้อความ UI ที่จะอัปเดต

    void Start()
    {
        // อัปเดตคะแนนเมื่อเริ่มต้นฉากใหม่
        UpdateScoreText();
    }

    void Update()
    {
        // อัปเดตคะแนนทุกเฟรม
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (ScoreManager.instance != null && scoreText != null)
        {
            scoreText.text = "Score: " + ScoreManager.instance.score.ToString();
        }
    }
}
