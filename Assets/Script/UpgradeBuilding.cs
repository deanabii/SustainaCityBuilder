using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeBuilding : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public TMP_Text incomeInfoText;
    public Button button;
    public Image characterImage;
    public TMP_Text upgradeNameText;

    [Header("Generator values")]
    public string upgradeName;
    public int startPrice = 15;
    public float upgradePriceMultiplier;
    public float coinPerUpgrade = 0.1f;

    [Header("Managers")]
    public GameManager gameManager;

    int level = 0;

    private void Start() {
        UpdateUI();
    }

    public void ClickAction() {
        int price = CalculatePrice();
        bool purchaseSuccess = gameManager.PurchaseAction(price);
        if (purchaseSuccess) {
            level++;
            UpdateUI();
        }
    }

    public void UpdateUI() {
        priceText.text = CalculatePrice().ToString();
        incomeInfoText.text = level.ToString() + " x " + coinPerUpgrade + "/s";

        bool canAfford = gameManager.count >= CalculatePrice();
        button.interactable = canAfford;

        bool isPurchased = level > 0;
        characterImage.color = isPurchased ? Color.white : Color.black;
        upgradeNameText.text = isPurchased ? upgradeName : "???";
    }

    int CalculatePrice() {
        int price = Mathf.RoundToInt(startPrice * Mathf.Pow(upgradePriceMultiplier, level));
        return price;
    }

    public float CalculateIncomePerSecond() {
        return coinPerUpgrade * level;
    }

    // Tambahkan di dalam UpgradeBuilding.cs
    public void SaveData() {
        PlayerPrefs.SetInt("Level_" + upgradeName, level); 
    }

    public void LoadData() {
        level = PlayerPrefs.GetInt("Level_" + upgradeName, 0);
        UpdateUI();
    }
}
