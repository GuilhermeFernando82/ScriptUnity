using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float mana1 = 100;
    public GameObject mana;
    public GameObject hud;
    public float speed;
    public float jump;
    public int life;
    public GameObject obj;
    public GameObject Magia1;
    public GameObject Magia2;
    public Transform graundCheck;
    private bool invulnerable = false;
    public bool graunded = false;
    public bool jumping = false;
    public bool facinRight = true;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    public Transform jg;
    public GameObject objeto;
    public Transform mao;
    private Vector3 dir =Vector3.right;
    public LayerMask interacao;
    public float attackRate = 0.5f;
    public GameObject Ataque;
    public Transform spawnAttack;
    public bool attacking;
    public int id;
    public int idArma;
    public int idArmaAtual;
    public GameObject[] Spritesarmas;
    private _GameController _GameController;
    //public GameObject obj;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(_GameController)) as _GameController;

        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jg = GetComponent<Transform>();
        foreach(GameObject o in Spritesarmas){
            o.SetActive(false);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        graunded = Physics2D.Linecast(transform.position, graundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if(Input.GetButtonDown("Jump") && graunded){
            jumping = true;
        }    
        Animations();
        if(Input.GetButtonDown("Fire1") && graunded){
            
            
        /*bool pauseStates1 = cajado.activeSelf;
        if(pauseStates1){
            float x = transform.localScale.x;
            obj = Instantiate(cajado, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
            obj.GetComponent<MovimentoMagia>().vel *= -x;
        }else{*/
            atk();
            float nextAttack = Time.time + attackRate;
            GameObject cloneAttack = Instantiate(Ataque, spawnAttack.position,spawnAttack.rotation);
            if(!facinRight){
            cloneAttack.transform.eulerAngles = new Vector3 (180,0,180);
        }
        //}
    }
        /*if(Input.GetKeyDown(KeyCode.R)){
            trocadearma();
        }else if(Input.GetKeyDown(KeyCode.T)){
            armaprimaria();
        }
        */
        /*if (Input.GetButtonDown("Fire1")  && objeto == null)
        {
            anim.SetTrigger("atk");
            

        }
        if (Input.GetButtonDown("Fire1") && objeto != null)
        {
               anim.SetTrigger("atk");
               objeto.SendMessage("interacao",SendMessageOptions.DontRequireReceiver);
        }
        */
        if(Input.GetKeyDown(KeyCode.T)){
            trocadeArma(0);
        }
        if(Input.GetKeyDown(KeyCode.Y)){
            trocadeArma(1);
        }
        if(Input.GetKeyDown(KeyCode.U)){
            trocadeArma(2);
        }

        if(Input.GetKeyDown(KeyCode.W) && graunded)
        {   
            float x = transform.localScale.x;
            if(mana1 >= 10){
                obj = Instantiate(Magia2, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
                obj.GetComponent<MovimentoMagia>().vel *= -x;
            }else{
                print("Sem mana!!!");
                mana1 = 10;
            }
            
            mana1  += -15;
            AtualizaHudmana();
        }

        else if(Input.GetKeyDown(KeyCode.Q))
        {   
            float x = transform.localScale.x;
            if(mana1 >= 10){
                obj = Instantiate(Magia1, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);
                obj.GetComponent<MovimentoMagia>().vel *= -x;
            }else{
                print("Sem mana!!!");
                mana1 = 10;
            }
            
            mana1  += -10;
            AtualizaHudmana();
        }   
        
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
  
        if((move < 0f && facinRight) || (move > 0f && !facinRight)){
            Flip();
        }
        if(jumping){
            rb.AddForce(new Vector2(0f,jump));
            jumping = false;
        }
    }
    void atack(int atk){
	switch(atk){
		case 0:
			attacking = false;
			Spritesarmas[2].SetActive(false);
			break;
		case 1:
			attacking = true;
			break;
	}

    }
    void Flip(){
        facinRight = !facinRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void Animations(){
        anim.SetBool("walk", rb.velocity.x != 0f && graunded);
    }
    void atk(){
        anim.SetTrigger("atk");
    }
  
    public void AtualizaHudmana(){
	    hud = GameObject.Find("mana");
        hud.GetComponent<Text>().text = mana1.ToString();
        
    }
    public void trocadearma(){

        //cajado.SetActive(true);

        
    }
    public void armaprimaria(){

        //cajado.SetActive(false);
        
        
    }
    public void trocadeArma(int id){
        idArma = id;
        Spritesarmas[0].GetComponent<SpriteRenderer>().sprite = _GameController.armas1[idArma];
        Spritesarmas[1].GetComponent<SpriteRenderer>().sprite = _GameController.armas2[idArma];
        Spritesarmas[2].GetComponent<SpriteRenderer>().sprite = _GameController.armas3[idArma];
        idArmaAtual = idArma;

    }
    void controleArma(int id){
        foreach(GameObject o in Spritesarmas)
        {
            o.SetActive(false);
        }
            Spritesarmas[id].SetActive(true);
        }



 
    /*void interagir()
    {
       
        Debug.DrawRay(mao.position, dir * 1.2f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(mao.position, dir, 1.5f, interacao);
        if(hit == true)
        {
           objeto = hit.collider.gameObject;
        }else{
           objeto = null;
        }
    }
*/
}
