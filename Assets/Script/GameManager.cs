using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text countText;

    int count = 0;

    private void Start() {
        UpdateUI();
    }

     public void ClickAction() {
        count++;
        UpdateUI();
    }

    public bool PurchaseAction(int cost) {
        if (count >= cost) {
            count -= cost;
            UpdateUI();
            return true;
        }
        return false;
    }

    void UpdateUI() {
        countText.text = count.ToString();
    }
}
