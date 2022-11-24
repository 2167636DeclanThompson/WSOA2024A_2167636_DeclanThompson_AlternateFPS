using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Code Monkey. "How to take a Screenshot in Unity" YouTube. May 25, 2018. [Video file] Available from: https://www.youtube.com/watch?v=lT-SRLKUe5k

    private static CameraScript instance;
    private Camera myCamera;
    private bool TakePictureNextFrame;
    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if (TakePictureNextFrame)
        {
            TakePictureNextFrame = false;

            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraPicture.png", byteArray);
            Debug.Log("Saved");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakePicture(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        TakePictureNextFrame = true;
    }

    public void TakePicture_Static(int width, int height) 
    {
        instance.TakePicture(width, height);
    }
}
