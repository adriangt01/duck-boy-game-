using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMalo : MonoBehaviour {
    private int puntoVida=-1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "QuitaPunto", puntoVida);
        }
        Destroy(gameObject);
    }
}
