using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCoHoi : MonoBehaviour
{
    public int theDuocChon = 0;
    public AudioSource audioSource;

    public static bool phaHuy = false;
    public static NhanVat_ThongTin nhanVat;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        theDuocChon = Random.Range(0, 8);
    }

    void Update()
    {
        HienThiThe();
        if (phaHuy)
        {
            phaHuy = false;
            Destroy(gameObject);
        }
    }

    public void HienThiThe()
    {
        int i = 0;
        foreach(Transform the in transform)
        {
            if (i == theDuocChon)
                the.gameObject.SetActive(true);
            else the.gameObject.SetActive(false);
            i++;
        }
    }

    public static void ChonNhanVat(NhanVat_ThongTin nv)
    {
        nhanVat = nv;
    }
}
