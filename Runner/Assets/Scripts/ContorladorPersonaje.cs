using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContorladorPersonaje : MonoBehaviour {
    public float Fuerzasalto = 100f;

    public bool enSuelo=true;
    public Transform comprobadorsuelo;
    float comprobadorRadio = 0.07f;
    public LayerMask mascarasuelo;
    private Animator animator;
    private bool corrriendo = false;
    //private bool muerto = false;
    public float velocidad = 1f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "haMuerto");
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
    void haMuerto()
    {
        corrriendo = false;
        animator.SetBool("isDead",true);
        StartCoroutine(restar());
    }
  
    IEnumerator restar()
    {
        yield return new WaitForSeconds(1.5F);
        //SceneManager.LoadScene("intento 1");


    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (corrriendo)
            {
                if (enSuelo) ///obtiene el click izquierdo el el toque de una pantalla tactill
                 {
                     GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Fuerzasalto));
                 }
            }
            else
            {
                corrriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
            }
        }
		
	}
}
