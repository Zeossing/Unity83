using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton instance

    public Text scoreText;
    public Image imageToChange;
    public Sprite newSprite;
    public Sprite originalSprite;

    public int score = 0; // ทำให้ตัวแปร score สาธารณะ
    private bool hasReached100 = false;

    void Awake()
    {
        // เช็คถ้ามี instance อยู่แล้วทำลายออบเจ็กต์นี้
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // ไม่ทำลายออบเจ็กต์นี้เมื่อเปลี่ยนฉาก
        }
    }

    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreText();

        if (score >= 100 && !hasReached100)
        {
            hasReached100 = true;
            ChangeImage(newSprite);
        }
        else if (score < 100 && hasReached100)
        {
            hasReached100 = false;
            ChangeImage(originalSprite);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    void ChangeImage(Sprite newSprite)
    {
        if (imageToChange != null && newSprite != null)
        {
            imageToChange.sprite = newSprite;
        }
    }
}
