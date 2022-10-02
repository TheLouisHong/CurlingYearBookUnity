using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// dotween
using DG.Tweening;

public class FlashOverlay : MonoBehaviour
{
    
    public Image flashImage;
    public float flashDuration = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        flashImage = GetComponent<Image>();
        flashImage.enabled = false;
    }

    // Flash
    public void Flash() {
        flashImage.enabled = true;
        flashImage.color = new Color(1, 1, 1, 1);
        flashImage.DOColor(new Color(1, 1, 1, 0), flashDuration).OnComplete(() => {
            flashImage.enabled = false;
        });
    }
}
