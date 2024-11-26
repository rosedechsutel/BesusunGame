using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSiap : MonoBehaviour
{
    public Text HitungMundurText;

    void Start()
    {
        StartCoroutine(HitungMundur());
    }

    IEnumerator HitungMundur()
    {
        HitungMundurText.text = "3";
        yield return new WaitForSeconds(1f);

        HitungMundurText.text = "2";
        yield return new WaitForSeconds(1f);

        HitungMundurText.text = "1";
        yield return new WaitForSeconds(1f);

        HitungMundurText.text = "Mulai";
        yield return new WaitForSeconds(1f);


        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(MetodePuzzle.pilihanPuzzle);
    }
}
