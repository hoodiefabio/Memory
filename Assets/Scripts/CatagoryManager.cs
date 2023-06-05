using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatagoryManager : MonoBehaviour
{
    [SerializeField] CardManager manager;
    [SerializeField] List<Sprite> colors;
    [SerializeField] List<Sprite> shapes;
    [SerializeField] List<Sprite> animals;
    public int uniqueCards = 3;
    // Start is called before the first frame update
    void Start()
    {
        manager.sprites.Clear();
        manager.timer.timerIsRunning = false;
    }

    public void SetCatogory(string catagory)
    {
        List<Sprite> catagorySprites;

        if (catagory == "shapes")
            catagorySprites = shapes;
        else if (catagory == "animals")
            catagorySprites = animals;
        else
            catagorySprites = colors;


        for (int i = 0; i < uniqueCards; i++)
        {
            int randomSprite = Random.Range(0, catagorySprites.Count);
            manager.sprites.Add(catagorySprites[randomSprite]);
            manager.sprites.Add(catagorySprites[randomSprite]);
            catagorySprites.Remove(catagorySprites[randomSprite]);

        }
        manager.RandomCards();
        manager.timer.timerIsRunning = true;
    }
}
