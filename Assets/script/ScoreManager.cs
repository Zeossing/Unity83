using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Image imageToChange; // รูปภาพที่จะเปลี่ยน
    public Sprite newSprite; // รูปภาพใหม่ที่จะใช้เปลี่ยน
    public Sprite originalSprite; // รูปภาพเดิม

    private int score = 0;
    private bool hasReached100 = false; // เพิ่มตัวแปรนี้

    void Start()
    {
        // โหลดคะแนนล่าสุดจาก PlayerPrefs
        score = PlayerPrefs.GetInt("Score", 0);
        UpdateScoreText();
    }

    public void AddScore(int scoreToAdd)
    {
        // เก็บค่ารูปภาพเดิม
        Sprite currentSprite = imageToChange.sprite;

        score += scoreToAdd;
        UpdateScoreText();

        // เพิ่มเงื่อนไขเพื่อเปลี่ยนรูปภาพเมื่อคะแนนถึง 100
        if (score >= 100 && !hasReached100)
        {
            hasReached100 = true;
            ChangeImage(newSprite);
        }
        // เงื่อนไขเพื่อเปลี่ยนรูปภาพกลับเป็นเดิมเมื่อคะแนนน้อยกว่า 100
        else if (score < 100 && hasReached100)
        {
            hasReached100 = false;
            ChangeImage(originalSprite);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // เมื่อเกมจบ
    void OnDisable()
    {
        // บันทึกคะแนนล่าสุดใน PlayerPrefs
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save(); // บันทึกข้อมูล
    }

    void ChangeImage(Sprite newSprite)
    {
        // เปลี่ยนรูปภาพ
        if (imageToChange != null && newSprite != null)
        {
            imageToChange.sprite = newSprite;
        }
    }
}

public class ButtonController : MonoBehaviour
{
    public int scoreToAdd = 10; // คะแนนที่จะเพิ่มเมื่อกดปุ่ม
    public ScoreManager scoreManager;

    void Start()
    {
        // หา ScoreManager ใน Scene หากไม่ได้กำหนด
        if (scoreManager == null)
            scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnButtonPressed()
    {
        // เพิ่มคะแนนเมื่อกดปุ่ม
        scoreManager.AddScore(scoreToAdd);
    }
}
