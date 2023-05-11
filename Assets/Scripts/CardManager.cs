using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] List<CardBehaviour> cards;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] GameObject winIndicator;
    public CardBehaviour lastSelectedCard;

    // Start is called before the first frame update
    void Start()
    {
        RandomCards();
        winIndicator.SetActive(false);
    }

    void RandomCards()
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
        winIndicator.SetActive(true);
    }
}
