using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThongTinNhatVat : MonoBehaviour
{
    public Text tienMat;
    public Text taiSan;
    public Text ten;
    public Text thayDoi;

    public NhanVat_ThongTin nhanVat;

    void Start()
    {
        ten.text = nhanVat.ten.ToString();
    }

    void Update()
    {
        tienMat.text = nhanVat.soTien.ToString();
        CapNhapTaiSan();
    }

    public void CapNhapTaiSan()
    {
        taiSan.text = nhanVat.sanDau.TaiSan(nhanVat.stt).ToString();
    }

    public void ThemTien(int tien)
    {
        StartCoroutine(HienThiThayDoi(tien));
    }

    public void TruTien(int tien)
    {
        StartCoroutine(HienThiThayDoi(-tien));
    }

    IEnumerator HienThiThayDoi(int tien)
    {
        if (tien > 0)
            thayDoi.text = "+" + tien.ToString();
        else
            thayDoi.text = tien.ToString();
        yield return new WaitForSeconds(1f);
        thayDoi.text = "";
    }
}
