using UnityEngine;

public enum LoaiXayDung { KHONG, BINHTHUONG, BIEUTUONG }
public class NhaO : DuLich
{
    public int tangGiaNhaO = 1;

    public int giaDatNen;
    public int giaNhaPho;
    public int giaChungCu;
    public int giaKhachSan;
    public int giaBieuTuong;

    public int[] danhSachNha = new int[5] { 0, 0, 0, 0, 0 };
    public int thuocKhuVuc;

    public GameObject giaoDienChuyenNhuong;
    public GameObject giaoDienXayBieuTuong;

    public int phiDuLich = 0;

    public int PhiChuyenNhuong()
    {
        return phiDuLich + (phiDuLich * 10) / 100;
    }

    public void XayDungThemNha(int[] dSThem)
    {
        for (int i = 0; i < 4; i++)
        {
            if (dSThem[i] == 1)
                danhSachNha[i] = dSThem[i];
        }
    }

    public void PhaHuyNha()
    {
        int viTriPha = 0;
        for (int i = 3; i >= 0; i--)
        {
            if (danhSachNha[i] == 1)
            {
                viTriPha = i;
                danhSachNha[i] = 0;
                break;
            }
        }
        int[] dsPhi = DanhSachPhi();
        phiDuLich -= (dsPhi[viTriPha] - ((dsPhi[viTriPha] * 10) / 100));
        Main.LayNhanVat(thuocNguoiChoi).ThemTien(dsPhi[viTriPha]);
        if (viTriPha == 0)
            thuocNguoiChoi = 0;
    }

    private int TongSoNha()
    {
        int tong = 0;
        for (int i = 0; i < 4; i++)
        {
            tong += danhSachNha[i];
        }
        return tong;
    }

    public LoaiXayDung DuocXayTiep(NhanVat_ThongTin nhanVat)
    {
        int soNha = TongSoNha();
        if ((soNha == 4 && danhSachNha[4] == 1) || (soNha == 3 && nhanVat.soVong == 0))
            return LoaiXayDung.KHONG;
        else if (soNha == 4 && danhSachNha[4] == 0)
            return LoaiXayDung.BIEUTUONG;
        return LoaiXayDung.BINHTHUONG;
    }

    public int[] DanhSachPhi()
    {
        int[] danhSachPhi = new int[5];
        danhSachPhi[0] = giaDatNen;
        danhSachPhi[1] = giaNhaPho;
        danhSachPhi[2] = giaChungCu;
        danhSachPhi[3] = giaKhachSan;
        danhSachPhi[4] = giaBieuTuong;
        return danhSachPhi;
    }

    public override int PhiDuLich()
    {
        return phiDuLich * tangGia;
    }

    public override void HienThiHaTang()
    {
        int[] dsHienThi = new int[5] { 0, 0, 0, 0, 0 };
        if (danhSachNha[4] == 1)
        {
            dsHienThi[4] = 1;
        }
        else
        {
            dsHienThi[0] = danhSachNha[0];
            for (int i = 1; i < 4; i++)
            {
                if (danhSachNha[i] == 1)
                {
                    dsHienThi[0] = 0;
                    dsHienThi[i] = 1;
                }
            }
        }
        int dem = 0;
        foreach (Transform item in cacCongTrinh.transform)
        {
            if (dsHienThi[dem] == 0)
                item.gameObject.SetActive(false);
            else item.gameObject.SetActive(true);
            dem++;
        }
    }

    public override void XuLiChuaSoHuu(NhanVat_ThongTin nhanVat)
    {
        GiaoDienMuaNhaO.ChonDiaDiem(GetComponent<NhaO>(), nhanVat);
    }

    public override void XuLiSoHuu(NhanVat_ThongTin nhanVat)
    {
        HienThiGiaoDienMua(nhanVat);
    }

    public override void XuLiKhongSoHuu(NhanVat_ThongTin nhanVat)
    {
        NhanVat_ThongTin nguoiBan = Main.LayNhanVat(thuocNguoiChoi);
        if (nhanVat.soTien >= PhiChuyenNhuong() && danhSachNha[4] == 0)
        {
            GiaoDienChuyenNhuong.ChonDiaDiem(nguoiBan, nhanVat, GetComponent<NhaO>());
            Instantiate(giaoDienChuyenNhuong);
        }
        else
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            nhanVat.KetThucLuot();
        }
    }

    public override int PhiMuaToiThieu()
    {
        int[] dsPhi = DanhSachPhi();
        int phiMuaToiThieu = 0;
        for (int i = 0; i < 5; i++)
        {
            if (danhSachNha[i] == 0)
            {
                return phiMuaToiThieu = dsPhi[i];
            }
        }
        return phiMuaToiThieu;
    }

    public void HienThiGiaoDienMua(NhanVat_ThongTin nhanVat)
    {
        LoaiXayDung loaiXayDung = DuocXayTiep(nhanVat);
        if (loaiXayDung != LoaiXayDung.KHONG)
        {
            if (PhiMuaToiThieu() <= nhanVat.soTien)
            {
                if (loaiXayDung == LoaiXayDung.BINHTHUONG)
                {
                    GiaoDienMuaNhaO.ChonDiaDiem(GetComponent<NhaO>(), nhanVat);
                    Instantiate(giaoDienMua);
                }
                else
                {
                    GiaoDienMuaBieuTuong.ChonDiaDiem(GetComponent<NhaO>(), nhanVat);
                    Instantiate(giaoDienXayBieuTuong);
                }
            }
            else
            {
                audioSource.clip = audioClips[3];
                audioSource.Play();
                nhanVat.KetThucLuot();
            }

        }
        else
        {
            audioSource.clip = audioClips[4];
            audioSource.Play();
            nhanVat.KetThucLuot();
        }
    }

    public override void HienThiThongTin()
    {
        GiaoDienThongTinNhaO.ChonDiaDiem(GetComponent<NhaO>());
    }

    public override int GiaTriTaiSan()
    {
        return PhiChuyenNhuong();
    }

    public new void CapNhapKhungTangGia()
    {
        if (tangGia * tangGiaNhaO == 1)
        {
            khungTangGia.text = "";
        }
        else khungTangGia.text = "X" + (tangGia * tangGiaNhaO).ToString();
    }

    public override bool DuocTanCong()
    {
        if (danhSachNha[4] == 1 || thuocNguoiChoi == 0) return false;
        return true;
    }

    public override void CapNhapQuyenSoHuu()
    {
        
    }
}
