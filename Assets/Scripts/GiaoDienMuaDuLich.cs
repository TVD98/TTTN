using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienMuaDuLich : GiaoDien
{
    public static KhuNghiDuong nghiDuong;
    public static NhanVat_ThongTin nhanVat;
    public static Sprite backround;

    public Image anhNen;
    public Text ten;
    public Text giamPhi;
    public Text phiMua;

    private int phiXayDung = 350;

    public static void ChonDiaDiem(KhuNghiDuong nD, NhanVat_ThongTin nV, Sprite anhNen)
    {
        nghiDuong = nD;
        nhanVat = nV;
        backround = anhNen;
    }

    public void Mua()
    {
        nhanVat.TruTien(int.Parse(phiMua.text));
        nghiDuong.DoiQuyenSoHuu(nhanVat.stt);
        TatHienThi();
    }

    public override void LayThongTin()
    {
        anhNen.sprite = backround;
        ten.text = nghiDuong.ten;
        giamPhi.text = nhanVat.giamPhiXayDung.ToString();
        phiMua.text = (phiXayDung - (phiXayDung * nhanVat.giamPhiXayDung) / 100).ToString();
    }

    public override void CapNhap()
    {

    }

    public override void TatHienThi()
    {
        PhaHuy();
        nhanVat.KetThucLuot();
    }
}
