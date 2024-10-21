using Core.Interact;
using Core.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTopPanel : MonoBehaviour
{
    private TopPanel topPanel;
    private void Awake()
    {
        topPanel = FindObjectOfType<TopPanel>();
    }

    public void ShowPanel()
    {
        if (topPanel == null) return;
        topPanel.ShowPanel();
    }

    public void HidePanel()
    {
        if(topPanel == null) return;
        topPanel.HidePanel();
    }
}
