using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XucXac : MonoBehaviour
{
    public static bool doXucXac;

    Die_d6 chinhNo;
    Rigidbody rd;
    public GameObject spawnPoint;

    void Start()
    {
        chinhNo = GetComponent<Die_d6>();
        rd = GetComponent<Rigidbody>();

    }

    public void DoXucXac()
    {
        transform.position = spawnPoint.transform.position;
        transform.Rotate(new Vector3(Random.value * 360, Random.value * 360, Random.value * 360));
    }

}


