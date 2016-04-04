using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resources : MonoBehaviour {

	public enum Type {red, green, blue, white};
	Type mytype; 

	public Text myText;
	public int total;
	public int available;

	public int taxaRegeneração;

	public float myTimer = 0f;

	public Resources(int _type, int amount, Text text, int regeneração){
		mytype = (Type)_type;

		total = amount;
		available = total;
		myText = text;
		taxaRegeneração = regeneração;
	}

	//Reduz recursos e atualiza UI
	public int ReduceAvailable (int i){
		if (available >= i){
			available -= i;
			myText.text = available.ToString();
		}
		return available;
	}

	public int ReduceTotal (int i){
		if (total >= i) {
			total -= i;
		}
		return total;
	}
}
