using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedCards : MonoBehaviour
{
    public Transform cardContainer; // 用于存放卡牌的容器
    public GameObject cardPrefab; // 卡牌预制件

    void Start()
    {
        if (SelectedCards.Instance == null)
        {
            Debug.LogError("SelectedCards instance is null.");
            return;
        }

        List<Sprite> selectedCards = SelectedCards.Instance.cards;
        Debug.Log("Number of selected cards: " + selectedCards.Count);

        foreach (Sprite cardFront in selectedCards)
        {
            GameObject card = Instantiate(cardPrefab, cardContainer);
            FlipCard flipCard = card.GetComponent<FlipCard>();
            if (flipCard != null)
            {
                flipCard.cardFront = cardFront;
                flipCard.cardBack = cardPrefab.GetComponent<FlipCard>().cardBack;

                // 设置卡牌的正面图片
                Image image = card.GetComponent<Image>();
                if (image != null)
                {
                    image.sprite = cardFront;
                    Debug.Log("Card instantiated with front: " + cardFront.name);
                }
            }
        }
    }
}