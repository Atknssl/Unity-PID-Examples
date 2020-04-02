[System.Serializable]
public class PID {
	public float pFactor, iFactor, dFactor;
		
	float integral;
	float lastError;
	
	
	public PID(float pFactor, float iFactor, float dFactor) {
		this.pFactor = pFactor;
		this.iFactor = iFactor;
		this.dFactor = dFactor;
	}
	
	
	public float Update(float target, float current, float deltatime) {
		float error = target - current;
		integral += error * deltatime;
		float derivative = (error - lastError) / deltatime;
		lastError = error;
		return error * pFactor + integral * iFactor + derivative * dFactor;
	}
}
