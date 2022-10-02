using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBookToDisk : MonoBehaviour
{
    public Book book;

    private void Awake() {
    }

    public void Save() {
        // Get width and height of book page
        var width = book.bookPages[0].texture.width;
        var height = book.bookPages[0].texture.height;

        // Create a new texture to hold the book
        var texture2D = new Texture2D(width, height, TextureFormat.RGB24, false, false);
        

        // loop bookPages and save each sprite as texture to disk
        for (int i = 0; i < book.bookPages.Length; i++)
        {
            var pageSprite = book.bookPages[i];
            var pageTexture = pageSprite.texture;

            // copy texture to texture2D
            texture2D.SetPixels(pageTexture.GetPixels());
            texture2D.Apply();

            // save texture2D to disk
            var bytes = texture2D.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/../page" + i + ".png", bytes);
        }

    }
}
