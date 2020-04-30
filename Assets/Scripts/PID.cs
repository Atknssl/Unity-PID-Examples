[System.Serializable]
public class PID
{
	public float pFactor, iFactor, dFactor;

	private float _integral;
	private float _lastError;
	public PID(float pFactor, float iFactor, float dFactor)
	{
		this.pFactor = pFactor;
		this.iFactor = iFactor;
		this.dFactor = dFactor;
	}
	public float Update(float target, float current, float deltatime)
	{
		float error = target - current;
		_integral += error * deltatime;
		float derivative = (error - _lastError) / deltatime;
		_lastError = error;
		return error * pFactor + _integral * iFactor + derivative * dFactor;
	}
	public void LimitIntegral(float value)
	{
		if (_integral >= value)
		{
			_integral = value;
		}
		if (_integral <= -value)
		{
			_integral = -value;
		}
	}
}