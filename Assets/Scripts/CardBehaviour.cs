using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] GameObject coverImage;
    [SerializeField] Animator animator;
    public bool found;
    public static int matches;
    private CardManager cardManager;
    private Button button;
    public bool selected = false;
    // Start is called before the first frame update
   
    void Start()
    {
        matches = 0;
        found = false;
        selected = false;
        coverImage.SetActive(true);
        cardManager = FindObjectOfType<CardManager>().GetComponent<CardManager>();
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cardManager.checkingResults || selected)
        {
            button.interactable = false;
        }
        else button.interactable = true;

        if(!cardManager.checkingResults && !found && ! selected)
        {
            animator.Play("CardCover");
        }

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
        cardManager.checkingResults = true;
        if (result)
        {
            cardManager.correctSound.PlayOneShot(cardManager.correctSound.clip);
            yield return new WaitForSecondsRealtime(0.5f);
            matches++;
            otherCard.found = true;
            this.found = true;

        }
        else if (!result)
        {
            yield return new WaitForSecondsRealtime(1f);
            otherCard.ToggleCover();
            this.ToggleCover();
        }
        cardManager.checkingResults = false;
    }

    public void ToggleCover()
    {
        if (coverImage != null && !found )
        {
            if (coverImage.activeSelf == true)
            {
                animator.Play("CardVisible");
                button.interactable = false;
            }
            else if (coverImage.activeSelf == false)
            {
                animator.Play("CardCover");
                button.interactable = true;
            }            
        }
    }
}
