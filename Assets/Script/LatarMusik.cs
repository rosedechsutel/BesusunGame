using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatarMusik : MonoBehaviour
{
    private static LatarMusik latarMusik;

    void Awake()
    {
        if(latarMusik == null)
        {
            latarMusik = this;
            DontDestroyOnLoad(latarMusik);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
