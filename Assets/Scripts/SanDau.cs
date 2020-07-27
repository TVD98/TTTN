using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KieuThang { KHONG, PHASAN, MOTHANG, BOMAU, DULICH};

public class SanDau : MonoBehaviour
{
    [SerializeField] private GameObject cacODat;
    public int[] danhSachDiaDiemKhu;
    public int[] danhSachDiaDiemHang;
    public int soKhuNghiDuong;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public KieuThang KiemTraThang(int nhanVat)
    {
        int[] danhSachKhuVuc = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] danhSachHang = new int[4] { 0, 0, 0, 0 };
        int soKhuNghiDuong = 0;
        foreach (Transform diaDiem in cacODat.transform)
        {
            NhaO nhaO = diaDiem.GetComponent<NhaO>();
            if (nhaO != null)
            {
                if (nhaO.thuocNguoiChoi == nhanVat)
                {
                    danhSachKhuVuc[nhaO.thuocKhuVuc - 1] += 1;
                    danhSachHang[int.Parse(nhaO.name) / 8]++;
                }
            }
            else
            {
                KhuNghiDuong nghiDuong = diaDiem.GetComponent<KhuNghiDuong>();
                if (nghiDuong != null)
                {
                    if (nghiDuong.thuocNguoiChoi == nhanVat)
                    {
                        soKhuNghiDuong++;
                        danhSachHang[int.Parse(nghiDuong.name) / 8]++;
                    }
                }
            }
        }
        return DieuKienThang(danhSachKhuVuc, danhSachHang, soKhuNghiDuong);
    }

    public KieuThang DieuKienThang(int[] ds, int[] hang, int soKhu)
    {
        if (soKhu == soKhuNghiDuong)
            return KieuThang.DULICH;
        int soKhuVucDayDu = 0;
        for (int i = 0; i < 8; i++)
        {
            if (ds[i] == danhSachDiaDiemKhu[i])
                soKhuVucDayDu++;
        }
        if (soKhuVucDayDu >= 3)
            return KieuThang.BOMAU;
        for (int i = 0; i < 4; i++)
        {
            if (hang[i] == danhSachDiaDiemHang[i])
                return KieuThang.MOTHANG;
        }
        return KieuThang.KHONG;
    }

    public int TaiSan(int sttNguoiChoi)
    {
        int tong = 0;
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                if (duLich.thuocNguoiChoi == sttNguoiChoi)
                    tong += duLich.GiaTriTaiSan();
            }
        }
        return tong;
    }

    public void TraVeMacDinh()
    {
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                duLich.TraToaDoBanDau();
                duLich.suKien = new ThongTinDiaDiem();
            }
            else tam.GetComponent<DiaDiem>().suKien = new ThongTinDiaDiem();
        }
    }

    public void HuyToChucLeHoi()
    {
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                duLich.HuyToChucLeHoi();
            }
        }
    }

    public void HienThiBenXe()
    {
        int i = 0;
        foreach (Transform tam in cacODat.transform)
        {
            DiaDiem diaDiem = tam.GetComponent<DiaDiem>();
            if (i != 24)
                diaDiem.suKien = new DenNoiTuyY();
            else diaDiem.suKien = new KhongLamGi();
            i++;
        }
    }

    public bool HienThiXuatPhat(NhanVat_ThongTin nhanVat)
    {
        int i = 0;
        foreach (Transform tam in cacODat.transform)
        {
            NhaO nhaO = tam.GetComponent<NhaO>();
            if (nhaO != null)
            {
                if (nhaO.thuocNguoiChoi == nhanVat.stt && nhaO.DuocXayTiep(nhanVat) != LoaiXayDung.KHONG)
                {
                    if (nhaO.PhiMuaToiThieu() <= nhanVat.soTien)
                    {
                        i++;
                        nhaO.NangCaoToaDo();
                        nhaO.suKien = new XayDungThem();
                    }
                }
                else nhaO.suKien = new KhongLamGi();
            }
            else tam.GetComponent<DiaDiem>().suKien = new KhongLamGi();
        }
        if (i == 0) return false;
        return true;
    }

    public bool HienThiLeHoi(NhanVat_ThongTin nhanVat)
    {
        int i = 0;
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                if (duLich.thuocNguoiChoi == nhanVat.stt)
                {
                    duLich.suKien = new ToChucLeHoi();
                    duLich.NangCaoToaDo();
                    i++;
                }
                else duLich.suKien = new KhongLamGi();
            }
            else tam.GetComponent<DiaDiem>().suKien = new KhongLamGi();
        }
        if (i == 0) return false;
        return true;
    }

    public void HienThiViTriDoi(NhanVat_ThongTin nhanVat)
    {
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                if (duLich.thuocNguoiChoi == nhanVat.stt && duLich.DuocTanCong())
                {
                    duLich.suKien = new DiemHoanDoi();
                    duLich.NangCaoToaDo();
                }
                else duLich.suKien = new KhongLamGi();
            }
            else tam.GetComponent<DiaDiem>().suKien = new KhongLamGi();
        }
    }

    public void HienThiViTriMuonDoi(NhanVat_ThongTin nhanVat)
    {
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                if (duLich.thuocNguoiChoi != nhanVat.stt && duLich.DuocTanCong())
                {
                    duLich.suKien = new DiemHoanDoi();
                    duLich.NangCaoToaDo();
                }
                else duLich.suKien = new KhongLamGi();
            }
            else tam.GetComponent<DiaDiem>().suKien = new KhongLamGi();
        }
    }

    public bool DuocPhepHoanDoi(NhanVat_ThongTin nhanVat)
    {
        int i = 0;
        int j = 0;
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                if (duLich.thuocNguoiChoi == nhanVat.stt && duLich.DuocTanCong())
                    i++;
                else if (duLich.thuocNguoiChoi != nhanVat.stt && duLich.DuocTanCong())
                    j++;
            }
        }
        if (i > 0 && j > 0) return true;
        return false;
    }

    public bool HienThiTangDat(NhanVat_ThongTin nhanVat)
    {
        int i = 0;
        foreach (Transform tam in cacODat.transform)
        {
            DuLich duLich = tam.GetComponent<DuLich>();
            if (duLich != null)
            {
                if (duLich.thuocNguoiChoi == nhanVat.stt && duLich.DuocTanCong())
                {
                    duLich.suKien = new DatTraoTang();
                    duLich.NangCaoToaDo();
                    i++;
                }
                else duLich.suKien = new KhongLamGi();
            }
            else tam.GetComponent<DiaDiem>().suKien = new KhongLamGi();
        }
        if (i == 0) return false;
        return true;
    }

    public bool HienThiBanNha(NhanVat_ThongTin nhanVat)
    {
        int i = 0;
        foreach (Transform tam in cacODat.transform)
        {
            NhaO nhaO = tam.GetComponent<NhaO>();
            if (nhaO != null)
            {
                if (nhaO.thuocNguoiChoi != nhanVat.stt && nhaO.DuocTanCong())
                {
                    nhaO.suKien = new DiemPhaHuy();
                    nhaO.NangCaoToaDo();
                    i++;
                }
                else nhaO.suKien = new KhongLamGi();
            }
            else tam.GetComponent<DiaDiem>().suKien = new KhongLamGi();
        }
        if (i == 0) return false;
        return true;
    }

    public void PhatAmThanh()
    {
        audioSource.Play();
    }
}
