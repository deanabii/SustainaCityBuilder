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

    void UpdateUI() {
        countText.text = count.ToString();
    }
}
