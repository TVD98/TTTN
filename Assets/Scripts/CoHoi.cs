using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoHoi : ChucNang
{
    public TheCoHoi theCoHoi;

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        TheCoHoi.ChonNhanVat(nhanVat);
        theCoHoi.theDuocChon = Random.Range(0, 2);
        Instantiate(theCoHoi);
    }

}
