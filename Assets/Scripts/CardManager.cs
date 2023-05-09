using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField] List<CardBehaviour> cards;
    [SerializeField] List<Sprite> sprites;

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
            Debug.Log(sprites[currentSprite].name);
            card.ChangeImage(sprites[currentSprite]);
            sprites.Remove(sprites[currentSprite]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
