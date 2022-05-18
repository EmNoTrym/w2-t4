using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class Clock : MonoBehaviour
{
    private float secDegree;
    private float minDegree;
    private float hourDegree;

    public GameObject hour;
    public GameObject min;
    public GameObject sec;
    public float additionalHour;

    public bool isSmooth = false;

    void Update()
    {
        if (!isSmooth)
        {
            secDegree = -(DateTime.Now.Second / 60f) * 360;
            minDegree = -(DateTime.Now.Minute / 60f) * 360;

            sec.transform.rotation = Quaternion.Euler(new Vector3(0, 0, secDegree));
            min.transform.rotation = Quaternion.Euler(new Vector3(0, 0, minDegree));
            
        }
        
        else if (isSmooth)
        {
            secDegree = -((DateTime.Now.Second + DateTime.Now.Millisecond / 1000f) / 60f) * 360;       
            minDegree = -((DateTime.Now.Minute + DateTime.Now.Second / 60f) / 60f) * 360;

            min.transform.rotation = Quaternion.Euler(new Vector3(0, 0, minDegree));
            sec.transform.rotation = Quaternion.Euler(new Vector3(0, 0, secDegree));
        }

        hourDegree = -((DateTime.Now.Hour + additionalHour) / 12f) * 360;
        hour.transform.rotation = Quaternion.Euler(new Vector3(0, 0, hourDegree));
    }

    public void ChangeIsSmooth()
    {
        
        isSmooth = !isSmooth;
    }
}
