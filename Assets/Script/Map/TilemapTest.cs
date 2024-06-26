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
        // 기존 카메라 설정 저장
        Color originalBackgroundColor = renderCamera.backgroundColor;
        CameraClearFlags originalClearFlags = renderCamera.clearFlags;

        // 투명 배경 설정
        renderCamera.backgroundColor = new Color(0, 0, 0, 0); // 투명 배경
        renderCamera.clearFlags = CameraClearFlags.SolidColor;

        // RenderTexture 생성
        RenderTexture renderTexture = new RenderTexture(textureWidth, textureHeight, 24, RenderTextureFormat.ARGB32);
        renderCamera.targetTexture = renderTexture;

        // 카메라 위치와 크기 설정
        renderCamera.orthographicSize = tilemap.cellBounds.size.y / 2f;
        renderCamera.transform.position = new Vector3(tilemap.cellBounds.center.x, tilemap.cellBounds.center.y, -10);

        // 타일맵 렌더링
        renderCamera.Render();

        // RenderTexture의 내용을 Texture2D로 복사
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        texture.ReadPixels(new Rect(0, 0, textureWidth, textureHeight), 0, 0);
        texture.Apply();

        // RenderTexture와 카메라 초기화
        renderCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // 원래 카메라 설정 복원
        renderCamera.backgroundColor = originalBackgroundColor;
        renderCamera.clearFlags = originalClearFlags;

        // Texture2D를 PNG로 저장
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
