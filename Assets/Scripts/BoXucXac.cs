using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoXucXac : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public XucXac xucXac0;
    public XucXac xucXac1;

    public static bool tatHienThi = false;
    public static bool duocDoXucXac = true;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && duocDoXucXac && Main.sanSanBatDau)
        {
            duocDoXucXac = false;
            BangThongBao.ThayDoiNoiDung("");
            NhanVat_DiChuyen nhanVat = Main.LayNhanVat(Main.stt + 1).gameObject.GetComponent<NhanVat_DiChuyen>();
            BatDauDo(nhanVat);
        }
        if (tatHienThi)
        {
            TatHienThi();
            tatHienThi = false;
        }
    }

    public void TatHienThi()
    {
        foreach (Transform tam in transform)
        {
            tam.gameObject.SetActive(false);
        }
    }

    public void BatHienThi()
    {
        foreach (Transform tam in transform)
        {
            tam.gameObject.SetActive(true);
        }
    }

    public void BatDauDo(NhanVat_DiChuyen nhanVat)
    {
        StartCoroutine(DoBoXucXac(nhanVat));
    }

    public void DoXucXacRoiDao(NhanVat_DiChuyen nhanVat)
    {
        StartCoroutine(DoBoXucXacRoiDao(nhanVat));
    }

    public void GieoXucXac()
    {
        BatHienThi();
        xucXac0.DoXucXac();
        xucXac1.DoXucXac();
    }

    IEnumerator DoBoXucXac(NhanVat_DiChuyen nhanVat)
    {
        KetQuaXucXac ketQua = null;
        do
        {
            GieoXucXac();
            yield return new WaitForSeconds(3f);
            ketQua = KiemTraKetQua();
        } while (ketQua == null);

        PhatAmThanhSoNut(ketQua.soNut);
        nhanVat.viTriKetThuc = Main.TimViTriKetThuc(nhanVat.viTriHienTai, ketQua.soNut);
        if (ketQua.doDoi)
        {
            PhatAmThanhDoDoi();
            BangThongBao.ThayDoiNoiDung("Đổ đôi");
            nhanVat.themLuot = true;
        }
        nhanVat.diChuyen = true;
    }

    IEnumerator DoBoXucXacRoiDao(NhanVat_DiChuyen nhanVat)
    {
        KetQuaXucXac ketQua = null;
        do
        {
            GieoXucXac();
            yield return new WaitForSeconds(3f);
            ketQua = KiemTraKetQua();
        } while (ketQua == null);

        PhatAmThanhSoNut(ketQua.soNut);
        nhanVat.viTriKetThuc = Main.TimViTriKetThuc(nhanVat.viTriHienTai, ketQua.soNut);
        NhanVat_ThongTin nhanVatThongTin = nhanVat.gameObject.GetComponent<NhanVat_ThongTin>();
        if (ketQua.doDoi)
        {
            PhatAmThanhDoDoi();
            BangThongBao.ThayDoiNoiDung("Đổ đôi");
            nhanVat.viTriKetThuc = Main.TimViTriKetThuc(nhanVat.viTriHienTai, ketQua.soNut);
            nhanVatThongTin.suKien = new SuKienDoXucXac();
            nhanVat.diChuyen = true;
        }
        else
        {
            nhanVatThongTin.main.boXucXac.TatHienThi();
            nhanVatThongTin.KetThucLuot();
        }
    }

    public KetQuaXucXac KiemTraKetQua()
    {
        Die_d6 xx0 = xucXac0.gameObject.GetComponent<Die_d6>();
        Die_d6 xx1 = xucXac1.gameObject.GetComponent<Die_d6>();
        if (xx0.value == 0 || xx1.value == 0)
            return null;
        if (xx0.value == xx1.value)
            return new KetQuaXucXac(true, xx0.value + xx1.value);
        return new KetQuaXucXac(false, xx0.value + xx1.value);
    }

    public void PhatAmThanhSoNut(int soNut)
    {
        audioSource.clip = audioClips[soNut - 2];
        audioSource.Play();
    }

    public void PhatAmThanhDoDoi()
    {
        audioSource.clip = audioClips[11];
        audioSource.Play();
    }
}

public class KetQuaXucXac
{
    public bool doDoi;
    public int soNut;

    public KetQuaXucXac(bool doDoi, int soNut)
    {
        this.doDoi = doDoi;
        this.soNut = soNut;
    }
}
