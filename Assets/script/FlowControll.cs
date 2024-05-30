using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 它拥有对全游戏的流程唯一的控制权，即只有它可以说“现在开始抽牌”、“现在开始A玩家行动”等所有命令。不准一切其他脚本对它发号施令。
/// </summary>
public class FlowControll : MonoBehaviour
{
    [SerializeField]private TilemapController tilemapController;

    // ※ 细节规则：一切对*逻辑*层面的调用应当是*瞬间*完成的，故使用Function ※

    // ※ 细节规则：一切对*视觉*的调用应当是*等待*的，故使用Coroutine（为了标准化，尽管是瞬时完成的动作也应该使用Coroutine）※

    // ※ 细节规则：最后按顺序放入Main协程中，即可按顺序的执行了 ※

    // ※ 会直接在程序开始时执行Main程序 ※
    
    // 在逻辑层面生成地图
    private void GeneralMap()
    {
        GameManager.map = new GameObject[GameManager.MapSize.x, GameManager.MapSize.y];
        Debug.Log($"完成[{nameof(GeneralMap)}]，在数据层面生成了 {GameManager.MapSize.x},{GameManager.MapSize.y} 的矩阵");

        string printText = "";
        for (int y = GameManager.MapSize.y - 1; y >= 0; y--)
        {
            for (int x = 0; x < GameManager.MapSize.x; x++)
            {
                printText += GameManager.map[x, y] is null ? "O" : "X";
            }
            printText+= "\n";
        }
        Debug.Log(printText);
    }
    private IEnumerator IE_GeneralMap()
    {
        tilemapController.GenralMap();
        yield return new WaitForSeconds(1.0f);
        Debug.Log($"完成[{nameof(IE_GeneralMap)}]");
    }
    
    
    private IEnumerator Main()
    {
        GeneralMap();
        yield return IE_GeneralMap();
    }

    
    private void Start()
    {
        StartCoroutine(Main());
    }
}
