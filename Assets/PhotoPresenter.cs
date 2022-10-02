using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PhotoPresenter : MonoBehaviour
{
    public Vector3 initialPosition;
    public Texture2D photoTexture;
    public Sprite photoSprite;
    public Ease moveEase = Ease.OutQuad;
    public Ease rotateEase = Ease.OutQuad;
    public float animationDuration = 1f;

    public Sequence moveSequence;
    public Sequence rotateSequence;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Present(Texture2D photo) {
        // duplicate photo
        photoTexture = new Texture2D(photo.width, photo.height, TextureFormat.RGBA32, false, true);
        photoTexture.SetPixels(photo.GetPixels());
        photoTexture.Apply();
        // create photoSprite
        photoSprite = Sprite.Create(photoTexture, new Rect(0, 0, photo.width, photo.height), new Vector2(0.5f, 0.5f));
        // set the photoSprite to this Image's sprite
        GetComponent<UnityEngine.UI.Image>().sprite = photoSprite;

        // tween sequence
        Sequence sequence = DOTween.Sequence();

        // show
        gameObject.SetActive(true);

        // kill previous sequence
        if (moveSequence != null) {
            moveSequence.Kill();
        } else {
            moveSequence = DOTween.Sequence();
        }

        moveSequence.Append(transform.DOMove(initialPosition, 0));
        moveSequence.Append(transform.DOLocalMoveY(0, animationDuration).SetEase(moveEase));
        moveSequence.Append(transform.DOLocalMoveY(800, 1f).SetDelay(1.5f));
        moveSequence.onComplete += () => {
            // hide
            gameObject.SetActive(false);
        };
        moveSequence.Play();

        // kill previous sequence
        if (rotateSequence != null) {
            rotateSequence.Kill();
        } else {
            rotateSequence = DOTween.Sequence();
        }

        rotateSequence.Append(transform.DORotate(new Vector3(0, 0, 360), animationDuration, RotateMode.FastBeyond360).SetEase(rotateEase));
        rotateSequence.Play();

    }
}
