using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter parentCounter;
    [SerializeField] private GameObject[] selectedVisualObjectArray;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.newKitchenCounter == parentCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach(GameObject visualObject in selectedVisualObjectArray)
            visualObject.SetActive(true);
    }

    private void Hide()
    {
        foreach (GameObject visualObject in selectedVisualObjectArray)
            visualObject.SetActive(false);
    }
}
