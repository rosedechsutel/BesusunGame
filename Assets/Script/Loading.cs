using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public string sceneToLoad;
    
    public void OnAnimationComplete()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneToLoad);
        loading.allowSceneActivation = false;

        yield return new WaitForSeconds(0.1f);
        loading.allowSceneActivation = true;
    }
}
