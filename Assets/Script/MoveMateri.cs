using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMateri : MonoBehaviour
{
    public GameObject[] Materi;
    public Text penomoranMateriText;
    int index;

    void Start()
    {
        index = 0;
        UpdateMateri();
        UpdateNoMateri();
    }
    void UpdateMateri()
    {
        for(int i = 0; i < Materi.Length; i++)
        {
            Materi[i].gameObject.SetActive(false);
        }
        Materi[index].gameObject.SetActive(true);
    }

    void UpdateNoMateri()
    {
        penomoranMateriText.text = (index + 1). ToString() + "/" + Materi.Length.ToString();
    }

    public void Kanan()
    {
        if(index < Materi.Length - 1)
        {
            index += 1;
        }
        
        else
        {
            index = 0;
        }

        UpdateMateri();
        UpdateNoMateri();
    }

    public void Kiri()
    {
        if(index > 0)
        {
            index -= 1;
        }
        
        else
        {
            index = Materi.Length - 1;
        }

        UpdateMateri();
        UpdateNoMateri();
    }
}
