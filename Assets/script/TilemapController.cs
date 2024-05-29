using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TilemapController : MonoBehaviour
{
    private Tilemap tilemap;
    [SerializeField] private Tile tileA;
    [SerializeField] private Tile tileB;
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < GameManager.MapSize.y; i++)
            {
                for (int j = 0; j < GameManager.MapSize.x; j++)
                {
                    if ((i+j)%2 == 0)
                    {
                        tilemap.SetTile(new Vector3Int(j, i, 0), tileA);
                    }
                    else
                    {
                        tilemap.SetTile(new Vector3Int(j, i, 0), tileB);
                    }
                    
                }
            }
        }
    }
    public void GenralMap()
    {

    }

    /*```csharp
    using UnityEngine;
    using UnityEngine.Tilemaps;

    public class TilemapController : MonoBehaviour
    {
        // Tilemap对象的引用
        public Tilemap tilemap;

        // 要设置到Tilemap上的Tile对象的引用
        public Tile tile;

        // Use this for initialization
        void Start()
        {
            // 确保tilemap和tile已经被设置
            if (tilemap == null || tile == null)
            {
                Debug.LogError("Tilemap or Tile is not assigned!");
                return;
            }

            // 在特定的位置设置一个Tile
            Vector3Int position = new Vector3Int(0, 0, 0);
            tilemap.SetTile(position, tile);

            // 例子：清除一个Tile
            // tilemap.SetTile(position, null);

            // 例子：获取一个Tile
            // TileBase retrievedTile = tilemap.GetTile(position);
            // Debug.Log(retrievedTile != null ? "Tile exists" : "Tile does not exist");
        }
    }*/
}
