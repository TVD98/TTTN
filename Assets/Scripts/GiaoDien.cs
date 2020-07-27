using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GiaoDien : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool daTonTai = false;

    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        daTonTai = true;
        LayThongTin();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Input.GetMouseButton(1))
        {
            TatHienThi();
        }
        CapNhap();
    }

    public void PhaHuy()
    {
        daTonTai = false;
        Destroy(gameObject);
    }

    public abstract void LayThongTin();
    public abstract void CapNhap();
    public abstract void TatHienThi();


    

    
}
