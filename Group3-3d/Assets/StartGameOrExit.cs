using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameOrExit : MonoBehaviour
{
    AudioSource titleSounds;
    public Animator fader;
    //public AudioClip GunShot;
    private void Start()
    {
        titleSounds = GetComponent<AudioSource>();
    }

    public void GoToFirstLevel()
    {
        StartCoroutine(waitForFading());
        SceneManager.LoadScene("lvl1");
    }

    public void ExitGame()
    {
        StartCoroutine(waitForFading());
        Application.Quit();
    }

    IEnumerator waitForFading()
    {
        fader.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3);
    }

}
