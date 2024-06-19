using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Square : MonoBehaviour
{
    public Texture2D srcTexture;
    Texture2D newTexture;
    SpriteRenderer sr;

    float worldWidth, worldHeight;
    int pixelWidth, pixelHeight;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        newTexture = Instantiate(srcTexture);

        newTexture.Apply();
        MakeSprite();

        worldWidth = sr.bounds.size.x;
        worldHeight = sr.bounds.size.y;
        pixelWidth = sr.sprite.texture.width;
        pixelHeight = sr.sprite.texture.height;

        gameObject.AddComponent<PolygonCollider2D>();
    }

    public void MakeAHole (CircleCollider2D c2d)
    {
        Vector2Int colliderCenter = WorldToPixel (c2d.bounds.center);
        int radius = Mathf.RoundToInt (c2d.bounds.size.x / 2 * pixelWidth / worldWidth);
        Destroy (c2d.transform.parent.gameObject);
        int px, nx, py, ny, distance;
        for (int i =0; i < radius; i++)
        {
            distance = Mathf.RoundToInt(Mathf.Sqrt(radius * radius - i * i));
            for (int j = 0; j < distance; j++)
            {
                px = colliderCenter.x + i;
                nx = colliderCenter.x - i;
                py = colliderCenter.y + j;
                ny = colliderCenter.y - j;

                newTexture.SetPixel(px, py, Color.clear);
                newTexture.SetPixel(nx, py, Color.clear);
                newTexture.SetPixel(px, ny, Color.clear);
                newTexture.SetPixel(nx, ny, Color.clear);
            }
        }
        newTexture.Apply();
        MakeSprite();

        var polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
        if (polygonCollider != null)
        {
            Destroy(polygonCollider);
        }
        //Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<CircleCollider2D>()) return;
        MakeAHole(collision.GetComponent<CircleCollider2D>());
    }

    public void MakeDot (Vector3 pos)
    {
        Vector2Int pisxelPosition = WorldToPixel(pos);

        Debug.Log(pos + "/" +  pisxelPosition);

        newTexture.SetPixel(pisxelPosition.x, pisxelPosition.y , Color.clear);
        newTexture.SetPixel(pisxelPosition.x+1, pisxelPosition.y, Color.clear);
        newTexture.SetPixel(pisxelPosition.x-1, pisxelPosition.y, Color.clear);
        newTexture.SetPixel(pisxelPosition.x, pisxelPosition.y+1, Color.clear);
        newTexture.SetPixel(pisxelPosition.x, pisxelPosition.y-1, Color.clear);

        newTexture.Apply ();
        MakeSprite();
    }

    private void MakeSprite()
    {
        Sprite newSprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.one * 0.5f);
        sr.sprite = newSprite;
    }

    private Vector2Int WorldToPixel(Vector3 pos)
    {
        Vector2Int pixelPosition = Vector2Int.zero;

        var dx = pos.x - transform.position.x;
        var dy = pos.y - transform.position.y;

        pixelPosition.x = Mathf.RoundToInt(0.5f * pixelWidth + dx * (pixelWidth / worldWidth));
        pixelPosition.y = Mathf.RoundToInt(0.5f * pixelHeight + dy * (pixelHeight / worldHeight));

        return pixelPosition;
    }
}
