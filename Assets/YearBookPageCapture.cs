using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// unity ui
using UnityEngine.UI;

public class YearBookPageCapture : MonoBehaviour
{
    [SerializeField]
    private RenderTexture renderTexture;

    public Image debugImage;

    private void Awake() {
        renderTexture = GetComponent<Camera>().targetTexture;
        Debug.Log(renderTexture);
    }

    public void DebugCapture()
    {
        Capture();
    }

    public Sprite Capture() {
        // rendertextre to texture2d
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        // texture2d to sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        // debug
        debugImage.sprite = sprite;

        return sprite;
    }

}
