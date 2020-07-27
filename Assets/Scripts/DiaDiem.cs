using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiaDiem : MonoBehaviour
{ 
    public string ten;
    public GameObject giaoDienThongTin;
    public SuKienChuotTrai suKien;

    public float y;

    // Start is called before the first frame update
    void Start()
    {
        suKien = new ThongTinDiaDiem();
        y = transform.position.y;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Main.sanSanBatDau)
        {
            suKien.NhanSuKienChuotTrai(GetComponent<DiaDiem>());
        }
    }

    public void NangCaoToaDo()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }

    public void TraToaDoBanDau()
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    public abstract void HienThiThongTin();
    public abstract void PhatSuKien(NhanVat_ThongTin script);
}
