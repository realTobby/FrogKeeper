using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChooser : MonoBehaviour
{
    public TMPro.TextMeshProUGUI jukeboxText;

    public AudioSource audioOut;

    public AudioClip[] bgms;

    IEnumerator PlayNext()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            audioOut.clip = bgms[Random.Range(0, bgms.Length)];
            audioOut.Play();
            jukeboxText.text = "BGM : " + audioOut.clip.name;

            yield return new WaitForSeconds(audioOut.clip.length);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayNext());

    }

    // Update is called once per frame
    void Update()
    {
    }

}
