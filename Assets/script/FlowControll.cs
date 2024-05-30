using System.Collections;
using UnityEngine;


/// <summary>
/// 它拥有对全游戏的流程唯一的控制权，即只有它可以说“现在开始抽牌”、“现在开始A玩家行动”等所有命令。不准一切其他脚本对它发号施令。
/// </summary>
public class FlowControll : MonoBehaviour
{
    [SerializeField] private TilemapController tilemapController;

    // ※ 细节规则：一切对*逻辑*层面的调用应当是*瞬间*完成的，故使用Function ※
    // ※ 细节规则：一切对*视觉*的调用应当是*等待*的，故使用Coroutine（为了标准化，尽管是瞬时完成的动作也应该使用Coroutine）※
    // ※ 细节规则：最后按顺序放入Main协程中，即可按顺序的执行了 ※
    // ※ 会直接在程序开始时执行Main程序 ※
    // 通用方法
    private void ChangePlayer() // 切换游戏玩家
    {
        if (GameManager.player == PlayerTag.A)
        {
            GameManager.player = PlayerTag.B;
        }
        else
        {
            GameManager.player = PlayerTag.A;
        }
    }

    // 生成地图
    private IEnumerator GeneralMap()// Main
    {
        GeneralMap_Logic();
        yield return GeneralMap_IE();
        yield break;
    }
    private void GeneralMap_Logic()// 逻辑层
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
            printText += "\n";
        }
        Debug.Log(printText);
    }
    private IEnumerator GeneralMap_IE()// 视觉层
    {
        tilemapController.GenralMap();
        yield return new WaitForEndOfFrame();
        Debug.Log($"完成[{nameof(GeneralMap_IE)}]");
        yield break;
    }
    // 抽选角色
    private IEnumerator SelectCharacter()
    {
        // 前处理

        // 等待玩家操作 + 动画

        // 操作是否合理，否则让玩家重新操作并重新等待

        // 逻辑层处理

        // 后处理 

        // 结束
        yield break;
    }
    // 放置角色
    private IEnumerator PlaceCharacter()
    {
        // 第一个玩家操作
        // 前处理
        // 等待玩家操作
        // 判定玩家操作合理性(不合理则重新让玩家操作并等待)
        // PlaceCharacter_A_Logic();
        // 后处理
        // 动画

        ChangePlayer();

        // 第二个玩家操作
        // 前处理
        // 等待玩家操作
        // 判定玩家操作合理性(不合理则重新让玩家操作并等待)
        // PlaceCharacter_A_Logic();
        // 后处理
        // 动画
        // 第二个玩家操作

        yield break;
    }
    private void PlaceCharacter_Logic(Vector2Int positon1, GameObject character1,
                                        Vector2Int positon2, GameObject character2,
                                        Vector2Int positon3, GameObject character3,
                                        Vector2Int positon4, GameObject character4,
                                        Vector2Int positon5, GameObject character5)// 逻辑层处理
    {
        GameManager.map[positon1.x, positon1.y] = character1;
        GameManager.map[positon2.x, positon1.y] = character2;
        GameManager.map[positon3.x, positon1.y] = character3;
        GameManager.map[positon4.x, positon1.y] = character4;
        GameManager.map[positon5.x, positon1.y] = character5;
    }





    private IEnumerator Main()
    {
        yield return GeneralMap();
        yield return SelectCharacter();
    }


    private void Start()
    {
        StartCoroutine(Main());
    }
}
