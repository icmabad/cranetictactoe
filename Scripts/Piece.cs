using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    PieceMovement move;
    public Vector3 magnet;
    private Rigidbody rb;

    public GameObject magnetpos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        move = gameObject.GetComponent<PieceMovement>();
        move.enabled = false;
        //magnetpos = GameObject.Find("MagnetPiece");
        magnetpos = GameObject.Find("Range");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickup(){
        rb.useGravity = false;
        move.enabled = true;
    }

    public void drop(){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        move.enabled = false;
        rb.useGravity = true;
    }
}
