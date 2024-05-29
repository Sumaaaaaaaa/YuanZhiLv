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
        // Tilemap���������
        public Tilemap tilemap;

        // Ҫ���õ�Tilemap�ϵ�Tile���������
        public Tile tile;

        // Use this for initialization
        void Start()
        {
            // ȷ��tilemap��tile�Ѿ�������
            if (tilemap == null || tile == null)
            {
                Debug.LogError("Tilemap or Tile is not assigned!");
                return;
            }

            // ���ض���λ������һ��Tile
            Vector3Int position = new Vector3Int(0, 0, 0);
            tilemap.SetTile(position, tile);

            // ���ӣ����һ��Tile
            // tilemap.SetTile(position, null);

            // ���ӣ���ȡһ��Tile
            // TileBase retrievedTile = tilemap.GetTile(position);
            // Debug.Log(retrievedTile != null ? "Tile exists" : "Tile does not exist");
        }
    }*/
}
