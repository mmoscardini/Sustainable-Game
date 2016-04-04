using UnityEngine;
using System.Collections;

public class HidroPlant : PowerPlant {


	public HidroPlant ():base(PowerPlantManager.Instance.greenResource,PowerPlantManager.Instance.blueResource,PowerPlantManager.Instance.greenTxt,PowerPlantManager.Instance.blueTxt){
		r1Cost = 1;
		r2Cost = 3;
		energyProduction = 2;
		startPolution = 1;
		turnPolution = 2;
	}
}
