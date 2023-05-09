using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] GameObject coverImage;
    // Start is called before the first frame update
   
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }

    public IEnumerator CheckMatch(CardBehaviour otherCard)
    {
        if(otherCard.GetComponent<Image>().sprite == this.GetComponent<Image>().sprite)
            yield return true;
        else
            yield return false;
    }

    public void ToggleCover()
    {
        if(coverImage != null)
        {
            if (coverImage.activeSelf == true)
                coverImage.SetActive(false);

            else if (coverImage.activeSelf == false)
                coverImage.SetActive(true);
        }
    }
}
