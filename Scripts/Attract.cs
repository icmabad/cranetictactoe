using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour
{
    public GameObject[] pieces;
    public bool magneton = false;

    private Piece currentobj = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            magneton=!magneton;
            if(currentobj!=null){
                currentobj.drop();
                currentobj=null;
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-transform.up), out hit))
        {
            if(hit.collider.tag=="pieces"&&magneton&&currentobj==null){
            Debug.Log("Where:" + transform.position);
            currentobj = hit.collider.gameObject.GetComponent<Piece>();
            currentobj.pickup();
            }
        }
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="pieces"&&magneton){
            Debug.Log("Object hit: "+ other.gameObject.name);
        }
    }
}
