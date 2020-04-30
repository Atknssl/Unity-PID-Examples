using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeLines : MonoBehaviour
{
    public Transform AltitudeLine;
    public int LinesUntilAltitude;
    void Start()
    {
        for (int i = -4; i <= LinesUntilAltitude; i++)
        {
            AltitudeLine.GetChild(0).GetComponent<Text>().text = i.ToString();
            Instantiate(AltitudeLine, new Vector3(0, i, 0), Quaternion.identity).transform.parent = gameObject.transform;
        }
    }
}
