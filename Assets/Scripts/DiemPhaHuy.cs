using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiemPhaHuy : SuKienChuotTrai
{
    public override void NhanSuKienChuotTrai(DiaDiem diaDiem)
    {
        NhaO nhaO = diaDiem.GetComponent<NhaO>();

        nhaO.PhaHuyNha();

        TheCoHoi.nhanVat.KetThucLuot();
    }

    
}
