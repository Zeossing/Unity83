using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton1 : MonoBehaviour
{
    public string nextSceneName;
    public int scoreToAdd;
    public bool resetScore;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (ScoreManager1.instance != null) // แก้จาก ScoreManager เป็น ScoreManager1
        {
            if (resetScore)
            {
                ScoreManager1.instance.ResetScore(); // แก้จาก ScoreManager เป็น ScoreManager1
            }
            else
            {
                ScoreManager1.instance.AddScore(scoreToAdd); // แก้จาก ScoreManager เป็น ScoreManager1
            }

            ScoreManager1.instance.LoadScene(nextSceneName); // แก้จาก ScoreManager เป็น ScoreManager1
        }
    }
}
