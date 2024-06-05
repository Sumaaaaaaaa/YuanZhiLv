using System.Collections.Generic;
using UnityEngine;

public class SelectedCards : MonoBehaviour
{
    public static SelectedCards Instance { get; private set; }
    public List<Sprite> cards = new List<Sprite>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

