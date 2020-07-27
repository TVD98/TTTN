using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiaoDienMuaNhaO : GiaoDien
{
    public static NhaO nhaO;
    public static NhanVat_ThongTin nhanVat;

    public Text ten;
    public Text phiXayDung;
    public Text giamPhi;
    public Text phiDuLich;
    public Text phiMua;

    public Button buttonMua;

    public Text[] danhSachPhi;

    public KhungHienThi[] khungHienThi;

    public int[] danhSachChon;


    public static void ChonDiaDiem(NhaO nOScript, NhanVat_ThongTin nVTTScript)
    {
        nhaO = nOScript;
        nhanVat = nVTTScript;
    }

    public override void LayThongTin()
    {
        audioSource.Play();
        danhSachChon = new int[4] { 0, 0, 0, 0 };
        ten.text = nhaO.ten;
        giamPhi.text = nhanVat.giamPhiXayDung.ToString();
        int i = 0;
        int[] tam = nhaO.DanhSachPhi();
        foreach (Text text in danhSachPhi)
        {
            text.text = tam[i].ToString();
            i++;
        }
        HienThiKhung();
    }

    public override void CapNhap()
    {
        CapNhapPhiText();
        CapNhapDanhSachChon();
        KiemTraDatNen();
        CapNhapKhung();
    }

    public void CapNhapPhiText()
    {
        int phiXD = 0;
        int[] tam = nhaO.DanhSachPhi();
        for (int i = 0; i < 4; i++)
        {
            phiXD += danhSachChon[i] * tam[i];
        }

        phiXayDung.text = phiXD.ToString();
        phiDuLich.text = (nhaO.PhiDuLich() + phiXD - (phiXD * 10) / 100).ToString();
        phiMua.text = (phiXD - (phiXD * nhanVat.giamPhiXayDung) / 100).ToString();
        CapNhapButtonMua();
    }

    public void HienThiKhung()
    {
        int[] tam = nhaO.danhSachNha;
        int phiXD = 0;
        if (nhanVat.soVong == 0) khungHienThi[3].ChuyenTrangThai(TrangThai.KHONGDUOCMUA);
        for (int i = 0; i < 4; i++)
        {
            if (tam[i] == 0)
            {
                khungHienThi[i].ChuyenTrangThai(TrangThai.DUOCMUA);
                phiXD += nhaO.DanhSachPhi()[i];
                if (nhanVat.DuTienXayDung(phiXD) == true)
                    khungHienThi[i].DoiDau(true);
            }
            else khungHienThi[i].ChuyenTrangThai(TrangThai.SOHUU);
        }
    }

    public void CapNhapKhung()
    {
        int[] tam = nhaO.DanhSachPhi();
        int phiXD = int.Parse(phiXayDung.text);
        for (int i = 0; i < 4; i++)
        {
            if (khungHienThi[i].TrangThaiDuocMua() || khungHienThi[i].TrangThaiKhongDuTien())
            {
                if (nhanVat.DuTienXayDung(phiXD + tam[i]) == false)
                    khungHienThi[i].ChuyenTrangThai(TrangThai.KHONGDUTIEN);
                else khungHienThi[i].ChuyenTrangThai(TrangThai.DUOCMUA);
            }
        }
    }

    public void KiemTraDatNen()
    {
        if(khungHienThi[0].TrangThaiDuocMua() && khungHienThi[0].DauDuocChon() == false)
        {
            for(int i = 1; i < 4; i++)
            {
                khungHienThi[i].DoiDau(false);
            }
        }
    }

    public void CapNhapDanhSachChon()
    {
        for (int i = 0; i < 4; i++)
        {
            if (khungHienThi[i].DauDuocChon())
                danhSachChon[i] = 1;
            else danhSachChon[i] = 0;
        }
    }

    public void Mua()
    {
        nhaO.XayDungThemNha(danhSachChon);
        if (nhaO.thuocNguoiChoi != nhanVat.stt)
        {
            nhaO.DoiQuyenSoHuu(nhanVat.stt);
        }
        nhaO.phiDuLich = int.Parse(phiDuLich.text);
        int phiMuaNha = int.Parse(phiMua.text);
        nhanVat.TruTien(phiMuaNha);

        TatHienThi();
    }

    public override void TatHienThi()
    {
        PhaHuy();
        nhanVat.KetThucLuot();
    }

    public void CapNhapButtonMua()
    {
        if(phiMua.text == "0")
        {
            buttonMua.interactable = false;
        }
        else buttonMua.interactable = true;
    }
}
