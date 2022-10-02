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
    public List<Image> ImageSlots = new List<Image>();
    List<Sprite> PhotoSprites = new List<Sprite>();

    private void Awake() {
        renderTexture = GetComponent<Camera>().targetTexture;
    }

    public void DebugCapture()
    {
        Capture();
    }

    public void PopulatePage(List<Texture2D> photos) {
        // destroy and clear all previous sprites
        foreach (var photo in PhotoSprites) {
            Destroy(photo);
        }

        PhotoSprites.Clear();

        for (int i = 0; i < ImageSlots.Count; i++) {
            if (i < photos.Count) {
                // create sprite and append to PhotoSprites
                var photoSprite = Sprite.Create(photos[i], new Rect(0, 0, photos[i].width, photos[i].height), new Vector2(0.5f, 0.5f));
                PhotoSprites.Add(photoSprite);

                // set PhotoSlots[i] to photoSprite
                ImageSlots[i].sprite = photoSprite;
            } else {
                ImageSlots[i].sprite = null;
            }
        }
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

    private void OnDestroy() {
        // destroy and clear all previous sprites
        foreach (var photo in PhotoSprites) {
            Destroy(photo);
        }

        PhotoSprites.Clear();
    }
}
