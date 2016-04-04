using UnityEngine;
using System.Collections;

public class EolicaPlant : PowerPlant {


	public EolicaPlant ():base(PowerPlantManager.Instance.blueResource,PowerPlantManager.Instance.whiteResource,PowerPlantManager.Instance.blueTxt,PowerPlantManager.Instance.whiteTxt){
		r1Cost = 2;
		r2Cost = 2;
		energyProduction = 1;
		startPolution = 1;
		turnPolution = 1;
	}

}
