using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVat_ThongTin : MonoBehaviour
{
    public string ten;
    public Material mauSac;
    public int stt;
    public int soVong = 0;
    public int soTien = 4000;
    public int soMang = 1;

    public ThongTinNhatVat thongTin;

    public int giamPhiXayDung = 0;

    public Main main;
    public SanDau sanDau;
    public GameObject danhDau;
    public GameObject trongLuot;

    public SuKienBatDau suKien;

    void Start()
    {
        suKien = new SuKienDoXucXac();
    }

    public bool DuTienXayDung(int soTienXayDung)
    {
        soTienXayDung = soTienXayDung - (soTienXayDung * giamPhiXayDung) / 100;
        if (soTienXayDung <= soTien)
            return true;
        return false;
    }

    public void ThemTien(int tien)
    {
        soTien += tien;
        thongTin.ThemTien(tien);
    }

    public void TruTien(int tien)
    {
        soTien -= tien;
        thongTin.TruTien(tien);
        if(soTien < 0)
        {
            if (soMang == 0)
            {
                int nguoiThang = 1;
                if (nguoiThang == stt) nguoiThang = 2;
                Main.KetThucGame(Main.LayNhanVat(nguoiThang).ten, KieuThang.PHASAN);
            }
            else
            {
                soTien = 0;
                soMang--;
            }
        }
    }

    public void BatDauLuot()
    {
        if (Main.ketThuc == false)
        {
            DanhDau(true);
            sanDau.TraVeMacDinh();
            suKien.PhatSuKien(GetComponent<NhanVat_ThongTin>());
        }
    }

    public void KetThucLuot()
    {
        StartCoroutine(Delay());
    }

    public void DanhDau(bool dau)
    {
        danhDau.gameObject.SetActive(dau);
        trongLuot.gameObject.SetActive(dau);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        BangThongBao.ThayDoiNoiDung("");
        sanDau.TraVeMacDinh();
        DanhDau(false);
        BoXucXac.tatHienThi = true;
        NhanVat_DiChuyen nhanVat = gameObject.GetComponent<NhanVat_DiChuyen>();
        if (nhanVat.themLuot)
        {
            nhanVat.themLuot = false;
            BatDauLuot();
        }
        else
            main.ThayDoiLuot();
    }



}
