using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThongTinDiaDiem : SuKienChuotTrai
{
    public override void NhanSuKienChuotTrai(DiaDiem diaDiem)
    {
        if (GiaoDien.daTonTai == false)
        {
            diaDiem.HienThiThongTin();
            Instantiate(diaDiem.giaoDienThongTin);
        }
    }

    // Start is called before the first frame update
}
