using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    public int hour { get; private set; }
    public int minute { get; private set; }

    public float timeSpeed = 5;
   
    float sec = 0;
    private void Start()
    {
        SetWatch(12, 00);
    }

    private void Update()
    {
        Timer();
    }


    public void SetWatch(int h, int m)
    {
        hour = h;
        minute = m;
    }

    private void Timer()
    {
        sec += Time.time * timeSpeed;

        if (sec > 59)
        {
            minute++;
            sec = 0;
        }

        if (minute > 59)
        {
            hour++;
            minute = 0;
        }

        if (hour >= 23 && minute >= 59)
            SetWatch(00, 00);
    }





}
