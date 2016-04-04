using UnityEngine;
using System.Collections;

public class PolutionManager : MonoBehaviour {

	public static int PolutionRate;

	//Niveis altissimos de poluição resultam em redução do total disponivel de um recurso renovável
	public static void PolutionOverload ()  {
		int rnd = Random.Range (0, 3);
		print (rnd);
		switch (rnd) {
		case 0: 
			PowerPlantManager.Instance.greenResource.total -= 1;
			//print ("new green total is " + PowerPlantManager.Instance.greenResource.total);
			break;
		case 1: 
			PowerPlantManager.Instance.blueResource.total -= 2;
			//print ("new blue total is " + PowerPlantManager.Instance.blueResource.total);
			break;
		case 2: 
			PowerPlantManager.Instance.whiteResource.total -= 1;
			//print ("new white total is " + PowerPlantManager.Instance.whiteResource.total);
			break;

		default:
			break;
		}
	}
}
