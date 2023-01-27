using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardMove : MonoBehaviour
{
    public Toggle T;
    public Transform body;
    public Transform arm;
    public Transform hang;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            PlayerPrefs.DeleteKey("gamesplaidcounter");
            PlayerPrefs.DeleteKey("xwincounter");
            PlayerPrefs.DeleteKey("owincounter");
            Application.Quit();
        }

        // Crane Base movement
        if (Input.GetKey(KeyCode.D))
        {
            body.Translate(new Vector3(0.03f, 0, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {
            body.Translate(new Vector3(0, 0, 0.03f), Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.Translate(new Vector3(0, 0, -0.03f), Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.Translate(new Vector3(-0.03f, 0, 0), Space.World);
        }

        // Crane Arm movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (arm.localPosition.y <= 1.3)
            {
                arm.Translate(new Vector3(0, 0.03f, 0), Space.World);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (arm.localPosition.y >= -10.5)
            {
                arm.Translate(new Vector3(0, -0.03f, 0), Space.World);
            }
        }

        // Crane Hang movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (hang.localPosition.y >= -9)
            {
                hang.Translate(new Vector3(0.03f, 0, 0), Space.Self);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (hang.localPosition.y <= 0.3)
            {
                hang.Translate(new Vector3(-0.03f, 0, 0), Space.Self);
            }
        }
    }
}
