using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class PadeOut : MonoBehaviour
{
    private float fadeTime = 2.0f;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        StartFade();
    }

    public void StartFade()
    {
        StartCoroutine(FadeInout());
    }

    private IEnumerator FadeInout()
    {
        yield return StartCoroutine(Fade(1, 0));

        gameObject.SetActive(false);
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }
}
