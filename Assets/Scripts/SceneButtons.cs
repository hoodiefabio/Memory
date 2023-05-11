using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
   public void Reload()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadScene(index));
    }

    private IEnumerator LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        yield return null;
    }


}
