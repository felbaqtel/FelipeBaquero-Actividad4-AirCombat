using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.Translate(0.0f, 0.0f, 0.5f);
	}

	void OnCollisionEnter(Collision collision){

		if (collision.collider.gameObject.tag == "Enemy") {


			//Carga el prefab de una explosion
			GameObject explosion = GameObject.Instantiate (Resources.Load ("prefab/Explosion") as GameObject);

			//Muevo la explosion a la posicion donde esta la nave
			explosion.transform.position = collision.collider.gameObject.transform.position;

			//Eliminamos el enemigo
			Destroy (collision.collider.gameObject);

			// Destruimos el misisl 
			Destroy (this.gameObject);
		}
		if (collision.collider.gameObject.tag == "Ally") {

			//Obtener una refernecia del gameObject LuzVerde (Gameobject hijo)
			GameObject son = collision.collider.gameObject.transform.Find("LuzVerde").gameObject;

			//Cambiamos a azul la propiedad color del componente Light 
			//del GameObject aliado
			son.GetComponent<Light> ().color = new Color (0, 0, 1);

			//Destruimos el misil
			Destroy (this.gameObject);
		}
	}
}