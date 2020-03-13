using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoInimigo : MonoBehaviour
{
    public bool jumping = false;
    public bool facinRight = true;
    public bool toche = false;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Transform wallCheck;
    public float speed;
    public float velo;
    public float timeLeft;
    bool facingRight = false;
    bool noChao = false;
    public Transform mao;

    public float lifeinimigo = 100;
    public float Speed = 2.5f;
    //public GameObject Magia;
    public GameObject obj;
    private Vector3 dir =Vector3.right;
    public float countdown = 4.0f;
    public bool lockleft;
    public Transform graundCheck;
    private bool invulnerable = false;
    public float dano;
    public GameObject obj2;
   
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
    }
    /*public void interacao()
    {
     lifeinimigo += -10;
     if (lifeinimigo == 0)
			{
				Destroy(gameObject);
			}
    }
    */
    // Update is called once per frame
    public void interacao()
    {
     lifeinimigo += -10;
     if (lifeinimigo == 0)
            {
                Destroy(gameObject);
            }
    print("Tomando");
    }
    void Update()
    {
        toche = Physics2D.Linecast(transform.position, wallCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        
        if(toche){
            flip();
        }
        /* countdown -= Time.deltaTime;
             if(countdown <= 0.0f){
                float x = transform.localScale.x;
           
                obj = Instantiate(Magia, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
                obj.GetComponent<MovimentoMagiadoInimigo>().Speed *= x;
                countdown = 4.0f;
                }
         
          */      


     
         if (lifeinimigo <= 0)
			{
				Destroy(gameObject);
                //obj2 = Instantiate(Potion, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
			}
        

        /*timeLeft -= Time.deltaTime;
         if(timeLeft < 0)
         {
             speed *= -1;
         }
      */
        
        /*
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
	    if (!noChao)
	    {	
	        speed *= -1;
	    }
        */
    
    }
   

    void FixedUpdate()
    {

        rb.velocity = new Vector2(speed, rb.velocity.y);
        
       
    }
    void flip(){
        facinRight = !facinRight;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale =new Vector3(x, transform.localScale.y, transform.localScale.z);
        dir.x = x;
        dir = dir;
        speed *= -1;
        
        
    }
     public void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("magia"))
        {
        
            lifeinimigo += dano;
            StartCoroutine(Damage());

       }
       else if(col.CompareTag("magia2"))
        {
        
            lifeinimigo += -3.5f;
            StartCoroutine(Damage());

       }
       else if(col.CompareTag("Ataque")){
            lifeinimigo += -5;
            StartCoroutine(Damage());
       }
    }
    IEnumerator Damage(){
        //float actual = speed;
        //speed = speed * -1;
        sprite.color = Color.red;
        rb.AddForce( new Vector2(0f, 100f));

        yield return new WaitForSeconds(0.1f);
        //speed = actual;
        sprite.color = Color.white;
    }
    
}
