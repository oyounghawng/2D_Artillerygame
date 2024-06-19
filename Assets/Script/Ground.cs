using UnityEngine;

public class TileSplitter : MonoBehaviour
{
    public int numberOfRows = 5; // 가로로 나눌 조각 수
    public int numberOfColumns = 5; // 세로로 나눌 조각 수
    public float pieceScaleFactor = 0.1f; // 조각 크기 조정 비율 (0.1 = 1/10)

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

        // 타일의 크기와 스프라이트의 크기
        Vector2 spriteSize = sprite.bounds.size;
        Vector2 pieceSize = new Vector2(spriteSize.x / numberOfColumns, spriteSize.y / numberOfRows);

        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                CreatePiece(texture, row, col, pieceSize, spriteSize, spriteRenderer.transform.position);
            }
        }

        // 원래 오브젝트를 비활성화
        //gameObject.SetActive(false);
        spriteRenderer.enabled = false;
    }

    void CreatePiece(Texture2D texture, int row, int col, Vector2 pieceSize, Vector2 spriteSize, Vector3 originalPosition)
    {
        GameObject piece = new GameObject("Piece_" + row + "_" + col);

        // 조각의 위치를 원래 위치에 맞게 조정
        float piecePosX = originalPosition.x - spriteSize.x / 2 + pieceSize.x / 2 + col * pieceSize.x;
        float piecePosY = originalPosition.y - spriteSize.y / 2 + pieceSize.y / 2 + row * pieceSize.y;
        piece.transform.position = new Vector2(piecePosX, piecePosY);

        // 조각을 부모 오브젝트의 자식으로 설정
        piece.transform.parent = transform;

        SpriteRenderer pieceSpriteRenderer = piece.AddComponent<SpriteRenderer>();
        pieceSpriteRenderer.sprite = Sprite.Create(texture,
            new Rect(col * pieceSize.x * texture.width / spriteSize.x,
                     row * pieceSize.y * texture.height / spriteSize.y,
                     pieceSize.x * texture.width / spriteSize.x,
                     pieceSize.y * texture.height / spriteSize.y),
            new Vector2(0.5f, 0.5f));

        // 크기 조정
        piece.transform.localScale = new Vector3(pieceScaleFactor, pieceScaleFactor, 1);

        // 물리 엔진을 적용하지 않으므로 Collider만 추가
        piece.AddComponent<BoxCollider2D>();
    }
}
