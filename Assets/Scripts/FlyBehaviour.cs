using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyBehaviour : MonoBehaviour
{
    public float Speed;

    public Vector3 DirectionVector;

    public bool IsDeadlyForFroggy = false;

    public bool GotCaught = false;

    public GameObject froggyKing;


    IEnumerator ChangeMind()
    {

        while(true)
        {
            DirectionVector = Random.insideUnitCircle.normalized;
            DirectionVector.z = 0;
            Speed = Random.Range(0.5f, 2.5f);
            yield return new WaitForSeconds(Random.Range(10, 20));

        }


    }


    IEnumerator BecomeDeadly()
    {
        yield return new WaitForSeconds(2.5f);
        if(GotCaught == false)
            IsDeadlyForFroggy = true;
        yield break;
    }

    private void Awake()
    {
        froggyKing = GameObject.FindGameObjectWithTag("FroggyKing");

        Speed = Random.Range(0.5f, 2.5f);

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BecomeDeadly());
        // start with a random direction
        StartCoroutine(ChangeMind());
    }

    // Update is called once per frame
    void Update()
    {
        // change direction if hitting screen border

        // check if hitting left border

        if(GotCaught == false)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);


            if (screenPoint.x < 32)
            {
                DirectionVector.x *= -1;
            }

            // check if hitting right border
            if (screenPoint.x > Screen.width - 32)
            {
                DirectionVector.x *= -1;
            }

            // check if hittin top border

            if (screenPoint.y < 32)
            {
                DirectionVector.y *= -1;
            }

            // check if hitting bottom botder

            if (screenPoint.y > Screen.height - 32)
            {
                DirectionVector.y *= -1;
            }

        }
        else
        {
            Destroy(this.gameObject);
        }

        // move towards target direction
        this.transform.position += DirectionVector * Speed * Time.deltaTime;

    }


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("froggySpecial"))
        {
            GotCaught = true;
            froggyKing.GetComponent<FrogBehaviour>().ToungeTouch();
            Destroy(this.gameObject);
        }
    }

}
