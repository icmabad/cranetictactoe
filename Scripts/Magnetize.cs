using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnetize : MonoBehaviour
{
    public GameObject[] pieces;
    public Text mag;
    public bool magneton = false;
    public bool dropped = false;

    private bool currentobj = false;

    public Toggle taketurns;
    private bool xturn = true;
    public Text turn;
    // Start is called before the first frame update
    void Start()
    {
        taketurns.onValueChanged.AddListener(delegate {
            ToggleValueChanged(taketurns);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            magneton = !magneton;
            if(magneton){
                mag.text = "Magnet: On";
            } else {
                mag.text = "Magnet: Off";
                if(taketurns.isOn){
                    xturn = !xturn;
                    if(xturn){
                        turn.text = "Player X's turn";
                    } else {
                        turn.text = "Player O's turn";
                    }
                }
            }
    
        }

    }

    void ToggleValueChanged(Toggle change){
        turn.enabled = !turn.enabled;
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pieces" && magneton)
        {
            Debug.Log("Object hit: " + other.gameObject.name);
            other.gameObject.GetComponent<Piece>().pickup(transform.position);
        }
    }*/

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pieces")
        {
            if (!dropped)
            {
                dropped = true;
                other.gameObject.GetComponent<Piece>().drop();
            }
            currentobj = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("HITTTTT");
        if (other.gameObject.tag == "pieces" && magneton&& !currentobj)
        {
            Debug.Log("Object hit: " + other.gameObject.name);
            if(taketurns.isOn){
                string temp = other.gameObject.name;
                if(xturn){
                    if(temp[0]!='O'){
                        other.gameObject.GetComponent<Piece>().pickup();
                        dropped = false;
                        currentobj = true;
                    }
                } else {
                    if(temp[0]!='X'){
                        other.gameObject.GetComponent<Piece>().pickup();
                        dropped = false;
                        currentobj = true;
                    }
                }
            } else {
                other.gameObject.GetComponent<Piece>().pickup();
                dropped = false;
                currentobj = true;
            }

        } else if (other.gameObject.tag == "pieces" && !magneton)
        {
            if (!dropped)
            {
                dropped = true;
                other.gameObject.GetComponent<Piece>().drop();
            }
            currentobj = false;
        }
    }
}
