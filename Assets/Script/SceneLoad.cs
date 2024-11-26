using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{ 
   public float sceneDelay = 1.0f; // Waktu tunggu sebelum berpindah scene

   public void MainMenu()
   {
      StartCoroutine(LoadSceneWithDelay("MainMenu"));
   }
   
   public void LoadMengenal()
   {
      StartCoroutine(LoadSceneWithDelay("LoadMengenal"));
   }

   public void LoadBermain()
   {
      StartCoroutine(LoadSceneWithDelay("LoadBermain"));
   }

   public void LoadSiap()
   {
      StartCoroutine(LoadSceneWithDelay("LoadSiap"));
   }
 
   public void MetodePuzzle()
   {
      StartCoroutine(LoadSceneWithDelay("MetodePuzzle"));
   }

   public void PuzzleBiasa()
   {
      StartCoroutine(LoadSceneWithDelay("PuzzleBiasa"));
   }

   public void PuzzleSulit()
   {
      StartCoroutine(LoadSceneWithDelay("PuzzleSulit"));
   }

   private IEnumerator LoadSceneWithDelay(string sceneName)
   {
      yield return new WaitForSeconds(sceneDelay); // Tunggu sebelum pindah scene
      SceneManager.LoadScene(sceneName); // Pindah ke scene berikutnya
   }
}
