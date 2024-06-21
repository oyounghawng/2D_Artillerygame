using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Collections.Generic;

public class TilemapToPNG : MonoBehaviour
{
    public Camera renderCamera;
    public Tilemap tilemap;
    public int textureWidth = 1024;
    public int textureHeight = 1024;
    public string tilemapFileName = "Tilemap4.png";

    void Start()
    {
        SaveTilemapAsPNG();
        SaveTileSprites();
    }

    [ContextMenu("FileToPng")]
    void SaveTilemapAsPNG()
    {
        // ���� ī�޶� ���� ����
        Color originalBackgroundColor = renderCamera.backgroundColor;
        CameraClearFlags originalClearFlags = renderCamera.clearFlags;

        // ���� ��� ����
        renderCamera.backgroundColor = new Color(0, 0, 0, 0); // ���� ���
        renderCamera.clearFlags = CameraClearFlags.SolidColor;

        // RenderTexture ����
        RenderTexture renderTexture = new RenderTexture(textureWidth, textureHeight, 24, RenderTextureFormat.ARGB32);
        renderCamera.targetTexture = renderTexture;

        // ī�޶� ��ġ�� ũ�� ����
        renderCamera.orthographicSize = tilemap.cellBounds.size.y / 2f;
        renderCamera.transform.position = new Vector3(tilemap.cellBounds.center.x, tilemap.cellBounds.center.y, -10);

        // Ÿ�ϸ� ������
        renderCamera.Render();

        // RenderTexture�� ������ Texture2D�� ����
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        texture.ReadPixels(new Rect(0, 0, textureWidth, textureHeight), 0, 0);
        texture.Apply();

        // RenderTexture�� ī�޶� �ʱ�ȭ
        renderCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // ���� ī�޶� ���� ����
        renderCamera.backgroundColor = originalBackgroundColor;
        renderCamera.clearFlags = originalClearFlags;

        // Texture2D�� PNG�� ����
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/" + tilemapFileName, bytes);

        Debug.Log("Tilemap saved as PNG: " + Application.dataPath + "/" + tilemapFileName);
    }

    [ContextMenu("FileToSprite")]
    void SaveTileSprites()
    {
        HashSet<Sprite> uniqueSprites = new HashSet<Sprite>();

        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile is Tile)
            {
                Tile t = (Tile)tile;
                if (t.sprite != null)
                {
                    uniqueSprites.Add(t.sprite);
                }
            }
        }

        int spriteIndex = 0;
        foreach (Sprite sprite in uniqueSprites)
        {
            SaveSpriteAsPNG(sprite, spriteIndex);
            spriteIndex++;
        }
    }

    void SaveSpriteAsPNG(Sprite sprite, int index)
    {
        Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        Color[] pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                  (int)sprite.textureRect.y,
                                                  (int)sprite.textureRect.width,
                                                  (int)sprite.textureRect.height);
        texture.SetPixels(pixels);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        string spriteFileName = "Sprite_" + index + ".png";
        File.WriteAllBytes(Application.dataPath + "/" + spriteFileName, bytes);

        Debug.Log("Sprite saved as PNG: " + Application.dataPath + "/" + spriteFileName);
    }
}
