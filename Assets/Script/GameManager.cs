using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text countText;
    [SerializeField] TMP_Text incomeText;
    [SerializeField] UpgradeBuilding[] upgradeBuilding;
    [SerializeField] int updatesPerSecond = 5;

    [HideInInspector] public float count = 0;
    float nextTimeCheck = 1;
    float lastIncomeValue = 0;

    private void Start() {
        LoadGame();
    }

    void Update() {
        if (nextTimeCheck < Time.timeSinceLevelLoad) {
            IdleCalculate();
            nextTimeCheck = Time.timeSinceLevelLoad + (1f / updatesPerSecond);
        }
    }

    void IdleCalculate() {
        float sum = 0;
        foreach (var upgradeBuilding in upgradeBuilding)
        {
            sum += upgradeBuilding.CalculateIncomePerSecond();
            upgradeBuilding.UpdateUI();
        }
        lastIncomeValue = sum;
        count += sum / updatesPerSecond;
        UpdateUI();
    }

     public void ClickAction() {
        count++;
        count += lastIncomeValue * 0.02f;
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
        countText.text = Mathf.RoundToInt(count).ToString();
        incomeText.text = lastIncomeValue.ToString() + "/s";
    }

    public void SaveGame() {
        PlayerPrefs.SetFloat("TotalCoins", count);

        foreach (var building in upgradeBuilding) {
            building.SaveData();
        }

        PlayerPrefs.Save();
        Debug.Log("Game Saved!");
    }

    public void LoadGame() {
        count = PlayerPrefs.GetFloat("TotalCoins", 0);

        foreach (var building in upgradeBuilding) {
            building.LoadData();
        }

        float totalIncome = 0;
        foreach (var building in upgradeBuilding) {
            totalIncome += building.CalculateIncomePerSecond();
        }
        lastIncomeValue = totalIncome;

        UpdateUI();
    }

    private void OnApplicationQuit(){
        SaveGame();
    }
}
