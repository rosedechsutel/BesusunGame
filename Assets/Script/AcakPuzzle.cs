using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcakPuzzle : MonoBehaviour
{
    public GameObject[] puzzleObjects;
    private ButtonSound ButtonSound;
    private int previousIndex = -1;

    void Start()
    {
        ButtonSound = FindObjectOfType<ButtonSound>();

        // Nonaktifkan semua objek puzzle pada awalnya
        foreach (GameObject puzzle in puzzleObjects)
        {
            puzzle.SetActive(false);
        }

        // Panggil acak untuk konfigurasi awal
        AcakUlangPuzzle();
    }

    public void AcakUlangPuzzle()
    {
        // Pastikan semua objek puzzle dinonaktifkan sebelum diacak
        foreach (GameObject puzzle in puzzleObjects)
        {
            puzzle.SetActive(false);
        }

        // Pilih indeks acak yang berbeda dari previousIndex
        int indexAcak;
        int maxAttempts = 10; // Jumlah maksimum percobaan untuk mencari indeks yang berbeda
        int attempts = 0;

        do
        {
            indexAcak = Random.Range(0, puzzleObjects.Length);
            attempts++;
            if (attempts >= maxAttempts) break; // Berhenti mencoba setelah 10 percobaan
        } while (indexAcak == previousIndex);

        // Update previousIndex dan aktifkan puzzle pada indeks acak
        previousIndex = indexAcak;
        puzzleObjects[indexAcak].SetActive(true);

        // Mainkan efek suara jika ada
        if (ButtonSound != null)
        {
            ButtonSound.PlaySound();
        }
    }
}
