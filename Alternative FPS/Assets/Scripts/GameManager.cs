using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraScript cameraScript;
    public KeyCode Escape;
    public KeyCode Picture;

    private void Update()
    {
        if (Input.GetKeyDown(Picture))
        {
            cameraScript.TakePicture_Static(Screen.width, Screen.height);
        }

        if (Input.GetKey(Escape))
        {
            Application.Quit();
        }
    }
}
