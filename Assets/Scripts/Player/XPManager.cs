using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPManager : MonoBehaviour
{
    [Header("XP Settings")]
    public float xpPerKill = 2f;
    public float xpMultiplier = 1.2f;

    [Header("UI Settings")]
    public TMP_Text levelText;
    public TMP_Text xpText;
    public Slider xpSlider;

    private int level = 0;
    private float levelProgress = 0.0f;
    private float xpForNextLevel = 10f;

    private void Start()
    {
        UpdateUI();
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
        }
    }
}
