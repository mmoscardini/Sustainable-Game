using UnityEngine;
using System.Collections;

public class OilPlant : PowerPlant {

	public OilPlant ():base(PowerPlantManager.Instance.redResource,PowerPlantManager.Instance.whiteResource,PowerPlantManager.Instance.redTxt, PowerPlantManager.Instance.whiteTxt){
		r1Cost = 4;
		r2Cost = 1;
		energyProduction = 4;
		startPolution = 4;
		turnPolution = 3;
	}
}
