using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    private pickRelic relicCheck;
    //public GameObject fadeOutCanvas;
    public Animator fadePlay;
    // Start is called before the first frame update
    void Start()
    {
        relicCheck = GetComponent<pickRelic>();
        
    }

    // Update is called once per frame
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("endGame") && relicCheck.playerHasRelic())
        {
            FadeToLevel();
            StartCoroutine(fadeOutAndChangeToTitle());
        }
        else
        {
            Debug.Log("Player does not have Relic");
        }
    }



    IEnumerator fadeOutAndChangeToTitle()
    {
        //fadeOutCanvas.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Title");
    }

    public void FadeToLevel()
    {
        fadePlay.SetTrigger("FadeOut");
    }
}
