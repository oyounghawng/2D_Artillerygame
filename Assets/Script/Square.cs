using DigitalRuby.AdvancedPolygonCollider;
using System.Collections;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Texture2D srcTexture;
    private Texture2D newTexture;
    private SpriteRenderer sr;

    private float worldWidth;
    private float worldHeight;
    private int pixelWidth;
    private int pixelHeight;


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

        gameObject.GetOrAddComponent<AdvancedPolygonCollider>().RunInPlayMode = true;
    }

    public void MakeAHole(CircleCollider2D c2d)
    {
        Vector2Int colliderCenter = WorldToPixel(c2d.bounds.center);
        int radius = Mathf.RoundToInt(c2d.bounds.size.x / 2 * pixelWidth / worldWidth);
        radius *= 3; // ���� �ı� ����ġ 1,2,3
        Destroy(c2d.transform.parent.gameObject, 0.02f);
        
        int px, nx, py, ny, distance;
        for (int i = 0; i < radius; i++)
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

        StartCoroutine(CollisionReset());
    }

    IEnumerator CollisionReset()
    {
        yield return new WaitForEndOfFrame();
        gameObject.GetOrAddComponent<AdvancedPolygonCollider>().RunInPlayMode = true;
        yield return new WaitForEndOfFrame();
        gameObject.GetOrAddComponent<AdvancedPolygonCollider>().RunInPlayMode = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<CircleCollider2D>()) return;
        MakeAHole(collision.GetComponent<CircleCollider2D>());
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
