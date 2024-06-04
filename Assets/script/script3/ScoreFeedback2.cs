using UnityEngine;
using UnityEngine.UI;

public class ScoreFeedback2 : MonoBehaviour
{
    public int twoStarScoreThreshold;
    public int threeStarScoreThreshold;
    public Image star1;
    public Image star2;
    public Image star3;
    public Text feedbackText;
    public Image imageToDisable; // รูปภาพที่ต้องการปิด
    public Button buttonToEnable; // ปุ่มที่ต้องการเปิด

    void Start()
    {
        DisplayScoreFeedback();
    }

    void DisplayScoreFeedback()
    {
        int score = ScoreManager2.instance.score; // แก้จาก ScoreManager เป็น ScoreManager2

        if (score >= threeStarScoreThreshold)
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = true;
            feedbackText.text = "สุดยอด!";
            imageToDisable.gameObject.SetActive(false); // ปิดรูปภาพ
            buttonToEnable.interactable = true; // เปิดให้ปุ่มกดได้
        }
        else if (score >= twoStarScoreThreshold)
        {
            star1.enabled = false;
            star2.enabled = true;
            star3.enabled = false;
            feedbackText.text = "พยายามต่อนะ!";
            imageToDisable.gameObject.SetActive(true); // ปิดรูปภาพ
            buttonToEnable.interactable = false; // ปิดให้ปุ่มไม่สามารถกดได้
        }
        else
        {
            star1.enabled = true;
            star2.enabled = false;
            star3.enabled = false;
            feedbackText.text = "พยายามอีกหน่อย!";
            imageToDisable.gameObject.SetActive(true); // ปิดรูปภาพ
            buttonToEnable.interactable = false; // ปิดให้ปุ่มไม่สามารถกดได้
        }
    }
}
