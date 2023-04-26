using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    private int tp_number;
    private int number;
    public Transform tp1;
    public Transform tp2;
    public Transform tp3;
    private string player_name;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    /*private void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
        {
            if (this.gameObject.name == "Teleport1") tp_number = 1;
            if (this.gameObject.name == "Teleport2") tp_number = 2;
            if (this.gameObject.name == "Teleport3") tp_number = 3;

            do
                number = Random.Range(1,4);
            while (number == tp_number);

            Debug.Log(number);
            switch(number)
            {
                case 1: other.gameObject.transform.position = tp1.position; break;
                case 2: other.gameObject.transform.position = tp2.position; break;
                case 3: other.gameObject.transform.position = tp3.position; break;
            }

        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            player_name = "Player";
            Teleport();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player_name = "Player2";
            Teleport();
        }
    }

    void Teleport()
    {

        if (this.gameObject.name == "Teleport1") tp_number = 1;
        if (this.gameObject.name == "Teleport2") tp_number = 2;
        if (this.gameObject.name == "Teleport3") tp_number = 3;

        do
            number = Random.Range(1, 4);
        while (number == tp_number);

        Debug.Log(number);
        switch (number)
        {
            case 1: GameObject.Find(player_name).transform.position = tp1.position; break;
            case 2: GameObject.Find(player_name).transform.position = tp2.position; break;
            case 3: GameObject.Find(player_name).transform.position = tp3.position; break;
        }
    }
}