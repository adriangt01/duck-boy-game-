using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automatico : MonoBehaviour {
    public float Fuerzasalto = 100f;

    public bool enSuelo = false;
    public Transform comprobadorsuelo;
    float comprobadorRadio = 0.07f;
    public LayerMask mascarasuelo;
    private Animator animator;
   public bool corrriendo = false;
    //private bool muerto = false;
    public float velocidad = 1f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start() {

    }
    private void FixedUpdate()
    {
        if (corrriendo)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, GetComponent<Rigidbody2D>().velocity.y);
        }
        animator.SetFloat("velocidad x", GetComponent<Rigidbody2D>().velocity.x);
        enSuelo = Physics2D.OverlapCircle(comprobadorsuelo.position, comprobadorRadio, mascarasuelo);
        animator.SetBool("isGrounded", enSuelo);
    }


    // Update is called once per frame
    void Update () {

        if (corrriendo)
        {
          
            corrriendo = true;
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
        
    }
    }
}
