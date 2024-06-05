using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard_FinishTrigger : MonoBehaviour
{
    [SerializeField] private getButton buttonScript;
    public Action<string[]> action;
    private void Start()
    {
        buttonScript.finishAction = action;
    }
}
