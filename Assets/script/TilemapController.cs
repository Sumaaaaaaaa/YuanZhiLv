using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    private Tilemap tilemap;
    [SerializeField] private Tile tileA;
    [SerializeField] private Tile tileB;
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }
    public void GenralMap()
    {
        // 清空所有Tiles
        tilemap.ClearAllTiles();
        // 生成地图
        for (int i = 0; i < GameManager.MapSize.y; i++)
        {
            for (int j = 0; j < GameManager.MapSize.x; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    tilemap.SetTile(new Vector3Int(j, i, 0), tileA);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(j, i, 0), tileB);
                }

            }
        }
        // 将相机对准到地图中央
        Bounds tilemapBounds = tilemap.localBounds;
        float tilemapWidth = tilemapBounds.size.x;
        float tilemapHeight = tilemapBounds.size.y;
        // 获取相机的屏幕宽高比
        float screenAspect = (float)Screen.width / (float)Screen.height;
        // 相机对准
        float cameraSize = tilemapHeight / 2.0f;
        if (tilemapWidth / screenAspect > tilemapHeight)
        {
            cameraSize = tilemapWidth / 2.0f / screenAspect;
        }
        Camera.main.orthographicSize = cameraSize;
        Camera.main.transform.position = new Vector3(tilemapBounds.center.x,
                                                    tilemapBounds.center.y,
                                                    Camera.main.transform.position.z);
    }
}
