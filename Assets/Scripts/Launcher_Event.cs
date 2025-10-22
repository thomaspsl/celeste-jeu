using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launcher_Event : MonoBehaviour
{
    public string m_playButtonSceneName;
    public Button m_playButton;
    public Button m_exitButton;

    // Start is called before the first frame update
    void Start()
    {
        m_playButton.onClick.AddListener(TaskOnClickPlay);
        m_exitButton.onClick.AddListener(TaskOnClickExit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TaskOnClickPlay()
    {
        SceneManager.LoadScene(m_playButtonSceneName);
    }

    private void TaskOnClickExit()
    {
        Application.Quit();
    }
}
