using System.Collections.Generic;
using UnityEngine;

public class SelectedCards : MonoBehaviour
{
    public static SelectedCards Instance { get; private set; }
    public List<Sprite> cards;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            cards = new List<Sprite>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

