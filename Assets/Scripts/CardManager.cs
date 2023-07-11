using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] List<CardBehaviour> cards;
    [HideInInspector] public List<Sprite> sprites;
    [SerializeField] GameObject winIndicator;
    [SerializeField] public Timer timer;
    [SerializeField] string highscoreName;
    [SerializeField] public AudioSource correctSound;
    [SerializeField] public AudioSource incorrectSound;
    [HideInInspector] public CardBehaviour lastSelectedCard;
    [HideInInspector] public bool newHighscore;
    [HideInInspector] public bool checkingResults;

    // Start is called before the first frame update
    void Start()
    {
        winIndicator.SetActive(false);
        newHighscore = false;
    }

    public void RandomCards()
    {
        foreach (CardBehaviour card in cards)
        {
            int currentSprite = Random.Range(0, sprites.Count);
            card.ChangeImage(sprites[currentSprite]);
            sprites.Remove(sprites[currentSprite]);
        }
    }

    public void SelectCard(CardBehaviour card)
    {
        if(lastSelectedCard == null && !card.found)
        {
            lastSelectedCard = card;
        }
        else if (lastSelectedCard != null && !card.found)
        {
            bool correctMatch = true;
            card.CheckMatch(lastSelectedCard, correctMatch);
            correctMatch = false;
            lastSelectedCard=null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cards != null && CardBehaviour.matches == (cards.Count/2))
        {
            GameWon();
        }
    }

    void GameWon()
    {
        if (timer.timeValue < PlayerPrefs.GetFloat(highscoreName, 90))
        {
            PlayerPrefs.SetFloat(highscoreName, timer.timeValue);
            newHighscore = true; 
        }
        winIndicator.SetActive(true);
        timer.timerIsRunning = false;
    }
}
