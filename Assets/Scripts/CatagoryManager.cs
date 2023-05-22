using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatagoryManager : MonoBehaviour
{
    [SerializeField] CardManager manager;
    [SerializeField] List<Sprite> colors;
    public int uniqueCards = 3;
    // Start is called before the first frame update
    void Start()
    {
        manager.sprites.Clear();
    }

    public void SetCatogory(string catagory)
    {
        if (catagory == "colors")
        {
            for (int i = 0; i < uniqueCards; i++)
            {
                int randomSprite = Random.Range(0, colors.Count);
                manager.sprites.Add(colors[randomSprite]);
                manager.sprites.Add(colors[randomSprite]);
                colors.Remove(colors[randomSprite]);

            }
        }
        manager.RandomCards();
    }
}
