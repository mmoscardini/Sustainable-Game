using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerPlant : MonoBehaviour {

	public Resources recurso1 { get; protected set; }
	public Resources recurso2 { get; protected set; }
	public Text r1Txt { get; protected set; }
	public Text r2Txt { get; protected set; }

	public int energyProduction { get; protected set; }
	public int r1Cost { get; protected set; }
	public int r2Cost { get; protected set; }
	public int startPolution { get; protected set; }
	public int turnPolution { get; protected set; }

	public float generateEnergyTimer = 0f;
	public static int energy;

	//criar nova instancia de usina
	//Adicioná-la ao array de usinas ativas
	public PowerPlant (Resources r1, Resources r2, Text _r1Txt, Text _r2Txt){
		recurso1 = r1;
		recurso2 = r2;
		r1Txt = _r1Txt;
		r2Txt = _r2Txt;
	}

	//a cada 10s  - definido na função ActivatePowerPlant no PP Manager
	public void GenerateEnergyAndImpacts (){
		//Usar math.floor para tudo é pessimo. Faz de um jeito melhor
		//Conferir se os recursos são maiores que zero onde a função é inicialmente chamada - PowerPlantManager)
		if (recurso1.available >= Mathf.FloorToInt (r1Cost / 2) && recurso2.available >= Mathf.FloorToInt (r2Cost / 2)) {
			recurso1.ReduceAvailable (Mathf.FloorToInt (r1Cost / 2));
			recurso2.ReduceAvailable (Mathf.FloorToInt (r2Cost / 2));

			energy += energyProduction;
			PolutionManager.PolutionRate += turnPolution;
		}
	}
}
