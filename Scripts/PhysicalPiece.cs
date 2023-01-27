using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalPiece : MonoBehaviour
{
    public float adjustVal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = gameObject.transform.parent.GetChild(0).gameObject;
        Vector3 Pivot = temp.GetComponent<NodePrimitive>().Pivot - new Vector3(0, temp.transform.localScale.y - adjustVal, 0);
        Matrix4x4 p = Matrix4x4.TRS(Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 invP = Matrix4x4.TRS(-Pivot, Quaternion.identity, Vector3.one);
        Matrix4x4 trs = temp.GetComponent<NodePrimitive>().trs;
        Matrix4x4 m = temp.GetComponent<NodePrimitive>().nodeT * p * trs * invP;
        transform.position = new Vector3(m.m03, m.m13, m.m23);
    }
}
