using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public bool destroyObject;
    public ParticleSystem blood;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage(100);
        if(destroyObject==true)
        {
            Destroy(other.gameObject);
            Instantiate(blood,other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
    }
}
