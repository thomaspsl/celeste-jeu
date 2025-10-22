using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Fade_TextMeshPro : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeDuration = 1.0f;
    public float delay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0.0f;
        Color originalColor = textMeshPro.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeDuration);
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textMeshPro.gameObject.SetActive(false);
    }
}
