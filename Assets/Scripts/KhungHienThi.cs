using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TrangThai { SOHUU, DUOCMUA, KHONGDUOCMUA, KHONGDUTIEN }
public class KhungHienThi : MonoBehaviour
{
    // Start is called before the first frame update
    public int loaiHienThi = 1;
    public Toggle danhDau;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HienThi();
    }

    public void HienThi()
    {
        int i = 0;
        foreach (Transform loai in transform)
        {
            if (i == loaiHienThi)
            {
                loai.gameObject.SetActive(true);
            }
            else loai.gameObject.SetActive(false);
            i++;
        }
    }

    public bool TrangThaiDuocMua()
    {
        if (loaiHienThi == 1)
            return true;
        return false;
    }

    public bool TrangThaiKhongDuTien()
    {
        if (loaiHienThi == 2)
            return true;
        return false;
    }

    public bool TrangThaiKhongDuocMua()
    {
        if (loaiHienThi == 3)
            return true;
        return false;
    }

    public void ChuyenTrangThai(TrangThai trangThai)
    {
        if (TrangThaiKhongDuocMua() == false)
        {
            switch (trangThai)
            {
                case TrangThai.DUOCMUA:
                    loaiHienThi = 1;
                    break;
                case TrangThai.SOHUU:
                    loaiHienThi = 0;
                    break;
                case TrangThai.KHONGDUTIEN:
                    if (DauDuocChon() == false)
                        loaiHienThi = 2;
                    break;
                case TrangThai.KHONGDUOCMUA:
                    loaiHienThi = 3;
                    break;
            }
        }
    }

    public void DoiDau(bool dauMoi)
    {
        if (TrangThaiDuocMua())
            danhDau.isOn = dauMoi;
    }

    public bool DauDuocChon()
    {
        return danhDau.isOn;
    }
}
