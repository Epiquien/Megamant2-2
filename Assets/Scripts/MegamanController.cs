using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanController : MonoBehaviour
{
   
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
    
    private const int Quieto = 0;
    private const int Correr = 1;
    private const int Saltar = 2;
    private const int CorrerDisparando = 3;
    
    public float velocityX = 7; 
    public float jumpForce = 30;
    private bool estaSaltando = false;

    private const int PISO_SALTAR = 7;
    
    public GameObject BalaPequenia;
    public GameObject BalaGrande;
    public GameObject BalaGigante;
    
    private Color originalColor;
    private float switchColorDelay = .1f;
    private float switchColorTime = 0f;
    
   
  
    private float startTime = 0f;
    private float timer = 0f;
    public float TiempoPequenia = 0.5f;
    
    public float TiempoGrande = 3.0f;
    
    public float TiempoGigante = 5.0f;
    // how long you need to hold to trigger the effect
 
    // Use if you only want to call the method once after holding for the required time
    private bool held = false;
 
    public string key = "x";
   
    
    public int score = 5;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        originalColor = sr.color;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarAnimacion(Quieto);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            CambiarAnimacion(Correr);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(- velocityX, rb.velocity.y);
            sr.flipX = true;
            CambiarAnimacion(Correr);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        if (Input.GetKeyUp(KeyCode.Space)  && !estaSaltando )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            CambiarAnimacion(Saltar);
            estaSaltando = true;
        }

       
        
        /////////////////////////////////////////////////////
        // Inicio de tiempo presionado
        if (Input.GetKeyDown(key))
        {
          
            lanzarBolaPequenia();
            startTime = Time.time;
            timer = startTime;
        }
 
        // Agrga tiempo a la tecla presionada
        if (Input.GetKey(key) && held == false)
        {
            timer += Time.deltaTime;
            CambiarAnimacion(CorrerDisparando);
            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
           // if (timer >= (startTime + TiempoPequenia))
           // {
            //    held = true;
              
          //  }  
         
             if (timer >(startTime + TiempoGrande) )
            {
               held = true;
                lanzarBolaGrande();
               
            }
             

            if (timer > (startTime + TiempoGigante)  )
            {
                held = true;
                 lanzarBolaGigante();
            }

            
        }

        if (Input.GetKeyUp(key))
        {
            held = false;
        }

        
//////////////////////////////////
        if (Input.GetKey(KeyCode.A))
        {
           SwitchColor();
        }

     
    }

    private void lanzarBolaPequenia()
    {
        var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .5f);
        Instantiate(BalaPequenia, position, BalaPequenia.transform.rotation);
    }
    
    private void lanzarBolaGrande()
    {
        var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .5f);
        Instantiate(BalaGrande, position, BalaPequenia.transform.rotation);
    }
    
    private void lanzarBolaGigante()
    {
        var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .5f);
        Instantiate(BalaGigante, position, BalaPequenia.transform.rotation);
    }
  
    
    private void SwitchColor()
    {
        if(sr.color == originalColor)
            sr.color = Color.green;
        else
            sr.color = originalColor;
        switchColorTime = 10;
        
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == PISO_SALTAR)
            estaSaltando = false;
        
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
    
    public void DisminuirPuntajeEn1()
    {
        score -= 1;
    }
    
    
}
