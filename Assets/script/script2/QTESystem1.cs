using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QTESystem1 : MonoBehaviour
{
    public Image promptImage; // UI Image component to display the QTE prompt
    public Sprite[] promptSprites; // Array of Sprites for the QTE prompts (e.g., A, B, X, Y)
    public KeyCode[] promptKeys; // Array of KeyCodes corresponding to the QTE prompts
    public float timeLimit = 2.0f; // Time limit for the QTE
    public int successScore = 10; // Score to add on success
    public int failScore = -5; // Score to subtract on failure
    public string nextSceneName; // Name of the next scene to load on success
    public AudioSource audioSource; // AudioSource component
    public AudioClip qteStartSound; // Sound to play when QTE starts
    public AudioClip qteSuccessSound; // Sound to play when QTE is successful
    public AudioClip qteFailSound; // Sound to play when QTE fails
    public Slider leftSlider; // UI Slider to display the left half of the countdown timer
    public Slider rightSlider; // UI Slider to display the right half of the countdown timer

    private float timer;
    private int currentPromptIndex;
    private bool qteActive = false;

    void Update()
    {
        if (qteActive)
        {
            timer -= Time.deltaTime;
            float normalizedTime = timer / timeLimit;
            if (leftSlider != null)
            {
                leftSlider.value = normalizedTime;
            }
            if (rightSlider != null)
            {
                rightSlider.value = normalizedTime;
            }

            if (timer <= 0)
            {
                FailQTE();
            }

            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(promptKeys[currentPromptIndex]))
                {
                    SuccessQTE();
                }
                else
                {
                    FailQTE();
                }
            }
        }
    }

    public void StartQTE()
    {
        qteActive = true;
        timer = timeLimit;
        currentPromptIndex = Random.Range(0, promptSprites.Length);
        promptImage.sprite = promptSprites[currentPromptIndex];
        promptImage.gameObject.SetActive(true);

        if (leftSlider != null)
        {
            leftSlider.gameObject.SetActive(true);
            leftSlider.maxValue = 1.0f;
            leftSlider.value = 1.0f;
        }

        if (rightSlider != null)
        {
            rightSlider.gameObject.SetActive(true);
            rightSlider.maxValue = 1.0f;
            rightSlider.value = 1.0f;
        }

        if (audioSource != null && qteStartSound != null)
        {
            audioSource.PlayOneShot(qteStartSound);
        }
    }

    void SuccessQTE()
    {
        qteActive = false;
        promptImage.gameObject.SetActive(false);
        if (leftSlider != null)
        {
            leftSlider.gameObject.SetActive(false);
        }
        if (rightSlider != null)
        {
            rightSlider.gameObject.SetActive(false);
        }
        Debug.Log("QTE Success!");

        // Play success sound
        if (audioSource != null && qteSuccessSound != null)
        {
            audioSource.PlayOneShot(qteSuccessSound);
        }

        // Add success score
        if (ScoreManager1.instance != null)
        {
            ScoreManager1.instance.AddScore(successScore);
        }
        
        // Change scene
        SceneManager.LoadScene(nextSceneName);

        // Add your additional success logic here (e.g., play animation, grant reward, etc.)
    }

    void FailQTE()
    {
        qteActive = false;
        promptImage.gameObject.SetActive(false);
        if (leftSlider != null)
        {
            leftSlider.gameObject.SetActive(false);
        }
        if (rightSlider != null)
        {
            rightSlider.gameObject.SetActive(false);
        }
        Debug.Log("QTE Failed!");

        // Play fail sound
        if (audioSource != null && qteFailSound != null)
        {
            audioSource.PlayOneShot(qteFailSound);
        }

        // Subtract fail score
        if (ScoreManager1.instance != null)
        {
            ScoreManager1.instance.AddScore(failScore);
        }

        // Add your additional failure logic here (e.g., play fail animation, reduce health, etc.)
    }
}
