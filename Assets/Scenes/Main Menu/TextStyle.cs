using System.Threading;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TextStyle : MonoBehaviour
{
    private void Start()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
    }
    public void enterHover()
    {
        this.GetComponent<Text>().color = Color.red;
    }

    public void exitHover()
    {
        this.GetComponent<Text>().color = Color.white;
    }
}
