using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade_RawPicture : MonoBehaviour
{
    public RawImage image;
    public float fadeDuration = 1.0f;
    public float delay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutImage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FadeOutImage()
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0.0f;
        Color originalColor = image.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeDuration);
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.gameObject.SetActive(false);
    }
}