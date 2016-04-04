using UnityEngine;
using System.Collections;

public class GasPlant : PowerPlant {


	public GasPlant ():base(PowerPlantManager.Instance.redResource,PowerPlantManager.Instance.greenResource,PowerPlantManager.Instance.redTxt,PowerPlantManager.Instance.greenTxt){
		r1Cost = 1;
		r2Cost = 3;
		energyProduction = 2;
		startPolution = 0;
		turnPolution = 3;
	}
}
