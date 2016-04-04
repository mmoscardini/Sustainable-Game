using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CityManager : MonoBehaviour {

	public Transform canvasMap;
	public GameObject cityPrefab;

	public static int totalPop = 0;
	public Text totalPopText;

	float energyConsumeTimer = 0f;

	//Criar lista de cidades
	List<GameObject> listaCidades = new List<GameObject>();




	void Start () {
		//Criar três cidades no mapa 
		CriarCidades (5);

		foreach (GameObject go in listaCidades) {
			City cityScript = go.GetComponent<City> ();
			totalPop += cityScript.population;
		}
	}

	void Update () {
		energyConsumeTimer += Time.deltaTime;
		if (energyConsumeTimer >= PowerPlantManager.gameloopTimer) {
			totalPop = 0;
			foreach (GameObject go in listaCidades) {
				City cityScript = go.GetComponent<City> ();
				cityScript.EnergyConsuption ();

				totalPop = cityScript.population;
			}
			energyConsumeTimer = 0f;
		}
			
		totalPopText.text = totalPop.ToString();
		print (totalPop);
	}

	//Criar gameobjets das cidades, adicionar script cidade
	//Posicionar corretamente em cima do mapa
	//Definir variaveis de população e consumo de energia
	public void CriarCidades (int amount){
		
		for (int i = 0; i < amount; i++) {			
			//Instanciar cidade em um lugar aleatorio do mapa 
			GameObject city = Instantiate (cityPrefab) as GameObject;
			city.transform.SetParent (canvasMap.transform);
			city.transform.localPosition = new Vector3 (Random.Range (-150, 150), Random.Range (-150, 150), 0);
			listaCidades.Add (city);
			City cityScript = city.GetComponent<City> ();

			int rnd = Random.Range (5, 10);
			cityScript.population = rnd;



			print ("cidade criada");
		}
	}

}
