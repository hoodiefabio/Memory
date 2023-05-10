using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] List<CardBehaviour> cards;
    [SerializeField] List<Sprite> sprites;
    public CardBehaviour lastSelectedCard;

    // Start is called before the first frame update
    void Start()
    {
        RandomCards();
    }

    void RandomCards()
    {
        foreach (CardBehaviour card in cards)
        {
            int currentSprite = Random.Range(0, sprites.Count-1);
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
        
    }
}
