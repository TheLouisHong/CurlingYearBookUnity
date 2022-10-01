using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// import dotween 
using DG.Tweening;

public class YearBookCover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        // dotween rotation and then
        transform.DORotate(new Vector3(0, 180, 0), 1f).OnComplete(() => {
            // dotween scale
            var pos = transform.position;
            pos.z = 10;
            transform.position = pos;
        });
    }

}
