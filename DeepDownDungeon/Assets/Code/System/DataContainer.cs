using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DataContainer : MonoBehaviour
{
    public static DataContainer Instance;
       

    private void Awake()
    {
        Instance = this;
    }

}
