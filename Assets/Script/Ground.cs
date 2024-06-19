using UnityEngine;

public class TileSplitter : MonoBehaviour
{
    public int numberOfRows = 5; // ���η� ���� ���� ��
    public int numberOfColumns = 5; // ���η� ���� ���� ��
    public float pieceScaleFactor = 0.1f; // ���� ũ�� ���� ���� (0.1 = 1/10)

    private void Start()
    {
        SplitTile();
    }

    void SplitTile()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            return;
        }

        Sprite sprite = spriteRenderer.sprite;
        Texture2D texture = sprite.texture;

        // Ÿ���� ũ��� ��������Ʈ�� ũ��
        Vector2 spriteSize = sprite.bounds.size;
        Vector2 pieceSize = new Vector2(spriteSize.x / numberOfColumns, spriteSize.y / numberOfRows);

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                CreatePiece(texture, row, col, pieceSize, spriteSize, spriteRenderer.transform.position);
            }
        }

        // ���� ������Ʈ�� ��Ȱ��ȭ
        //gameObject.SetActive(false);
        spriteRenderer.enabled = false;
    }

    void CreatePiece(Texture2D texture, int row, int col, Vector2 pieceSize, Vector2 spriteSize, Vector3 originalPosition)
    {
        GameObject piece = new GameObject("Piece_" + row + "_" + col);

        // ������ ��ġ�� ���� ��ġ�� �°� ����
        float piecePosX = originalPosition.x - spriteSize.x / 2 + pieceSize.x / 2 + col * pieceSize.x;
        float piecePosY = originalPosition.y - spriteSize.y / 2 + pieceSize.y / 2 + row * pieceSize.y;
        piece.transform.position = new Vector2(piecePosX, piecePosY);

        // ������ �θ� ������Ʈ�� �ڽ����� ����
        piece.transform.parent = transform;

        SpriteRenderer pieceSpriteRenderer = piece.AddComponent<SpriteRenderer>();
        pieceSpriteRenderer.sprite = Sprite.Create(texture,
            new Rect(col * pieceSize.x * texture.width / spriteSize.x,
                     row * pieceSize.y * texture.height / spriteSize.y,
                     pieceSize.x * texture.width / spriteSize.x,
                     pieceSize.y * texture.height / spriteSize.y),
            new Vector2(0.5f, 0.5f));

        // ũ�� ����
        piece.transform.localScale = new Vector3(pieceScaleFactor, pieceScaleFactor, 1);

        // ���� ������ �������� �����Ƿ� Collider�� �߰�
        piece.AddComponent<BoxCollider2D>();
    }
}
