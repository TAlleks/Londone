using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;

    public Slider scale;

    public void Loading()

    {
        LoadingScreen.SetActive(true);
        //StartCoroutine(LoadAsync());
        SceneManager.LoadScene("Location");
    }

    IEnumerator LoadAsync()

    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync("Location");
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)

        {
            scale.value = loadAsync.progress;

            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)

            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}