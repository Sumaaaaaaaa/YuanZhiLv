using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getButton : MonoBehaviour
{
    public Button decideButton; // 决定按钮
    public CardManager cardManager; // 卡牌管理器
    public Action<string[]> finishAction;

    void Start()
    {
        decideButton.onClick.AddListener(OnButtonClick);
        decideButton.interactable = false; // 初始时禁用按钮
    }

    // 逐帧判断是否选择五张卡片，当选择到五张卡片时启用按钮
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

    void OnButtonClick()
    {
        List<Sprite> selectedcard = cardManager.GetComponent<CardManager>().GetSelectedCards();
        List<string> returnStrings = new List<string>();
        foreach(Sprite i in selectedcard)
        {
            returnStrings.Add(i.name);
        }
        finishAction(returnStrings.ToArray());
        return;
    }
}