using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerPlantManager : MonoBehaviour {

	public static PowerPlantManager Instance { get; protected set;}
	//Textos Recursos
	public Text redTxt,greenTxt,blueTxt,whiteTxt;
	//Texto Polição e energia
	public Text polutionUI, availableEnergy; 

	//Ṕool de recursos
	[HideInInspector]
	public Resources redResource, greenResource, blueResource, whiteResource;

	//Usinas ativas imgs
	public GameObject pp01, pp02, pp03, pp04,pp05;
	public Sprite oilPP, gasPP, hidroPP, eolicaPP;

	List<GameObject> PowerPlantGOList;
	List<PowerPlant> activePowerPlants;

	public static float gameloopTimer = 1f;



	void Start(){
		//Criar apenas uma instancia do PPManager
		if (Instance != null) {
			GameObject.Destroy (Instance);
		} 
		else
			Instance = this;


		//crie novos objetos Recurso
		redResource = new Resources ((int)Resources.Type.red, 120, redTxt, 0);
		greenResource = new Resources ((int)Resources.Type.green, 50, greenTxt, 10);
		blueResource = new Resources ((int)Resources.Type.blue, 60, blueTxt, 11);
		whiteResource = new Resources ((int)Resources.Type.white, 40, whiteTxt, 15);
		//Setup UI Recursos
		SetupResources (redResource);
		SetupResources (greenResource);
		SetupResources (blueResource);
		SetupResources (whiteResource);

		//Nova lista de gameObjects onde as usinas são alocadas
		PowerPlantGOList = new List<GameObject>();
		PowerPlantGOList.Add (pp01);
		PowerPlantGOList.Add (pp02);
		PowerPlantGOList.Add (pp03);
		PowerPlantGOList.Add (pp04);
		PowerPlantGOList.Add (pp05);

		//Lista com as usinas ativas
		activePowerPlants = new List<PowerPlant>();
	}

	void Update(){
		//Aumento natural de recursos
		//O recurso vermelho não aumenta com o passar do tempo
		NaturalResiliance (greenResource, 9);
		NaturalResiliance (blueResource, 12);
		NaturalResiliance (whiteResource, 10);

		//Para cada usina ativa gere energia e poluição
		foreach (PowerPlant pp in activePowerPlants) {
			ActivatePowerPlant (pp);
		}
		//Checar se o marcador de poluição passou de 20. Caso tenha passado aumentar
		if (PolutionManager.PolutionRate >= gameloopTimer ){
			PolutionManager.PolutionOverload ();
			PolutionManager.PolutionRate = 0;
		}

		//Display energia e poluição na UI
		polutionUI.text = PolutionManager.PolutionRate.ToString();
		availableEnergy.text = PowerPlant.energy.ToString ();


	}

	//Criar instancia da Usina de Oleo. Adicionar usina na UI
	public void CreateOilPP(){
		//Se existirem slots disponibeis
		for (int i = 0; i < PowerPlantGOList.Count; i++) {
			if (PowerPlantGOList [i].activeSelf == false) {
				
				//Criar novo objeto Usina
				PowerPlant newpp = new OilPlant();
				//Se existem recursos disponiveis, remover recursos, criar UI do objeto
				if (CheckResourcesAvailable(redResource,newpp.r1Cost) && CheckResourcesAvailable (whiteResource, newpp.r2Cost)){
					redResource.ReduceAvailable (newpp.r1Cost);
					whiteResource.ReduceAvailable (newpp.r2Cost);

					PowerPlantGOList [i].SetActive (true);
					PowerPlantGOList [i].GetComponent<Image> ().sprite = oilPP;
					activePowerPlants.Add (newpp);
					PolutionManager.PolutionRate += newpp.turnPolution;
				}
				//Caso não esteja disponivel, destruir o objeto criado
				else
					GameObject.Destroy (newpp);
				// Sair do loop
				return;
			}
		}
	}

	public void CreateGasPP(){
		//Se existirem slots disponibeis
		for (int i = 0; i < PowerPlantGOList.Count; i++) {
			if (PowerPlantGOList [i].activeSelf == false) {
				//Criar novo objeto Usina
				PowerPlant newpp = new GasPlant();
				//Se existem recursos disponiveis, remover recursos, criar UI do objeto
				if (CheckResourcesAvailable(redResource,newpp.r1Cost) && CheckResourcesAvailable (greenResource, newpp.r2Cost)){
					redResource.ReduceAvailable (newpp.r1Cost);
					greenResource.ReduceAvailable (newpp.r2Cost);

					PowerPlantGOList [i].SetActive (true);
					PowerPlantGOList [i].GetComponent<Image> ().sprite = gasPP;
					activePowerPlants.Add (newpp);
					PolutionManager.PolutionRate += newpp.turnPolution;
				}
				//Caso não esteja disponivel, destruir o objeto criado
				else
					GameObject.Destroy (newpp);
				// Sair do loop
				return;
			}
		}
	}

	public void CreateHidroPP(){
		//Se existirem slots disponibeis
		for (int i = 0; i < PowerPlantGOList.Count; i++) {
			if (PowerPlantGOList [i].activeSelf == false) {
				//Criar novo objeto Usina
				PowerPlant newpp = new HidroPlant();
				//Se existem recursos disponiveis, remover recursos, criar UI do objeto
				if (CheckResourcesAvailable(greenResource,newpp.r1Cost) && CheckResourcesAvailable (blueResource, newpp.r2Cost)){
					greenResource.ReduceAvailable (newpp.r1Cost);
					blueResource.ReduceAvailable (newpp.r2Cost);

					PowerPlantGOList [i].SetActive (true);
					PowerPlantGOList [i].GetComponent<Image> ().sprite = hidroPP;
					activePowerPlants.Add (newpp);
					PolutionManager.PolutionRate += newpp.turnPolution;
				}
				//Caso não esteja disponivel, destruir o objeto criado
				else
					GameObject.Destroy (newpp);
				// Sair do loop
				return;
			}
		}
	}

	public void CreateEolicaPP(){
		//Se existirem slots disponibeis
		for (int i = 0; i < PowerPlantGOList.Count; i++) {
			if (PowerPlantGOList [i].activeSelf == false) {
				//Criar novo objeto Usina
				PowerPlant newpp = new EolicaPlant();
				//Se existem recursos disponiveis, remover recursos, criar UI do objeto
				if (CheckResourcesAvailable (blueResource, newpp.r1Cost) && CheckResourcesAvailable (whiteResource, newpp.r2Cost)) {
					//blueResource.ReduceAvailable (newpp.r1Cost);
					//whiteResource.ReduceAvailable (newpp.r2Cost);

					PowerPlantGOList [i].SetActive (true);
					PowerPlantGOList [i].GetComponent<Image> ().sprite = eolicaPP;
					activePowerPlants.Add (newpp);
					PolutionManager.PolutionRate += newpp.turnPolution;
				}
				//Caso não esteja disponivel, destruir o objeto criado
				else
					GameObject.Destroy (newpp);
				// Sair do loop
				return;
			}
		}
	}

	//Atualiza recursos na UI
	void SetupResources(Resources r){
		if (r.available > r.total)
			r.available = r.total;
		r.myText.text = r.available.ToString();
	}

	bool CheckResourcesAvailable (Resources recurso, int cost){
		if (recurso.available >= cost) {
			return true;
		} else
			return false;
	}

	//Resiliencia natual do ambiente. Taxa de recuperação natural dos recursos renováveis	
	void NaturalResiliance (Resources recurso, float tempo){
		recurso.myTimer += Time.deltaTime;

		//a cada 'tempo' segundos o recursos disponiveis aumentam em 'taxa'
		if (recurso.myTimer > tempo) {
			recurso.available += recurso.taxaRegeneração;
			recurso.total += Mathf.FloorToInt(recurso.taxaRegeneração / 2);
			SetupResources (recurso);
			recurso.myTimer = 0f;
		}
	}

	//A cada 10s a usina gera energia e poluição
	void ActivatePowerPlant(PowerPlant pp){
		pp.generateEnergyTimer += Time.deltaTime;
		if (pp.generateEnergyTimer >= gameloopTimer) {
			pp.GenerateEnergyAndImpacts ();
			pp.generateEnergyTimer = 0;
			//print (PolutionManager.PolutionRate);
		}
	}
}
