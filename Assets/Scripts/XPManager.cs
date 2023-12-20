using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPManager : MonoBehaviour
{
    [Header("Global")]
    public int targetXP = 100; // Target XP for level One
    [Space]
    [Header("Woodcutting")]
    public int woodcuttingXP = 0;
    public int woodcuttingLevel = 1;
    [Space]
    public int explorationXP = 0;
    public int explorationLevel = 1;
    [Space]
    [Header("Level Up")]
    public TMP_Text levelupText;

    private void Start()
    {
        HideLevelUpText();
    }

    private void Update()
    {
        if (woodcuttingXP >= targetXP)
        {
            LevelUp();
        }
    }

    public void GainXP(int xpAmount)
    {
        Debug.Log("XP: " + woodcuttingXP);
        woodcuttingXP += xpAmount;
    }

    void LevelUp()
    {
        woodcuttingLevel++;
        woodcuttingXP -= targetXP;
        targetXP = CalculateNextTargetXP();
        Debug.Log("Level up! You are now level " + woodcuttingLevel);
        ShowLevelUpText();
        Invoke("HideLevelUpText", 2f);
    }

    int CalculateNextTargetXP()
    {
        return Mathf.FloorToInt(targetXP * 4.0f); // Every time you level up the next level requires 4 times the amount of XP.
    }

    void HideLevelUpText()
    {
        levelupText.gameObject.SetActive(false); // Hide the text
    }
    void ShowLevelUpText()
    {
        levelupText.gameObject.SetActive(true); // Make the text visible
        levelupText.text = "Level Up! You are now level: " + woodcuttingLevel; // Set the text content
    }

}
