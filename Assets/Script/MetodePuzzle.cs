using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodePuzzle : MonoBehaviour
{
    public static string pilihanPuzzle;

    public void PilihGampang() {
        pilihanPuzzle = "PuzzleGampang";
        SceneManager.LoadScene("LoadSiap");
    }

    public void PilihBiasa() {
        pilihanPuzzle = "PuzzleBiasa";
        SceneManager.LoadScene("LoadSiap");
    }

    public void PilihSulit() {
        pilihanPuzzle = "PuzzleSulit";
        SceneManager.LoadScene("LoadSiap");
    }
}
