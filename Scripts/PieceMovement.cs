using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    Piece piecescript;
    
    // Start is called before the first frame update
    void Start()
    {
        piecescript = gameObject.GetComponent<Piece>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y!=piecescript.magnetpos.transform.position.y-1){
            float x = Vector3.Distance(transform.position, piecescript.magnetpos.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, piecescript.magnetpos.transform.position, 20*Time.deltaTime);
        }else
            transform.position = piecescript.magnetpos.transform.position;
    }
}
