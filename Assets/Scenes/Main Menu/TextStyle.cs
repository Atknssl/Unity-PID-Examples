using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextStyle : MonoBehaviour
{
    public void enterHover()
    {
        this.GetComponent<Text>().color = Color.red;
    }

    public void exitHover()
    {
        this.GetComponent<Text>().color = Color.white;
    }
}
