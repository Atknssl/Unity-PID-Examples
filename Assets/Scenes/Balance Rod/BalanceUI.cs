using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BalanceUI : MonoBehaviour
{
    public GameObject PIDMenu;
    public GameObject pid;
    public InputField PValue;
    public InputField IValue;
    public InputField DValue;
    public InputField HoldAngle;
    public InputField Throttle;

    private void Start() {
        PValue.text = pid.GetComponent<BalanceController>().pid.pFactor.ToString();
        IValue.text = pid.GetComponent<BalanceController>().pid.iFactor.ToString();
        DValue.text = pid.GetComponent<BalanceController>().pid.dFactor.ToString();
        Throttle.text = pid.GetComponent<BalanceController>().Throttle.ToString();
        HoldAngle.text = pid.GetComponent<BalanceController>().angle.ToString();

    }
    public void UpdateHoldAngle()
    {
        if(float.TryParse(this.HoldAngle.text, out float number))
        {
            pid.GetComponent<BalanceController>().angle = number;
        }
        else
        {
            this.HoldAngle.text = pid.GetComponent<BalanceController>().angle.ToString();
        }
    }
    public void UpdateThrottle()
    {
        if(float.TryParse(this.Throttle.text, out float number))
        {
            //Throttle is between 0 and 1
            if(number > 1)
            {
                this.Throttle.text = "1";
                number = 1;
            }
            else if(number < 0)
            {
                this.Throttle.text = "0";
                number = 0;
            }
            pid.GetComponent<BalanceController>().Throttle = number;
        }
        else
        {
            this.Throttle.text = pid.GetComponent<BalanceController>().Throttle.ToString();
        }
    }

    public void UpdatePValue()
    {
        if(float.TryParse(this.PValue.text, out float number))
        {
            pid.GetComponent<BalanceController>().pid.pFactor = number;
        }
        else
        {
            this.PValue.text = pid.GetComponent<BalanceController>().pid.pFactor.ToString();
        }
    }

        public void UpdateIValue()
    {
        if(float.TryParse(this.IValue.text, out float number))
        {
            pid.GetComponent<BalanceController>().pid.iFactor = number;
        }
        else
        {
            this.IValue.text = pid.GetComponent<BalanceController>().pid.iFactor.ToString();
        }
    }

        public void UpdateDValue()
    {
        if(float.TryParse(this.DValue.text, out float number))
        {
            pid.GetComponent<BalanceController>().pid.dFactor = number;
        }
        else
        {
            this.DValue.text = pid.GetComponent<BalanceController>().pid.dFactor.ToString();
        }
    }

    public void TogglePIDMenu()
    {
        PIDMenu.SetActive(!PIDMenu.activeSelf);
    }
}
