using UnityEngine;

public class XPManager : MonoBehaviour
{
    [Header("XP Settings")]
    public float xpPerKill = 2f;
    public float xpMultiplier = 1.2f;

    private int level = 0;
    private float levelProgress = 0.0f;
    private float xpForNextLevel = 10f;

    public void AddXP(string eventType)
    {
        switch (eventType)
        {
            case "kill":
                levelProgress += xpPerKill;
                break;
            default:
                break;
        }
        CheckLevelUp();
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
        }
    }
}
