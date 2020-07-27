using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thue : ChucNang
{
    public GameObject giaoDienThuThue;

    public int phanTramThue = 10;

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        int taiSan = nhanVat.sanDau.TaiSan(nhanVat.stt);
        int tamTinh = (taiSan * phanTramThue) / 100;
        if (tamTinh <= nhanVat.soTien && tamTinh != 0)
        {
            GiaoDienThuThue.ChonNhanVat(nhanVat, tamTinh);
            Instantiate(giaoDienThuThue);
        }
        else
        {
            if (tamTinh > 0)
                nhanVat.TruTien(tamTinh);
            nhanVat.KetThucLuot();
        }
    }

}
