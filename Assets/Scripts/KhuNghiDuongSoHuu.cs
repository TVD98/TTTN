using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhuNghiDuongSoHuu : KhuNghiDuong
{
    public int soKhuSoHuu = 0;
    public KhuNghiDuongSoHuu[] danhSach;

    public override void XuLiSoHuu(NhanVat_ThongTin nhanVat)
    {
        nhanVat.KetThucLuot();
    }

    public override void XuLiKhongSoHuu(NhanVat_ThongTin nhanVat)
    {
        nhanVat.KetThucLuot();
    }

    public void CapNhapSoHuu()
    {
        int soKhu = 0;
        foreach(KhuNghiDuongSoHuu dl in danhSach)
        {
            if(thuocNguoiChoi == dl.thuocNguoiChoi && thuocNguoiChoi != 0)
            {
                soKhu++;
            }
        }
        soKhuSoHuu = soKhu;
	giaTri = soKhuSoHuu;
    }

    public override void CapNhapQuyenSoHuu()
    {
        foreach (KhuNghiDuongSoHuu dl in danhSach)
        {
            dl.CapNhapSoHuu();
        }
    }
}
