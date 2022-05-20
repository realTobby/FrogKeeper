using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KordesiiLogoTimer : MonoBehaviour
{
    public AudioSource sound;

    public void EndStartup()
    {
        SceneManager.LoadScene(1);
    }


    IEnumerator StartupLogo(int timer)
    {
        int maxTime = timer;

        while(timer > 0)
        {
            if (timer == maxTime-1)
                sound.Play();

            yield return new WaitForSeconds(1);
            timer--;
        }
        EndStartup();
        yield break;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartupLogo(7));
    }
}
