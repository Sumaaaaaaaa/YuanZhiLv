using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlipCard : MonoBehaviour
{
    public Sprite cardFront; // 卡牌正面的图片
    public Sprite cardBack;  // 卡牌背面的图片
    public bool isFlipped = false; // 卡牌是否已经翻转
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        if (isFlipped)
        {
            image.sprite = cardFront; // 如果卡牌已经翻转，则显示正面
        }
        else
        {
            image.sprite = cardBack; // 否则显示背面
        }
    }

    public void Flip()
    {
        if (!isFlipped)
        {
            StartCoroutine(FlipAnimation());
        }
    }

    IEnumerator FlipAnimation()
    {
        // 进行翻牌动画
        for (float i = 0; i <= 1; i += Time.deltaTime * 2)
        {
            transform.localScale = new Vector3(Mathf.Lerp(1, 0, i), 1, 1);
            yield return null;
        }

        // 切换图片
        image.sprite = cardFront;
        isFlipped = true;

        // 继续翻牌动画
        for (float i = 0; i <= 1; i += Time.deltaTime * 2)
        {
            transform.localScale = new Vector3(Mathf.Lerp(0, 1, i), 1, 1);
            yield return null;
        }
    }
}
