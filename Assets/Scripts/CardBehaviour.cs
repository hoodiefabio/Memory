using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] GameObject coverImage;
    public bool found;
    public static int matches;
    // Start is called before the first frame update
   
    void Start()
    {
        matches = 0;
        found = false;
        coverImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }

    public void CheckMatch(CardBehaviour otherCard, bool result)
    {
        if (otherCard.gameObject != this.gameObject)
        {
            if (otherCard.GetComponent<Image>().sprite.name == this.GetComponent<Image>().sprite.name)
                result = true;
            else if (otherCard.GetComponent<Image>().sprite.name != this.GetComponent<Image>().sprite.name)
                result = false;
            StartCoroutine(ResultCheck(otherCard, result));
        }
    }

    private IEnumerator ResultCheck(CardBehaviour otherCard, bool result)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (result)
        {
            matches++;
            otherCard.found = true;
            this.found = true;

        }
        else if (!result)
        {
            otherCard.ToggleCover();
            this.ToggleCover();
        }
    }

    public void ToggleCover()
    {
        if(coverImage != null && !found)
        {
            if (coverImage.activeSelf == true)
                coverImage.SetActive(false);

            else if (coverImage.activeSelf == false)
                coverImage.SetActive(true);
        }
    }
}