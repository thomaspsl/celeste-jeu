using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish_Event : MonoBehaviour
{
    public string m_playAgainButtonSceneName;
    public Button m_playAgainButton;
    public string m_homeButtonSceneName;
    public Button m_homeButton;

    // Start is called before the first frame update
    void Start()
    {
        m_playAgainButton.onClick.AddListener(TaskOnClickPlayAgain);
        m_homeButton.onClick.AddListener(TaskOnClickHome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TaskOnClickPlayAgain()
    {
        SceneManager.LoadScene(m_playAgainButtonSceneName);
    }

    private void TaskOnClickHome()
    {
        SceneManager.LoadScene(m_homeButtonSceneName);
    }
}
