using System.Collections;
using UnityEngine;


/// <summary>
/// 它拥有对全游戏的流程唯一的控制权，即只有它可以说“现在开始抽牌”、“现在开始A玩家行动”等所有命令。不准一切其他脚本对它发号施令。
/// </summary>
public class FlowControll : MonoBehaviour
{
    [SerializeField] private TilemapController tilemapController;
    [SerializeField] private Canvas Canvas;

    // ※ 细节规则：一切对*逻辑*层面的调用应当是*瞬间*完成的，故使用方法 ※
    // ※ 细节规则：一切对*视觉*、*操作*的调用应当是*等待*的，故使用Coroutine（为了标准化，尽管是瞬时完成的动作也应该使用Coroutine）※
    // ※ 细节规则：最后按顺序放入Main协程中，即可按顺序的执行了 ※
    // ※ 会直接在程序开始时执行Main程序 ※
    // 通用方法
    private IEnumerator Main()
    {
        yield return SelectCharacter();
        yield return SelectCharacter();
        yield return GeneralMap();
        yield break;
    }

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
    [SerializeField] private GameObject draw_card_visual; // prehab
    private IEnumerator SelectCharacter()
    {
        // 等待帧结束，以防止Destory发生在新的组件被建立之后，导致错误的摧毁
        yield return new WaitForEndOfFrame();

        // 生成选择UI的游戏对象
        GameObject target = Instantiate(draw_card_visual,Canvas.transform);

        // 创建一个Lambda一路传到按钮上
        bool draw_card_visual_finished = false;
        string[] Getcards = null;
        var target2 = target.GetComponent<DrawCard_FinishTrigger>().action =
            (string[] cards) => 
            {
                draw_card_visual_finished = true;
                Getcards = cards;
            };

        // 卡死环节
        while (!draw_card_visual_finished)
        {
            yield return null;
        }
        // 完成后
        foreach(string i in Getcards)
        {
            print(i);
        }
        

        // 删除UI的所有游戏对象
        Destroy(target);

        // 结束
        yield break;
    }







    private void Start()
    {
        StartCoroutine(Main());
    }
}
