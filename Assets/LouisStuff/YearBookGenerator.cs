using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YearBookGenerator : MonoBehaviour
{
    public YearBookPageCapture pageCapture;
    public Book book;

    PhotoCollection photoCollection;

    private IEnumerator Start()
    {
        // wait 10 frames for the camera to render
        for (int i = 0; i < 10; i++)
        {
            yield return null;
        }

        photoCollection = FindObjectOfType<PhotoCollection>();

        if (photoCollection == null)
        {
            Debug.Log("No PhotoCollection found");
            GenerateBlankPage();
            GenerateBlankPage();

        } else {
            Debug.Log("Generating " + photoCollection.photos.Count + " pages");
            Generate(book);
        }
    }

    public void Generate(Book book) {
        StartCoroutine(_Generate(book));
    }

    public IEnumerator _Generate(Book book) {
        var imageSlotsPerPage = pageCapture.ImageSlots.Count;

        // generate pages until all photos are captured
        for (int i = 0; i < photoCollection.photos.Count; i += imageSlotsPerPage)
        {
            // populate the page with photos
            var photos = photoCollection.photos.GetRange(i, Math.Min(imageSlotsPerPage, photoCollection.photos.Count - i));
            pageCapture.PopulatePage(photos);

            // wait one frame
            yield return null;

            // capture the page
            var pageSprite = pageCapture.Capture();

            // add the page sprite to the book
            Array.Resize(ref book.bookPages, book.bookPages.Length + 1);

            book.bookPages[book.bookPages.Length - 1] = pageSprite;
        }

        // make sure bookPages is an even number
        if (book.bookPages.Length % 2 == 1) {
            GenerateBlankPage();
        }

        book.Initialize();
    }

    public void GenerateBlankPage() {
        var page = pageCapture.Capture();

        Array.Resize(ref book.bookPages, book.bookPages.Length + 1);
        book.bookPages[book.bookPages.Length - 1] = page;
    }
}
