using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChucNang : DiaDiem
{
    public Sprite sprite;
    
    public override void HienThiThongTin()
    {
        GiaoDienThongTinCN.ChonDiaDiem(GetComponent<ChucNang>());
    }


}
