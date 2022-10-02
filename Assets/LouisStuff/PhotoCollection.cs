using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCollection : MonoBehaviour
{
    public List<Texture2D> photos = new List<Texture2D>();

    private void Awake() {
        Object.DontDestroyOnLoad(this.gameObject);
    }

    public void AddPhoto(Texture2D photo) {
        // copy the photo to a new texture
        Texture2D newPhoto = new Texture2D(photo.width, photo.height, TextureFormat.RGB24, false, true);
        newPhoto.SetPixels(photo.GetPixels());
        newPhoto.Apply();

        // add the new photo to the list
        photos.Add(newPhoto);
    }
    
    public void ClearPhotos() {
        // destroy all textures
        foreach (var photo in photos) {
            Destroy(photo);
        }
        photos.Clear();
    }

    private void OnDestroy() {
        ClearPhotos();
    }
}
