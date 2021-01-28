using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {
   
    public GameObject[] obj;
    public float tiempoMin = 1f;
    public float tiempoMax = 1.1f;
	// Use this for initialization
	void Start () {
        // Generar();
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
    }
	
    void PersonajeEmpiezaACorrer(Notification notificacion)
    {
        Generar();
    }
	// Update is called once per frame
	void Update () {
		
	}
    void Generar()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
    }
}
