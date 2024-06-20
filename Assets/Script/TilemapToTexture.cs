using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapToTexture : MonoBehaviour
{
    public Tilemap tilemap;
    public Camera renderCamera;
    public int textureWidth = 512;
    public int textureHeight = 512;

    private void Awake()
    {
        // Render Texture 생성
        RenderTexture renderTexture = new RenderTexture(textureWidth, textureHeight, 24);
        renderCamera.targetTexture = renderTexture;

        // 카메라 설정
        renderCamera.orthographic = true;
        renderCamera.orthographicSize = Mathf.Max(tilemap.size.x, tilemap.size.y) / 2;
        renderCamera.transform.position = new Vector3(tilemap.transform.position.x, tilemap.transform.position.y, -10);

        // 카메라로 타일맵 렌더링
        renderCamera.Render();

        // Render Texture를 Texture2D로 변환
        Texture2D texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, textureWidth, textureHeight), 0, 0);
        texture.Apply();

        // RenderTexture 해제
        renderCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // 텍스처 사용
        // 예시: 텍스처를 스프라이트로 변환하여 SpriteRenderer에 적용
        //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f));
        GetComponent<Square>().srcTexture = texture;
    }
}
