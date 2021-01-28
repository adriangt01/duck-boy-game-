using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour {
    private bool haColisionadoConEljugador = false;
    public int PuntosAGanados=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
      
       if (!haColisionadoConEljugador && collision.gameObject.tag == "Player")
        {
           haColisionadoConEljugador = true;
        
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", PuntosAGanados);
       }
        
    }
}
