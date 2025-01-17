using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // 卡牌预制件
    public List<Sprite> cardFronts; // 所有卡牌正面的图片列表
    public Transform cardContainer; // 存放卡牌的UI的容器
    public int totalCards = 21; // 卡牌总数
    public int maxSelections = 5; // 最大选择数量
    private List<GameObject> selectedCards = new List<GameObject>();
    
    void Start()
    {
        if (cardPrefab == null)
        {
            Debug.LogError("Card Prefab is not assigned.");
            return;
        }

        if (cardContainer == null)
        {
            Debug.LogError("Card Container is not assigned.");
            return;
        }

        if (cardFronts == null || cardFronts.Count < totalCards)
        {
            Debug.LogError("Card Fronts are not properly assigned or not enough sprites provided.");
            return;
        }

        GenerateCards();
    }

    void GenerateCards()
    {
        // 创建一个随机序列（int）
        List<int> randomIndices = new List<int>();
        for (int i = 0; i < totalCards; i++)
        {
            randomIndices.Add(i);
        }
        Shuffle(randomIndices);

        for (int i = 0; i < totalCards; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardContainer);
            FlipCard flipCard = card.GetComponent<FlipCard>();

            if (flipCard == null)
            {
                Debug.LogError("FlipCard component is missing on the card prefab.");
                continue;
            }
            // 获得一个随机的Sprite赋值给 生成的卡片
            int randomIndex = randomIndices[i];
            flipCard.cardFront = cardFronts[randomIndex];

            Button button = card.GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Button component is missing on the card prefab.");
                continue;
            }

            button.onClick.AddListener(() => SelectCard(card));
        }
    }

    static private void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void SelectCard(GameObject card)
    {
        if (!selectedCards.Contains(card) & (selectedCards.Count < maxSelections))
        {
            selectedCards.Add(card);
            card.GetComponent<Image>().color = Color.green; // 选中后变色
            card.GetComponent<FlipCard>().Flip();
        }
    }
    public List<Sprite> GetSelectedCards()
    {
        List<Sprite> selectedCardFronts = new List<Sprite>();
        foreach (GameObject card in selectedCards)
        {
            FlipCard flipCard = card.GetComponent<FlipCard>();
            if (flipCard != null)
            {
                selectedCardFronts.Add(flipCard.cardFront);
            }
        }
        return selectedCardFronts;
    }

    public int SelectedCardCount()
    {
        return selectedCards.Count;
    }
}


