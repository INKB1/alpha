using UnityEngine;
using System.Collections;

public class DestroyByVisibility : MonoBehaviour {
	void OnBecameInvisible(){
		if (gameObject.name != "Avião") {
			Destroy (this.gameObject);
		}
	}
}
