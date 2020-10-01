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

    private void Start() {
        PValue.text = pid.GetComponent<BalanceController>().pid.pFactor.ToString();
        IValue.text = pid.GetComponent<BalanceController>().pid.iFactor.ToString();
        DValue.text = pid.GetComponent<BalanceController>().pid.dFactor.ToString();
    }
    private void Update()
    {
        
    }

    public void UpdatePValue()
    {
        if(float.TryParse(this.PValue.text, out float number))
        {
            pid.GetComponent<BalanceController>().pid.pFactor = number;
        }
    }

        public void UpdateIValue()
    {
        if(float.TryParse(this.IValue.text, out float number))
        {
            pid.GetComponent<BalanceController>().pid.iFactor = number;
        }
    }

        public void UpdateDValue()
    {
        if(float.TryParse(this.DValue.text, out float number))
        {
            pid.GetComponent<BalanceController>().pid.dFactor = number;
        }
    }

    public void TogglePIDMenu()
    {
        PIDMenu.SetActive(!PIDMenu.activeSelf);
    }
}
