using UnityEngine;

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


    private void Update()
    {
        if (woodcuttingXP >= targetXP)
        {
            LevelUp();
        }
    }

    public void GainXP(int xpAmount)
    {
        Debug.Log(woodcuttingXP);
        woodcuttingXP += xpAmount;
    }

    void LevelUp()
    {
        woodcuttingLevel++;
        woodcuttingXP -= targetXP;
        targetXP = CalculateNextTargetXP();
        Debug.Log("Level up! You are now level " + woodcuttingLevel);
    }

    int CalculateNextTargetXP()
    {
        return Mathf.FloorToInt(targetXP * 4.0f); // Every time you level up the next level requires 4 times the amount of XP.
    }
}
