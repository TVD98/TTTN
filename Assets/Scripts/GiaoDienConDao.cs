using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienConDao : GiaoDien
{
    public static NhanVat_ThongTin nhanVat;
    public static int soLuot = 0;
    public Text soLuotConLai;
    public int phiNghiDuong = 700;
    public GameObject luaChonTraTien;

    public override void CapNhap() { }

    public static void ChonNhanVat(NhanVat_ThongTin nv, int sl)
    {
        nhanVat = nv;
        soLuot = sl;
    }

    public override void LayThongTin()
    {
        audioSource.Play();
        luaChonTraTien.gameObject.SetActive(true);
        if(nhanVat.soTien < phiNghiDuong)
        {
            luaChonTraTien.gameObject.SetActive(false);
        }
        soLuotConLai.text = soLuot.ToString();
    }

    public override void TatHienThi()
    {
        PhaHuy();
    }

    public void TungXucXac()
    {
        TatHienThi();
        nhanVat.main.boXucXac.DoXucXacRoiDao(nhanVat.gameObject.GetComponent<NhanVat_DiChuyen>());
    }

    public void TraTien()
    {
        TatHienThi();
        nhanVat.TruTien(phiNghiDuong);
        nhanVat.suKien = new SuKienDoXucXac();
        nhanVat.main.boXucXac.BatDauDo(nhanVat.gameObject.GetComponent<NhanVat_DiChuyen>());
    }

    public void SuDungTheBai()
    {

    }

    
}
