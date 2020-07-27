using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeHoi : ChucNang
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public static int diaDiemDangCoLeHoi = -1;

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        if (!nhanVat.sanDau.HienThiLeHoi(nhanVat))
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            nhanVat.KetThucLuot();
        }
        else
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
            BangThongBao.ThayDoiNoiDung("Chọn thành phố để tổ chức lễ hội");
        }
    }

}
