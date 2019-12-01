 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public GameObject panel;
    public Button Skip;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true); //해상도 조정
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void LoadHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void LoadGamemap1()
    {
        SceneManager.LoadScene("map1");
    }

    public void LoadGamemap2()
    {
        SceneManager.LoadScene("map2");
    }

    public void LoadGamemap3()
    {
        SceneManager.LoadScene("map3");
    }

    public void LoadGameEnd()
    {
        SceneManager.LoadScene("End");
    }

    public void paneldie()
    {
        panel.gameObject.SetActive(false);
        Skip.gameObject.SetActive(false);
    }
}
