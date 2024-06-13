using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private KitchenCounter parentCounter;
    [SerializeField] private GameObject selectedVisualObject;
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
        selectedVisualObject.SetActive(true);
    }

    private void Hide()
    {
        selectedVisualObject.SetActive(false);
    }
}
