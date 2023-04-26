using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet_player2 : MonoBehaviour
{

    public float speed;
    private Rigidbody2D bulletRB;
    public GameObject flare;

    // Use this for initialization
    void Start()
    {

        bulletRB = GetComponent<Rigidbody2D>();


        if (GameObject.Find("Player2").transform.localScale.x == -1)
            bulletRB.velocity = new Vector2(-speed, 0);

        else bulletRB.velocity = new Vector2(speed, 0);

    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObj = other.gameObject;
        Debug.Log("Collided with: " + otherObj);

        PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(10);




        GameObject Flare = (GameObject)Instantiate(flare, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
