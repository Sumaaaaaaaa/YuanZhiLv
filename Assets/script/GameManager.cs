using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一切游戏全程可能用到的重要的数据（不可变、可变）都放在这，使用静态数据
/// </summary>
public class GameManager : MonoBehaviour
{
    // 它是单例模式的
    static private GameManager _instance;

    // 地图部分
    // 地图大小设定
    [SerializeField] private Vector2Int _mapSize = new Vector2Int();
    static public Vector2Int MapSize
    {
        get
        { return _instance._mapSize; }
    }
    // 地图矩阵
    static public GameObject[,] map;


    private void Awake()
    {
        // 单例模式实现
        if (_instance is not null)
        {
            Debug.LogError("GameManager单例模式错误，在场景中出现了大于一个GameManager，请立即终止并检查");
        }
        _instance = this;
    }
}
