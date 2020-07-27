using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhuNghiDuongThamQuan : KhuNghiDuong
{
    public int soLanThamQuan = 1;

    public void TangSoLanThamQuan()
    {
        if (soLanThamQuan < 3) soLanThamQuan++;
        giaTri = soLanThamQuan;
    }

    public override void XuLiKhongSoHuu(NhanVat_ThongTin nhanVat)
    {
        TangSoLanThamQuan();
        nhanVat.KetThucLuot();
    }

    public override void XuLiSoHuu(NhanVat_ThongTin nhanVat)
    {
        TangSoLanThamQuan();
        nhanVat.KetThucLuot();
    }

    public override void CapNhapQuyenSoHuu()
    {

    }
}
