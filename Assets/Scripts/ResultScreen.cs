using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timeSurvied;
    public TMPro.TextMeshProUGUI fliesEaten;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        // load variables

        var timeSurviedVal = PlayerPrefs.GetFloat("LastTime");
        var flies = PlayerPrefs.GetInt("FliesEaten");


        timeSurvied.text = "Time Survived: " + timeSurviedVal.ToString("n2");
        fliesEaten.text = "Flies eaten: " + flies;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack()
    {
        SceneManager.LoadScene(1);
    }

}
