using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> allPieces; // 所有棋子预制件列表
    private List<GameObject> mainPieces; // 主棋子列表
    private List<GameObject> reservePieces; // 备选棋子列表
    public Transform mainPieceContainer; // 显示主棋子的父对象
    public Transform reservePieceContainer; // 显示备选棋子的父对象
    public int mainPieceCount = 5; // 主棋子的数量
    public int reservePieceCount = 2; // 备选棋子的数量
    private GameObject selectedPiece = null; // 被选中的棋子

    void Start()
    {
        mainPieces = new List<GameObject>();
        reservePieces = new List<GameObject>();
        SelectRandomPieces();
        DisplayPieces();
    }

    void SelectRandomPieces()
    {
        List<GameObject> tempList = new List<GameObject>(allPieces);
        for (int i = 0; i < mainPieceCount; i++)
        {
            int randomIndex = Random.Range(0, tempList.Count);
            mainPieces.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
        }

        for (int i = 0; i < reservePieceCount; i++)
        {
            int randomIndex = Random.Range(0, tempList.Count);
            reservePieces.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
        }
    }

    void DisplayPieces()
    {
        foreach (Transform child in mainPieceContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in reservePieceContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < mainPieces.Count; i++)
        {
            GameObject piece = Instantiate(mainPieces[i], mainPieceContainer);
            int index = i; // 保存当前的索引
            Button button = piece.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => SelectPiece(index, true));
            }
        }

        for (int i = 0; i < reservePieces.Count; i++)
        {
            GameObject piece = Instantiate(reservePieces[i], reservePieceContainer);
            int index = i; // 保存当前的索引
            Button button = piece.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => SelectPiece(index, false));
            }
        }
    }

    void SelectPiece(int index, bool isMainPiece)
    {
        if (selectedPiece == null)
        {
            if (isMainPiece)
            {
                selectedPiece = mainPieces[index];
            }
            else
            {
                selectedPiece = reservePieces[index];
            }
            Debug.Log("Selected piece: " + selectedPiece.name);
        }
        else
        {
            if (isMainPiece)
            {
                GameObject temp = mainPieces[index];
                mainPieces[index] = selectedPiece;
                if (reservePieces.Contains(selectedPiece))
                {
                    reservePieces[reservePieces.IndexOf(selectedPiece)] = temp;
                }
                else
                {
                    mainPieces[mainPieces.IndexOf(selectedPiece)] = temp;
                }
            }
            else
            {
                GameObject temp = reservePieces[index];
                reservePieces[index] = selectedPiece;
                if (mainPieces.Contains(selectedPiece))
                {
                    mainPieces[mainPieces.IndexOf(selectedPiece)] = temp;
                }
                else
                {
                    reservePieces[reservePieces.IndexOf(selectedPiece)] = temp;
                }
            }
            selectedPiece = null;
            DisplayPieces();
        }
    }
}