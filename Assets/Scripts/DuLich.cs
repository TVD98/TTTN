using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DuLich : DiaDiem
{
    public GameObject cacCongTrinh;
    public int thuocNguoiChoi = 0;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public int tangGia = 1;

    public GameObject giaoDienMua;

    public TextMesh khungTangGia;

    void Update()
    {
        CapNhapKhungTangGia();
        HienThiHaTang();
    }

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        KiemTraNhapCu(nhanVat);
    }

    public void KiemTraNhapCu(NhanVat_ThongTin nhanVat)
    {
        if (ChuaDuocSoHuu())
        {
            if (nhanVat.DuTienXayDung(PhiMuaToiThieu()))
            {
                XuLiChuaSoHuu(nhanVat);
                Instantiate(giaoDienMua);
            }
            else
            {
                audioSource.clip = audioClips[3];
                audioSource.Play();
                nhanVat.KetThucLuot();
            }
        }
        else if (nhanVat.stt == thuocNguoiChoi)
        {
            XuLiSoHuu(nhanVat);
        }
        else {
            ThanhToanPhiDuLich(nhanVat);
            XuLiKhongSoHuu(nhanVat);
        }
    }

    public bool ChuaDuocSoHuu()
    {
        if (thuocNguoiChoi == 0)
            return true;
        else return false;
    }

    public void DoiQuyenSoHuu(int nhanVatMoi)
    {
        thuocNguoiChoi = nhanVatMoi;
        Material moi = Main.LayNhanVat(thuocNguoiChoi).mauSac;
        foreach(Transform tam in cacCongTrinh.transform)
        {
            tam.GetComponent<CongTrinh>().DoiMauSac(moi);
        }
        KieuThang kieuThang = GameObject.Find("San Dau").GetComponent<SanDau>().KiemTraThang(nhanVatMoi);
        if (kieuThang != KieuThang.KHONG)
        {
            string nguoiThang = Main.LayNhanVat(nhanVatMoi).ten;
            if (nhanVatMoi == 1) nhanVatMoi = 2;
            else nhanVatMoi = 1;
            string nguoiThua = Main.LayNhanVat(nhanVatMoi).ten;
            Main.KetThucGame(nguoiThang, kieuThang);

            LichSuGame.ThemKetQua(new KetQuanTranDau(nguoiThang, nguoiThua, kieuThang));
        }
        CapNhapQuyenSoHuu();
    }

    public void ThanhToanPhiDuLich(NhanVat_ThongTin nhanVat)
    {
        int phiDuLich = PhiDuLich();
        NhanVat_ThongTin nhanVatSoHuu = Main.LayNhanVat(thuocNguoiChoi);
        nhanVatSoHuu.ThemTien(phiDuLich);
        nhanVat.TruTien(phiDuLich);
    }

    public void CapNhapKhungTangGia()
    {
        if (tangGia == 1)
        {
            khungTangGia.text = "";
        }
        else khungTangGia.text = "X" + tangGia.ToString();
    }

    public void ToChucLeHoi()
    {
        if (tangGia != 5)
            tangGia++;
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void HuyToChucLeHoi()
    {
        tangGia = 1;
    }


    public abstract int PhiMuaToiThieu();
    public abstract int PhiDuLich();
    public abstract void HienThiHaTang();
    public abstract void XuLiChuaSoHuu(NhanVat_ThongTin nhanVat);
    public abstract void XuLiSoHuu(NhanVat_ThongTin nhanVat);
    public abstract void XuLiKhongSoHuu(NhanVat_ThongTin nhanVat);
    public abstract int GiaTriTaiSan();
    public abstract bool DuocTanCong();
    public abstract void CapNhapQuyenSoHuu();

}
