using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Globalization;

public class AltitudeUI : MonoBehaviour
{
    public GameObject PIDMenu;
    public GameObject VerticalMenu;
    public GameObject AltLines;
    public GameObject Info;
    public GameObject rod;
    public InputField PValue;
    public InputField IValue;
    public InputField DValue;
    public InputField ILimit;
    public InputField AsValue;
    public InputField DesValue;
    public InputField TarAlt;
    public Toggle AltToggle;
    public Text Speed;
    public Text Altitude;
    public Text Error;


    void Start()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

        PValue.text = rod.GetComponent<AltitudeController>().pid.pFactor.ToString();
        IValue.text = rod.GetComponent<AltitudeController>().pid.iFactor.ToString();
        DValue.text = rod.GetComponent<AltitudeController>().pid.dFactor.ToString();
        ILimit.text = rod.GetComponent<AltitudeController>().integralLimit.ToString();
        AsValue.text = rod.GetComponent<AltitudeController>().ascendMaxSpeed.ToString();
        DesValue.text = rod.GetComponent<AltitudeController>().descendMaxSpeed.ToString();
        TarAlt.text = rod.GetComponent<AltitudeController>().altitude.ToString();
    }

    private void Update() {
        Speed.text = rod.GetComponent<AltitudeController>().verticalSpeed.ToString("0.000");
        Altitude.text = rod.GetComponent<Transform>().position.y.ToString("0.000");
        Error.text = (rod.GetComponent<AltitudeController>().altitude - rod.GetComponent<Transform>().position.y).ToString("0.000");
    }

    public void UpdateTarget()
    {
        if(float.TryParse(this.TarAlt.text, out float number))
        {
            rod.GetComponent<AltitudeController>().altitude = number;
        }
        else
        {
            this.TarAlt.text = rod.GetComponent<AltitudeController>().altitude.ToString();;
        }
    }
    public void UpdateAsSpeed()
    {
        if(float.TryParse(this.AsValue.text, out float number))
        {
            rod.GetComponent<AltitudeController>().ascendMaxSpeed = number;
        }
        else
        {
            this.AsValue.text = rod.GetComponent<AltitudeController>().ascendMaxSpeed.ToString();;
        }
    }
    public void UpdateDesSpeed()
    {
        if(float.TryParse(this.DesValue.text, out float number))
        {
            rod.GetComponent<AltitudeController>().descendMaxSpeed = number;
        }
        else
        {
            this.DesValue.text = rod.GetComponent<AltitudeController>().descendMaxSpeed.ToString();;
        }
    }
    public void UpdateILimit()
    {
        if(float.TryParse(this.ILimit.text, out float number))
        {
            rod.GetComponent<AltitudeController>().integralLimit = number;
        }
        else
        {
            this.ILimit.text = rod.GetComponent<AltitudeController>().integralLimit.ToString();;
        }
    }
    public void UpdatePValue()
    {
        if(float.TryParse(this.PValue.text, out float number))
        {
            rod.GetComponent<AltitudeController>().pid.pFactor = number;
        }
        else
        {
            this.PValue.text = rod.GetComponent<AltitudeController>().pid.pFactor.ToString();
        }
    }

        public void UpdateIValue()
    {
        if(float.TryParse(this.IValue.text, out float number))
        {
            rod.GetComponent<AltitudeController>().pid.iFactor = number;
        }
        else
        {
            this.IValue.text = rod.GetComponent<AltitudeController>().pid.iFactor.ToString();
        }
    }

        public void UpdateDValue()
    {
        if(float.TryParse(this.DValue.text, out float number))
        {
            rod.GetComponent<AltitudeController>().pid.dFactor = number;
        }
        else
        {
            this.DValue.text = rod.GetComponent<AltitudeController>().pid.dFactor.ToString();
        }
    }
    public void ToggleAltLines()
    {
        AltLines.SetActive(AltToggle.isOn);
    }
    public void TogglePIDMenu()
    {
        PIDMenu.SetActive(!PIDMenu.activeSelf);
    }

    public void ToggleVerticalMenu()
    {
        VerticalMenu.SetActive(!VerticalMenu.activeSelf);
    }

    public void ToggleInfoMenu()
    {
        Info.SetActive(!Info.activeSelf);
    }
}
