using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRatioAdjuster : MonoBehaviour
{
    public Camera cameraToAdjust;
    private float targetaspect;
    private float windowaspect;
    private float scaleheight;

    void Start()
    {   
        adjustCameraRatio();
    }

    // Update is called once per frame
    void Update()
    {
        if ((float)Screen.width / (float)Screen.height != windowaspect) {
            adjustCameraRatio();
        }
    }

    void adjustCameraRatio() {
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        targetaspect = 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        scaleheight = windowaspect / targetaspect;

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {  
            Rect rect = cameraToAdjust.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;
            
            cameraToAdjust.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = cameraToAdjust.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            cameraToAdjust.rect = rect;
        }
    }
}
