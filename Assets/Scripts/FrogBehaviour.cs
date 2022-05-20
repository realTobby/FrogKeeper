using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogBehaviour : MonoBehaviour
{
    public GameObject UI_ELEMENT_INFO_SPECIAL;


    public Animator frogAnimator;

    public AudioSource croaking;

    public AudioClip[] croaks;

    public bool isDoingSometing = false;

    public bool CanUseSpecial = false;

    public BoxCollider2D abilityHitbox;

    public ScoreHandler scores;

    private void Start()
    {

        StartCoroutine(AbilityCooldown());

        StartCoroutine(Blink());
        StartCoroutine(Croak());
    }


    IEnumerator AbilityCooldown()
    {
        UI_ELEMENT_INFO_SPECIAL.SetActive(false);
        yield return new WaitForSeconds(50);
        UI_ELEMENT_INFO_SPECIAL.SetActive(true);
        CanUseSpecial = true;
    }


    IEnumerator Croak()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(2, 10));

            if(isDoingSometing == false)
            {
                isDoingSometing = true;
                frogAnimator.Play("frogCroak");

                croaking.clip = croaks[Random.Range(0, croaks.Length)];
                croaking.Play();

                yield return new WaitForSeconds(0.2f);
                isDoingSometing = false;

            }
        }
    }

    IEnumerator Blink()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 9));
            if(isDoingSometing == false)
            {
                isDoingSometing = true;
                frogAnimator.Play("frogBlinking");
                yield return new WaitForSeconds(0.2f);
                isDoingSometing = false;
            }
            
        }
    }

    IEnumerator UseAbility()
    {
        isDoingSometing = true;
        CanUseSpecial = false;

        abilityHitbox.enabled = true;

        // play animation
        frogAnimator.Play("frogOpenMouth");

        yield return new WaitForSeconds(0.5f);
        abilityHitbox.enabled = false;

        yield return new WaitForSeconds(1.5f);

        

        // stop animation
        frogAnimator.Play("frogBlinking");

        isDoingSometing = false;

        yield break;
    }


    private void Update()
    {
        if(CanUseSpecial == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(UseAbility());
                StartCoroutine(AbilityCooldown());
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("fly"))
        {
            var animatorinfo = this.frogAnimator.GetCurrentAnimatorClipInfo(0);
            if(animatorinfo[0].clip.name == "frogOpenMouth")
            {
                Destroy(collision.gameObject);
                scores.AteAFly();
            }

            else if (collision.transform.GetComponent<FlyBehaviour>().IsDeadlyForFroggy == true)
            {
                scores.SaveLastScore();

                SceneManager.LoadScene(2);
            }

        }
    }


}
