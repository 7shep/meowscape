using UnityEngine;

public class XPManager : MonoBehaviour
{
    public int currentXP = 0;
    public int targetXP = 100;
    public int playerLevel = 1;

    private void Update()
    {
        if (currentXP >= targetXP)
        {
            LevelUp();
        }
    }

    public void GainXP(int xpAmount)
    {
        currentXP += xpAmount;
    }

    void LevelUp()
    {
        playerLevel++;
        currentXP -= targetXP;
        targetXP = CalculateNextTargetXP();
        Debug.Log("Level up! You are now level " + playerLevel);
    }

    int CalculateNextTargetXP()
    {
        return Mathf.FloorToInt(targetXP * 2.0f); // Adjust this formula as needed
    }
}
