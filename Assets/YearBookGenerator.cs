using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YearBookGenerator : MonoBehaviour
{
    public YearBookPageCapture pageCapture;
    public Book book;

    private IEnumerator Start()
    {
        // wait 10 frames for the camera to render
        for (int i = 0; i < 10; i++)
        {
            yield return null;
        }

        Generate(book);
        book.Initialize();
    }
    public void Generate(Book book) {
        Debug.Log("Generating!");
        var page = pageCapture.Capture();
        page.name = "Cool New Page";

        Array.Resize(ref book.bookPages, book.bookPages.Length + 4);
        book.bookPages[book.bookPages.Length - 1] = page;
        book.bookPages[book.bookPages.Length - 2] = page;
        book.bookPages[book.bookPages.Length - 3] = page;
        book.bookPages[book.bookPages.Length - 4] = page;
    }
}
