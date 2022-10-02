using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCameraViewport : MonoBehaviour
{
    public PhotoCamera photoCamera;

    // Start is called before the first frame update
    void Start()
    {
        // set the photoCamera's sprite to this Image's sprite
        GetComponent<UnityEngine.UI.Image>().sprite = photoCamera.photoSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
