using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecontrol : MonoBehaviour
{
    private RaycastHit hitInfo;
    public GameObject axis;
    private SceneNode gp=null;
    private string dir;
    Vector3 mouseDownPos = Vector3.zero;
    private Vector3 dif;
    private Vector3 temp;
    private int set = 0;
    private bool movedot = false;

    private bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        axis.transform.localPosition = new Vector3(0,-100,0);
    }

    // Update is called once per frame
    void Update()
    {

        if(gp!=null){
            transform.localPosition = gp.getposition();
            //axis.transform.up = gp.transform.up;
        }

        if (Input.GetMouseButtonDown(0))
        {
            movedot = false;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            //bool hit = Physics.SphereCast(Camera.main.ScreenPointToRay(Input.mousePosition),10,transform.forward, out hitInfo, 10);
            if (hit)
            {
                GameObject p;
                Debug.Log(hitInfo.transform.parent.gameObject.name);
                //String name = hitInfo.transform.parent.gameObject.name;
                if(hitInfo.transform.parent.gameObject.name=="Geom"){
                    p = GameObject.Find(hitInfo.transform.parent.transform.parent.gameObject.name);
                    if(p!=null){
                        Debug.Log(p.name);
                        gp = p.GetComponent<SceneNode>();
                        axis.transform.localPosition = gp.getposition();
                        reverse = true;
                    }
                } else if (hitInfo.transform.parent.gameObject.name=="arm"||hitInfo.transform.parent.gameObject.name=="Base"){
                    p = GameObject.Find(hitInfo.transform.parent.parent.parent.gameObject.name);
                    if(p!=null){
                        Debug.Log(p.name);
                        gp = p.GetComponent<SceneNode>();
                        axis.transform.localPosition = gp.getposition();
                        reverse = false;
                    }
                } else if (hitInfo.transform.gameObject.tag == "axis")
                {
                    set = 0;
                    dir = hitInfo.transform.gameObject.name;
                    mouseDownPos = Input.mousePosition;
                    temp = gp.transform.localPosition;
                    movedot = true;
                    dif = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, gp.transform.localPosition.z));
                } else {
                    axis.transform.localPosition = new Vector3(0,-100,0);
                    reverse = false;
                }
            } else {
                reverse = false;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (movedot)
            {
                gp.transform.localPosition = axis.transform.localPosition;
                float distance_to_screen = Camera.main.WorldToScreenPoint(gp.transform.position).z;
                Vector3 t = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
                if (set == 0)
                {
                    dif = t;
                    set++;
                }
                if(reverse){
                    if (dir == "X")
                    {
                        gp.transform.localPosition = new Vector3(temp.x, t.x - dif.x + temp.y, temp.z);
                        axis.transform.localPosition = gp.getposition();
                    }
                    else if (dir == "Y")
                    {
                        gp.transform.localPosition = new Vector3( -(t.y - dif.y) + temp.x,temp.y, temp.z);
                        axis.transform.localPosition = gp.getposition();
                    }
                    else if (dir == "Z")
                    {
                        gp.transform.localPosition = new Vector3(temp.x, temp.y, t.z - dif.z + temp.z);
                        axis.transform.localPosition = gp.getposition();
                    }
                } else {
                    if (dir == "X")
                    {
                        gp.transform.localPosition = new Vector3(t.x - dif.x + temp.x, temp.y, temp.z);
                        axis.transform.localPosition = gp.getposition();
                    }
                    else if (dir == "Y")
                    {
                        gp.transform.localPosition = new Vector3(temp.x, t.y - dif.y + temp.y, temp.z);
                        axis.transform.localPosition = gp.getposition();
                    }
                    else if (dir == "Z")
                    {
                        gp.transform.localPosition = new Vector3(temp.x, temp.y, t.z - dif.z + temp.z);
                        axis.transform.localPosition = gp.getposition();
                    }
                }
            }
        }
    }
}
