using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCamera : MonoBehaviour
{
    public Texture2D photoTexture;
    public Sprite photoSprite;
    public PhotoPresenter photoPresenter;
    RenderTexture savephotoRenderTexture;
    Texture2D savephotoTexture;

    // Start is called before the first frame update
    void Awake()
    {
        var renderTexture = GetComponent<Camera>().targetTexture;
        // create photoTexture
        photoTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false, true); 
        // create photoSprite
        photoSprite = Sprite.Create(photoTexture, new Rect(0, 0, renderTexture.width, renderTexture.height), new Vector2(0.5f, 0.5f));

        // create savephotoRenderTexture
        savephotoRenderTexture = new RenderTexture(renderTexture.width, renderTexture.height, 0, RenderTextureFormat.ARGB32);

        // create savephotoTexture
        savephotoTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false, false);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest) {
        // copy renderTexture to photoTexture
        photoTexture.ReadPixels(new Rect(0, 0, src.width, src.height), 0, 0);
        photoTexture.Apply();
        // copy photoTexture to dest
        Graphics.Blit(photoTexture, dest);
    }

    public void TakePhoto() {
        // copy renderTexture to savephotoRenderTexture
        Graphics.Blit(GetComponent<Camera>().targetTexture, savephotoRenderTexture);

        // copy savephotoRenderTexture to savephotoTexture
        RenderTexture.active = savephotoRenderTexture;
        savephotoTexture.ReadPixels(new Rect(0, 0, savephotoRenderTexture.width, savephotoRenderTexture.height), 0, 0);
        savephotoTexture.Apply();
        RenderTexture.active = null;

        // save photoTexture to file
        var bytes = savephotoTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/../photo.png", bytes);

        photoPresenter.Present(photoTexture);
    }

    private void OnDestroy() {
        // destroy photoTexture
        Destroy(photoTexture);

        // destroy savephotoRenderTexture
        savephotoRenderTexture.Release();

        // destroy savephotoTexture
        Destroy(savephotoTexture);

    }
}
