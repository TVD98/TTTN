using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatTraoTang : SuKienChuotTrai
{
    public override void NhanSuKienChuotTrai(DiaDiem diaDiem)
    {
        DuLich duLich = diaDiem.GetComponent<DuLich>();

        int nguoiChoiDuocTang = TheCoHoi.nhanVat.stt + 1;
        if (nguoiChoiDuocTang == 3)
            nguoiChoiDuocTang = 1;
        duLich.DoiQuyenSoHuu(nguoiChoiDuocTang);
        TheCoHoi.nhanVat.KetThucLuot();
    }

    
}
