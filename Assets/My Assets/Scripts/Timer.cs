using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public static string time;
    public static int sec = 0;
    public static int min = 0;


    void Update()
    {
        sec = Convert.ToInt32(Time.fixedUnscaledTime);
        min = Convert.ToInt32(sec / 60);
        if (min > 9)
        {
            if (Convert.ToInt32(sec & 60) > 9)
                time = min + ":" + sec % 60;
            else
                time = min + ":" + "0" + sec % 60;
        }
        else
        {
            if (Convert.ToInt32(sec & 60) > 9)
                time = "0" + min + ":" + sec % 60;
            else
                time = "0" + min + ":" + "0" + sec % 60;
        }
    }
}
