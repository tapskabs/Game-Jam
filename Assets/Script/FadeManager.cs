using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;

    void Start()
    {
        fadeImage.gameObject.SetActive(false); 
    }

    public IEnumerator FadeInAndOut(float fadeDuration, GameObject player, Transform teleportLocation)
    {
        fadeImage.gameObject.SetActive(true);
        
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        
        player.transform.position = teleportLocation.position;

        
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }
}
