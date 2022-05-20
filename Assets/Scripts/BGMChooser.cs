using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChooser : MonoBehaviour
{
    public TMPro.TextMeshProUGUI jukeboxText;

    public AudioSource audioOut;

    public AudioClip[] bgms;

    // Start is called before the first frame update
    void Start()
    {
        audioOut.clip = bgms[Random.Range(0, bgms.Length)];
        audioOut.Play();
        jukeboxText.text = "BGM : " + audioOut.clip.name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
