using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Music.Instance.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            Music.Instance.gameObject.GetComponent<AudioSource>().Play();
        }
        Cursor.visible = true;
    }
}
