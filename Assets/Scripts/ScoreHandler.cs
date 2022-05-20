using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;


    public float CurrentTime = 0f;

    public int FliesEaten = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;



        scoreText.text = "Time: " + CurrentTime.ToString("n2");



    }

    public void AteAFly()
    {
        FliesEaten += 1;
    }

    public void SaveLastScore()
    {

        PlayerPrefs.SetFloat("LastTime", CurrentTime);
        PlayerPrefs.SetInt("FliesEaten", FliesEaten);
        PlayerPrefs.Save();

    }

}
