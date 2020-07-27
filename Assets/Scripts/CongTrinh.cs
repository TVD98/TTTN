using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongTrinh : MonoBehaviour
{
    public GameObject[] mai;

    public void DoiMauSac(Material moi)
    {
        foreach (GameObject tam in mai)
        {
            Renderer renderer = tam.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = moi;
            }
            foreach(Transform item in tam.transform)
            {
                item.GetComponent<Renderer>().material = moi;
            }
        }
    }
}
