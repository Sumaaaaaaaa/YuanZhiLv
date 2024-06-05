using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getButton : MonoBehaviour
{
    public Button decideButton; // 决定按钮
    public CardManager cardManager; // 卡牌管理器

    void Start()
    {
        decideButton.onClick.AddListener(OnDecideButtonClicked);
        decideButton.interactable = false; // 初始时禁用按钮
    }

    void Update()
    {
        // 检查是否选择了五张卡牌
        if (cardManager.SelectedCardCount() == cardManager.maxSelections)
        {
            decideButton.interactable = true; // 启用按钮
        }
        else
        {
            decideButton.interactable = false; // 禁用按钮
        }
    }

    void OnDecideButtonClicked()
    {
        // 获取选择的卡牌
        List<Sprite> selectedCards = cardManager.GetSelectedCards();

        if (SelectedCards.Instance != null)
        {
            // 存储选择的卡牌
            SelectedCards.Instance.cards = selectedCards;

            // 切换到下一个场景
            SceneManager.LoadScene("duel"); // 确保这个名称与构建设置中的名称一致
        }
        else
        {
            Debug.LogError("SelectedCards instance is null.");
        }
    }
}