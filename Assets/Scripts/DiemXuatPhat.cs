using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiemXuatPhat : ChucNang
{
    public SanDau sanDau;
    public Text tangVong;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        if (!sanDau.HienThiXuatPhat(nhanVat))
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            nhanVat.KetThucLuot();
        }
        else
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
            BangThongBao.ThayDoiNoiDung("Chọn thành phố muốn nâng cấp");
        }
    }

    public void TangVong(NhanVat_ThongTin nhanVat)
    {
        nhanVat.soTien += 1000;
        StartCoroutine(ThemTien());
    }

    IEnumerator ThemTien()
    {
        tangVong.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        tangVong.gameObject.SetActive(false);
    }

}
