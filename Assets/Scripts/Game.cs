using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : ChucNang
{
    public GameObject giaoDienChoiGame;

    public override void PhatSuKien(NhanVat_ThongTin nhanVat)
    {
        GiaoDienChoiGame.ChonNhanVat(nhanVat);
        Instantiate(giaoDienChoiGame);
    }


}
