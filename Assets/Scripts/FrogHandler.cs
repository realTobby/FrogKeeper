using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogHandler : MonoBehaviour
{
    public GameObject froggy;

    public Vector3 lastMousePos;

    public GameObject tounge;

    public bool isRotating = false;

    bool IsMouseOverGameWindow { get { return !(0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y); } }

    IEnumerator LerpToRotation(float endRotation, float time, float delay)
    {
        if (isRotating) yield break;

        isRotating = true;

        yield return new WaitForSeconds(delay);

        float startRotation = froggy.transform.rotation.eulerAngles.y;
        float lerpRotation = startRotation;

        float i = 0f;
        float rate = 1 / time;
        while (i <= 1)
        {
            i += Time.deltaTime * rate;

            lerpRotation = Mathf.Lerp(startRotation, endRotation, i);
            froggy.transform.rotation = Quaternion.Euler(0f, lerpRotation, 0f);
            yield return null;
        }
        froggy.transform.rotation = Quaternion.Euler(0f, endRotation, 0f);
        
        isRotating = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Vector3 mousePos = Input.mousePosition;
        lastMousePos = mousePos;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        // get mouse pos

        if(IsMouseOverGameWindow)
        {
            Vector3 mousePos = Input.mousePosition;

            //if(mousePos.x )

            if(froggy.GetComponent<FrogBehaviour>().isDoingSometing == false)
            {
                if (mousePos.x < lastMousePos.x)
                {
                    // flip to left
                    StartCoroutine(LerpToRotation(180, 0.2f, 0f));
                    //tounge.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (mousePos.x > lastMousePos.x)
                {
                    // flip to right
                    StartCoroutine(LerpToRotation(0, 0.2f, 0f));
                    //tounge.GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            lastMousePos = mousePos;

            // convert mouse pos

            var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            // froggy pos

            froggy.transform.position = worldPos;
        }

        

    }
}
