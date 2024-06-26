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
        // Render Texture ����
        RenderTexture renderTexture = new RenderTexture(textureWidth, textureHeight, 24);
        renderCamera.targetTexture = renderTexture;

        // ī�޶� ����
        renderCamera.orthographic = true;
        renderCamera.orthographicSize = Mathf.Max(tilemap.size.x, tilemap.size.y) / 2;
        renderCamera.transform.position = new Vector3(tilemap.transform.position.x, tilemap.transform.position.y, -10);

        // ī�޶�� Ÿ�ϸ� ������
        renderCamera.Render();

        // Render Texture�� Texture2D�� ��ȯ
        Texture2D texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, textureWidth, textureHeight), 0, 0);
        texture.Apply();

        // RenderTexture ����
        renderCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // �ؽ�ó ���
        // ����: �ؽ�ó�� ��������Ʈ�� ��ȯ�Ͽ� SpriteRenderer�� ����
        //Sprite sprite = Sprite.Create(texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f));
        GetComponent<Square>().srcTexture = texture;
    }
}
