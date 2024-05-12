using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCount : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("point", 0);
    }

}
