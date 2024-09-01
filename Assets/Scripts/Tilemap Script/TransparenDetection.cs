using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparenDetection : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float transparencyAmount;
    [SerializeField] private float fadeTime;

    private SpriteRenderer spriteRenderer;
    private Tilemap tilemap;

    private Color colorFade;
    private Color originColor;
    private Coroutine coroutine;

    private float countTime;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coroutine = null;

        if (tilemap != null)
        {
            originColor = tilemap.color;
        }
        else if (spriteRenderer != null)
        {
            originColor = spriteRenderer.color;
        }

        colorFade = originColor;
        colorFade.a = transparencyAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (spriteRenderer)
            {
                MadeCoroutinNull();
                coroutine = StartCoroutine(FadeRoutine(spriteRenderer, colorFade));
            }
            else if (tilemap)
            {
                MadeCoroutinNull();
                coroutine = StartCoroutine(FadeRoutine(tilemap, colorFade));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (spriteRenderer)
            {
                MadeCoroutinNull();
                coroutine = StartCoroutine(FadeRoutine(spriteRenderer, originColor));
            }
            else if (tilemap)
            {
                MadeCoroutinNull();
                coroutine = StartCoroutine(FadeRoutine(tilemap, originColor));
            }
        }
    }

    IEnumerator FadeRoutine(SpriteRenderer sr, Color newColor)
    {
        countTime = 0;
        while (countTime < fadeTime)
        {
            countTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(sr.color.a, newColor.a, countTime/fadeTime);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
        sr.color = newColor;
    }

    IEnumerator FadeRoutine(Tilemap tl, Color newColor)
    {
        countTime = 0;
        while (countTime < fadeTime)
        {
            countTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(tl.color.a, newColor.a, countTime / fadeTime);
            tl.color = new Color(tl.color.r, tl.color.g, tl.color.b, newAlpha);
            yield return null;

        }
        tl.color = newColor;
    }

    private void MadeCoroutinNull()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}
