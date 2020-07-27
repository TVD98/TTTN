using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KhuNghiDuong : DuLich
{
    public int phiMua = 350;
    public int giaTri = 1;
    public int[] danhSachPhi = new int[3] { 280, 560, 1120 };
    public Sprite anhNen;
    public Sprite backround;

    public override void HienThiHaTang()
    {
        if (thuocNguoiChoi != 0)
        {
            int i = 1;
            foreach (Transform tam in cacCongTrinh.transform)
            {
                if (i == giaTri) tam.gameObject.SetActive(true);
                else tam.gameObject.SetActive(false);
                i++;
            }
        }
    }

    public override int PhiDuLich()
    {
        if (ChuaDuocSoHuu())
            return 0;
        return danhSachPhi[giaTri - 1] * tangGia;
    }

    public override int PhiMuaToiThieu()
    {
        return phiMua;
    }

    public override void XuLiChuaSoHuu(NhanVat_ThongTin nhanVat)
    {
        GiaoDienMuaDuLich.ChonDiaDiem(GetComponent<KhuNghiDuong>(), nhanVat, anhNen);
    }

    public override void HienThiThongTin()
    {
        GiaoDienThongTinKND.ChonDiaDiem(GetComponent<KhuNghiDuong>(), backround);
    }

    public override int GiaTriTaiSan()
    {
        return phiMua;
    }

    public override bool DuocTanCong()
    {
        if (thuocNguoiChoi != 0)
            return true;
        return false;
    }

}
