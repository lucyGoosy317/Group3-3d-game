using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FadeOut(Music.Instance.gameObject.GetComponent<AudioSource>(), 5f));
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
