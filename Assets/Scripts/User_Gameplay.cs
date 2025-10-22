using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class User_Gameplay : MonoBehaviour
{
    AudioSource m_Source;
    private int heart;
    private int heartObjectCount;
    private int lightning;
    private int lightningObjectCount;
    
    [SerializeField] TextMeshProUGUI m_heart;
    [SerializeField] TextMeshProUGUI m_lightning;
    [SerializeField] AudioClip m_Death;
    [SerializeField] AudioClip m_Ting;
    [SerializeField] AudioClip m_Ouch;

    // Start is called before the first frame update
    void Start()
    {
        heart = 3;
        heartObjectCount = heart;

        lightning = 0;
        lightningObjectCount = CountObjectsWithTag("Lightning");

        m_heart.text = heart.ToString() + "/" + heartObjectCount.ToString();
        m_lightning.text = lightning.ToString() + "/" + lightningObjectCount.ToString();
        m_Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            lightningObjectCount = lightning + 1;
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            heart = heart * 10;
            heartObjectCount = heartObjectCount * 10;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LauncherScene");
        }
    }

    private int CountObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        return objectsWithTag.Length;
    }

    public void Death()
    {
        SceneManager.LoadScene("LooseScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_Source.isPlaying)
        {
            switch (collision.gameObject.tag)
            {
                case "Lightning":
                    m_Source.clip = m_Ting;
                    Destroy(collision.gameObject);
                    lightning++;
                    m_Source.Play();
                    if(lightning == lightningObjectCount) SceneManager.LoadScene("WinScene");
                    break;
                case "Enemy":
                    if(heart - 1 > 0){
                        m_Source.clip = m_Ouch;
                        m_Source.Play();
                        heart--;
                    } else {
                        m_Source.clip = m_Death;
                        m_Source.Play();
                        Invoke("Death", 1);
                    }
                    break;
                default:
                    break;
            }
        }
        m_heart.text = heart.ToString() + "/" + heartObjectCount.ToString();
        m_lightning.text = lightning.ToString() + "/" + lightningObjectCount.ToString();
    }
}

