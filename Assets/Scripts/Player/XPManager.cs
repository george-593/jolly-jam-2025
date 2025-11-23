using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class XPManager : MonoBehaviour
{
    [Header("XP Settings")]
    public float xpPerKill = 2f;
    public float xpMultiplier = 1.2f;

    [Header("UI Settings")]
    public TMP_Text levelText;
    public TMP_Text xpText;
    public Slider xpSlider;
    public GameObject levelUpContainer;
    public GameObject[] upgradePanels;

    [Header("References")]
    public PlayerController player;
    public Weapon weapon;

    private int level = 0;
    private float levelProgress = 0.0f;
    private float xpForNextLevel = 10f;

    public enum UpgradeType
    {
        Speed = 0,
        Damage = 1,
        MaxHealth = 2,
        MaxWarmth = 3
    }

    private void Start()
    {
        UpdateUI();
        levelUpContainer.SetActive(false);
    }

    public void AddXP(string eventType)
    {
        switch (eventType)
        {
            case "kill":
                levelProgress += xpPerKill;
                UpdateUI();
                break;
            default:
                break;
        }
        CheckLevelUp();
    }

    private void UpdateUI()
    {
        xpText.text = $"{levelProgress} / {xpForNextLevel}";
        xpSlider.value = levelProgress;
        levelText.text = $"Level: {level}";
        xpSlider.maxValue = xpForNextLevel;
    }

    private void CheckLevelUp()
    {
        if (levelProgress >= xpForNextLevel)
        {
            level += 1;
            levelProgress = 0f;
            xpForNextLevel *= xpMultiplier;

            Debug.Log("Level Up! Level: " + level + " | Next XP Goal: " + xpForNextLevel);

            // Level Up UI
            UpdateUI();
            ShowLevelUpMenu();
        }
    }

    private void ShowLevelUpMenu()
    {
        Time.timeScale = 0;
        levelUpContainer.SetActive(true);

        List<UpgradeType> availableUpgrades = new List<UpgradeType>();
        foreach (UpgradeType upgrade in Enum.GetValues(typeof(UpgradeType)))
        {
            availableUpgrades.Add(upgrade);
        }

        foreach (GameObject upgradePanel in upgradePanels)
        {
            Debug.Log(upgradePanel);
            int randomIndex = UnityEngine.Random.Range(0, availableUpgrades.Count);
            UpgradeType selectedUpgrade = availableUpgrades[randomIndex];

            availableUpgrades.RemoveAt(randomIndex);

            TMP_Text[] texts = upgradePanel.GetComponentsInChildren<TMP_Text>();
            texts[1].text = GetUpgradeName(selectedUpgrade);

            Button upgradeBtn = upgradePanel.GetComponentInChildren<Button>();

            upgradeBtn.onClick.RemoveAllListeners();
            upgradeBtn.onClick.AddListener(() => LevelUpCallback((int)selectedUpgrade));
        }
    }

    private string GetUpgradeName(UpgradeType type)
    {
        switch (type)
        {
            case UpgradeType.Speed: return "Move Speed +";
            case UpgradeType.Damage: return "Damage +";
            case UpgradeType.MaxHealth: return "Health +";
            case UpgradeType.MaxWarmth: return "Warmth +";
            default: return "Upgrade";
        }
    }

    public void LevelUpCallback(int upgradeIndex)
    {
        UpgradeType upgrade = (UpgradeType)upgradeIndex;

        Debug.Log("Player chose upgrade: " + upgrade);

        // Apply stats to player
        switch (upgrade)
        {
            case UpgradeType.Damage:
                weapon.damage += 10;
                break;
            case UpgradeType.MaxHealth:
                player.health += 25;
                break;
            case UpgradeType.MaxWarmth:
                player.warmth += 25;
                break;
            case UpgradeType.Speed:
                player.moveSpeed += 2;
                break;
            default:
                break;
        }

        levelUpContainer.SetActive(false);
        Time.timeScale = 1;
    }
}