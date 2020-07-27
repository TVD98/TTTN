using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XayDungThem : SuKienChuotTrai
{
    public override void NhanSuKienChuotTrai(DiaDiem diaDiem)
    {
        NhaO nhaO = (NhaO)diaDiem;
        NhanVat_ThongTin nhanVat = Main.LayNhanVat(nhaO.thuocNguoiChoi).GetComponent<NhanVat_ThongTin>();
        nhaO.XuLiSoHuu(nhanVat);
    }

    
}
