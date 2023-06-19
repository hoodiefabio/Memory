using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winscreen : MonoBehaviour
{
    [SerializeField] Text highscoreText;
    [SerializeField] string highscoreName;
    [SerializeField] GameObject confetti;
    CardManager cardManager;
    // Start is called before the first frame update
    void Start()
    {
        cardManager = FindObjectOfType<CardManager>().GetComponent<CardManager>();
        confetti.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime(PlayerPrefs.GetFloat(highscoreName));

        if (cardManager.newHighscore)
        {
            confetti.SetActive(true);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        highscoreText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
