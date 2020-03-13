using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 
public class _GameController : MonoBehaviour
{
    public float life = 100;
    public GameObject hud;
    [Header("Banco de dados de Armas")]
    public string[] NomeArma;
    public Sprite[] imgInventario;
    public int[] dano;
    public int[] idArmaInicial;
    public Sprite[] armas1;
    public Sprite[] armas2;
    public Sprite[] armas3;
    private Potion Potion;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(life <= 0){
            SceneManager.LoadScene(1);
            life = 0;
        }
    }
    public void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name == "trigger" || col.gameObject.name == "trigger" || col.gameObject.name == "Inimigo" || col.gameObject.name == "Inimigo2" || col.gameObject.name == "Inimigo3")
        {
            life += -0.125f;
            AtualizaHud();
       }/*if(col.gameObject.name == "Potion")
       {
           Potion.addpotion();
       }*/
    }
     public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "trigger" || col.gameObject.name == "Inimigo4" || col.gameObject.name == "Inimigo" || col.gameObject.name == "Inimigo2" || col.gameObject.name == "Inimigo3")
        {
            life += -0.125f;
            AtualizaHud();
      }
    }
    public void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.name == "trigger" || col.gameObject.name == "Inimigo" || col.gameObject.name == "Inimigo2" || col.gameObject.name == "Inimigo3" )
        {
            life += -0.125f;
            AtualizaHud();
      }
    }
    
    public void AtualizaHud(){
	    hud = GameObject.Find("life");
        hud.GetComponent<Text>().text = life.ToString();
    }
     
     
}
