using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DragAndDrop : MonoBehaviour
{
    public GameObject Detect;
    Vector3 Pos_awal, Scale_awal;
    bool On_pos = false;
    bool sudahBenar = false;

    public static int potonganBenar = 0;
    public int totalPotongan;
    public Text counterText;

    public Text timeText;
    private float startTime;
    private bool timerStarted = false;

    public Button btnKembali;
    public GameObject panelSelesai; // Panel untuk bintang dan tombol
    public Image [] bintangImages; // Array untuk gambar bintang
    public Sprite bintangPenuh; // Sprite untuk bintang penuh
    public Sprite bintangKosong; // Sprite untuk bintang kosong

    // Tambahkan enum untuk menentukan mode puzzle
    public enum ModePuzzle { Gampang, Biasa, Sulit }
    public ModePuzzle modePuzzle;

    // Variabel untuk menyimpan waktu berdasarkan mode
    private float waktuBintang3; // Waktu untuk 3 bintang
    private float waktuBintang2; // Waktu untuk 2 bintang

    void Start()
    {
        Pos_awal = transform.position;
        Scale_awal = transform.localScale;
        potonganBenar = 0;
        UpdateCounter();
        timeText.text = "Waktu: 00:00";  

        startTime = Time.time;
        timerStarted = true;

        btnKembali.gameObject.SetActive(false);
        panelSelesai.SetActive(false); // Sembunyikan panel selesai di awal

        // Set waktu bintang sesuai mode
        SetWaktuBintang();
    }

    void Update()
    {
        if (timerStarted && potonganBenar < totalPotongan)
        {
            float elapsedTime = Time.time - startTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
            string timeFormatted = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            timeText.text = "Waktu: " + timeFormatted;
        }
    }

    void OnMouseDrag()
    {   
        if (sudahBenar) return;

        Vector3 Pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        transform.position = new Vector3(Pos_mouse.x, Pos_mouse.y, -1f);
        transform.localScale = new Vector2(250f, 250f);

        GetComponent<SpriteRenderer>().sortingOrder =10;
    }

    void OnMouseUp()
    {
        if (On_pos && !sudahBenar)
        {
            transform.position = Detect.transform.position;
            transform.localScale = new Vector2(280f, 280f);

            GetComponent<SpriteRenderer>().sortingOrder = 0;

            if (Detect != null)
            {
                potonganBenar++;
                UpdateCounter();
                sudahBenar = true;

                if (potonganBenar == totalPotongan)
                {
                    float totalTime = Time.time - startTime;
                    TimeSpan timeSpan = TimeSpan.FromSeconds(totalTime);
                    string timeFormatted = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                    timeText.text = "Waktu: " + timeFormatted;
                    timerStarted = false;

                    panelSelesai.SetActive(true); // Tampilkan panel selesai
                    SetBintang(totalTime); // Set bintang berdasarkan waktu
                    btnKembali.gameObject.SetActive(true);
                }
            }
        }
        else if (!sudahBenar)
        {
            transform.position = Pos_awal;
            transform.localScale = Scale_awal;

            GetComponent<SpriteRenderer>().sortingOrder =1;
        }
    }

    void OnTriggerStay2D(Collider2D Object)
    {
        if (Object.gameObject == Detect)
        {
            On_pos = true;
        }
    }

    void OnTriggerExit2D(Collider2D Object)
    {
        if (Object.gameObject == Detect)
        {
            On_pos = false;
        }
    }

    void UpdateCounter()
    {
        counterText.text = potonganBenar + "/" + totalPotongan;
    }

    // Fungsi untuk mengatur waktu bintang berdasarkan mode puzzle
    void SetWaktuBintang()
    {
        if (modePuzzle == ModePuzzle.Gampang)
        {
            waktuBintang3 = 15f;   // 10 detik untuk 3 bintang
            waktuBintang2 = 20f;  // 20 detik untuk 2 bintang
        }
        else if (modePuzzle == ModePuzzle.Biasa)
        {
            waktuBintang3 = 120f;  // 2 menit untuk 3 bintang
            waktuBintang2 = 240;  // 4 menit untuk 2 bintang
        }
        else if (modePuzzle == ModePuzzle.Sulit)
        {
            waktuBintang3 = 480f;  // 8 menit untuk 3 bintang
            waktuBintang2 = 600f;  // 10 menit untuk 2 bintang
        }
    }

    void SetBintang(float waktuSelesai)
    {
        // Reset bintang menjadi kosong
        foreach (Image bintang in bintangImages)
        {
            bintang.sprite = bintangKosong;
        }

        // Set jumlah bintang berdasarkan waktu
        if (waktuSelesai <= waktuBintang3)
        {
            // 3 bintang
            for (int i = 0; i < 3; i++)
            {
                bintangImages[i].sprite = bintangPenuh;
            }
        }
        else if (waktuSelesai <= waktuBintang2)
        {
            // 2 bintang
            for (int i = 0; i < 2; i++)
            {
                bintangImages[i].sprite = bintangPenuh;
            }
        }
        else
        {
            // 1 bintang
            bintangImages[0].sprite = bintangPenuh;
        }
    }
}