using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScreenMenu()
    {
        SceneManager.LoadSceneAsync("Scenes/Menu");
    }
    public void LoadScreenSelect()
    {
        SceneManager.LoadSceneAsync("Select");
    }

    public void LoadScreenAlReady_1()
    {
        SceneManager.LoadSceneAsync("Scenes/Section1/AlReady1");
    }

    public void LoadScreenStartSection_1()
    {
        SceneManager.LoadSceneAsync("StartSection_1");
    }

    public void LoadScreenSection_1_1()
    {
        SceneManager.LoadSceneAsync("Section_1_1");
    }

    public void LoadScreenSection_1_2()
    {
        SceneManager.LoadSceneAsync("Section_1_2");
    }

    public void LoadScreenSection_1_1_1()
    {
        SceneManager.LoadSceneAsync("Section_1_1_1");
    }

    public void LoadScreenSection_1_1_2()
    {
        SceneManager.LoadSceneAsync("Section_1_1_2");
    }

    public void LoadScreenSection_1_1_3()
    {
        SceneManager.LoadSceneAsync("Section_1_1_3");
    }
}
