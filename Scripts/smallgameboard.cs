using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallgameboard : MonoBehaviour
{
    public char piece = 'n';
    public gameboard game;
    // Start is called before the first frame update
    void Start()
    {
        game = transform.parent.gameObject.GetComponent<gameboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pieces")
        {
            string temp = other.gameObject.name;
            piece = temp[0];
            Debug.Log(piece);
            //if(game!=null)
            //game.prints();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pieces")
        {
            piece = 'n';
            //Debug.Log(piece);
        }
    }
}
