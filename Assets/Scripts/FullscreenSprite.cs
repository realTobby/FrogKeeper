using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenSprite : MonoBehaviour
{
    public Sprite[] backgrounds;

    void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();


        spriteRenderer.sprite = backgrounds[Random.Range(0, backgrounds.Length)];


        float cameraHeight = Camera.main.orthographicSize * 2.5f;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        scale *= cameraSize.x / spriteSize.x;

       // transform.position = Vector2.zero; // Optional
        transform.localScale = scale;

    }
}
