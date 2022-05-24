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

    public GameObject toungeAbility;

    public ScoreHandler scores;

    public GameObject indicator;

    private void Start()
    {

        StartCoroutine(AbilityCooldown());

        StartCoroutine(Blink());
        StartCoroutine(Croak());
    }


    IEnumerator AbilityCooldown()
    {
        UI_ELEMENT_INFO_SPECIAL.SetActive(false);
        indicator.SetActive(false);
        yield return new WaitForSeconds(6);
        UI_ELEMENT_INFO_SPECIAL.SetActive(true);
        indicator.SetActive(true);
        CanUseSpecial = true;
    }

    IEnumerator SingleCroak()
    {

        isDoingSometing = true;
        frogAnimator.Play("frogCroak");

        croaking.clip = croaks[Random.Range(0, croaks.Length)];
        croaking.pitch = Random.Range(0, 3);
        croaking.Play();

        yield return new WaitForSeconds(0.2f);
        isDoingSometing = false;


    }

    IEnumerator Croak()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            if (isDoingSometing == false)
            {
                StartCoroutine(SingleCroak());
            }
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 10));
            if (isDoingSometing == false)
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



        // play animation
        frogAnimator.Play("frogOpenMouth");

        yield return new WaitForSeconds(.2f);



        //toungeAbility.transform.LookAt(indicator.transform);

        //abilityHitbox.enabled = true;
        toungeAbility.SetActive(true);

        //Debug.Log(toungeAbility.transform.rotation.z);

        Vector3 moveDirection = indicator.transform.position - toungeAbility.transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            toungeAbility.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        //Debug.Log(toungeAbility.transform.rotation.z);

        yield return new WaitForSeconds(.5f);

        //toungeAbility.enabled = false;
        toungeAbility.SetActive(false);

        // stop animation
        frogAnimator.Play("frogIdle");

        isDoingSometing = false;

        yield break;
    }


    private void Update()
    {
        if (CanUseSpecial == true)
        {
            if (Input.GetMouseButton(1))
            {
                StartCoroutine(UseAbility());
                StartCoroutine(AbilityCooldown());
            }
        }

    }

    public void ToungeTouch()
    {
        scores.AteAFly();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("fly"))
        {
            if (collision.transform.GetComponent<FlyBehaviour>().IsDeadlyForFroggy == true)
            {
                scores.SaveLastScore();
                SceneManager.LoadScene(2);
            }
        }
    }
}


