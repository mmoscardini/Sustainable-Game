using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

	public int requiredEnergy;
	public int population;

	void Start (){
		//cada cidadão consome 0,5 de energia. Arredondado para baixo
		requiredEnergy = Mathf.FloorToInt(population * 0.5f);
		CityManager.totalPop += population;
	}

	public void EnergyConsuption (){
		//Se existe energia energia gerada o suficiente para atender a demanda
		//A energia é consumida e a população da cidade cresce igual a metade da energia consumida;
		if (PowerPlant.energy >= requiredEnergy) {
			PowerPlant.energy -= requiredEnergy;


			population += Mathf.FloorToInt (requiredEnergy / 2);
			requiredEnergy += Mathf.FloorToInt (requiredEnergy / 2); 
		}
		//caso não tenha energia disponivel
		//Se existir ao menos 50% da energia necessária, a cidade consome toda a energia e se mantem estavel.
		else if (requiredEnergy > PowerPlant.energy && PowerPlant.energy >= requiredEnergy * 0.5f) {
			PowerPlant.energy = 0;
		}
		//se existir menos de 50% disponivel a cidade perde um quinto da população at
		else if (PowerPlant.energy < requiredEnergy * 0.5f) {
			PowerPlant.energy = 0;
			population -= Mathf.FloorToInt (population / 2);
			requiredEnergy -= Mathf.FloorToInt (requiredEnergy / 2); 


		} else
			Debug.LogError ("A quantidade de energia é negativa");
	}
}
