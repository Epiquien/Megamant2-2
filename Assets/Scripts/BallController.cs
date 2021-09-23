using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float velocityX = 10f;
    private const string ENEMY = "Enemy";

  
    private Rigidbody2D rb;

    private MegamanController _megamanController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _megamanController = FindObjectOfType<MegamanController>();
        Destroy(this.gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        
        if (other.gameObject.CompareTag(ENEMY))
        {


            Destroy(gameObject);
            
            _megamanController.DisminuirPuntajeEn1();
            if (_megamanController.score == 0)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject); 
            }
              
            
           

          
            
            //Debug.Log("vida enemigo: "+ vidaEnemigo);

            //  _game.PlusScore(10);
            // _sonidos.PlayShotDump();

            // Debug.Log(_game.GetScore());
            // que le pasara al enemigo
        }
       
    }
}
