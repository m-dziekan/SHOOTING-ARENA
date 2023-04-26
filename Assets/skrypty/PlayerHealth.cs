using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PlayerHealth : MonoBehaviour {

    public float maxHealth = 100;
    public Image healthBar;
    Text informationText;
    public Animator anim;

    public GameObject EndGameMenuUI;
    public TextMeshProUGUI winnerText;


    [SerializeField]float health;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int amount)
    {
       

        health -= amount;

        if (health <= 0)    
        {
            health = 0;
            transform.Find("Weapon").gameObject.SetActive(false);
            anim.SetTrigger("Dead");
           // this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.GetComponent<PlayerController>().enabled=false;
            StartCoroutine(Pause());
        }

        healthBar.fillAmount = health/100;
    }

    public IEnumerator Pause()
    {
        yield return new WaitForSeconds(2);
        EndGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
        if(healthBar.gameObject.name=="Health") winnerText.text = "NINJA-GIRL WINS!";
        else if (healthBar.gameObject.name == "Health(1)") winnerText.text = "NINJA-BOY WINS!";

    }
}
