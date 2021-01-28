using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntuacion : MonoBehaviour {
    public int puntos = 0;
    public int vida = 5;
    public int vidaExtra = 50;
    public TextMesh Marcador;
    public TextMesh life;
    private Animator animator;

    // Use this for initialization
    void Start() {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "QuitaPunto");

    }
    void IncrementarPuntos(Notification notificacion)
    {
        int PuntosAincrementar = (int)notificacion.data;
        
        puntos += PuntosAincrementar;
        if (puntos >= vidaExtra)
        {
            vida = vida + 1;
            vidaExtra = vidaExtra + 50;
        }
        //Debug.Log(" puntos Ganados " +  PuntosAincrementar+ " puntos. Total ganados " + puntos+"vida actual"+vida);
       Marcador.text = " puntuacion: "+puntos.ToString();
        life.text = " vidas: "+vida.ToString();
        
    }
    
    void QuitaPunto(Notification notificacion1)
    {
        int PuntosAQuitar = (int)notificacion1.data;
        vida =vida + PuntosAQuitar;
        if (vida <= 0)
        {
            GameObject Run1 =GameObject.Find("Run1");
           Run1.SetActive(false);
            SceneManager.LoadScene("GameScene");
            // NotificationCenter.DefaultCenter().PostNotification(this, "haMuerto");



        }
       
       
    }
    // Update is called once per frame
    void Update () {
		
	}
}
