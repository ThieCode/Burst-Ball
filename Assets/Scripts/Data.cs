using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Game Assets/Data", order = 1)]
public class Data : ScriptableObject {

    public float BaseBulletSpeed = 8;

    public float GunBaseBallsPerSeconds = 1;
    public float GunBPSUpgradeFactor = 1;
    public float GunBPSCount = 1;

    public float GunBasePower = 1;
    public float GunPowerUpgradeFactor = 0.1f; 
    public int GunPowerUpgradeCount = 0;

    public float CoinsBaseMultiplier = 1;
    public float CoinsMultiplierUpgradeFactor = 0.1f;
    public int CoinsMultiplierUpgradeCount = 0;

    public float HullBaseDamage = 1;
    public float HullDamageUpgradeFactor = 0.1f;
    public float HullDamageUpgradeCount = 0;

    public int PlayerTotalCoins = 0;

    public int level = 32;
    public float[] ballsMaxHeight = new float[] { 6f, 7f, 7.5f, 8f };
    public float[] ballsRadius = new float[] { .35f, .52f, .78f, 1.05f };

    public float GunTotalBPS
    {
        get
        {
            return GunBPSCount * GunBaseBallsPerSeconds;
        }
    }

    public float GunPowerFactor
    {
        get
        {
            return GunBasePower + (GunPowerUpgradeCount * GunBasePower) * GunPowerUpgradeFactor;
        }
    }

    public float CoinsMultiplierFactor
    {
        get
        {
            return CoinsBaseMultiplier + (CoinsMultiplierUpgradeCount * CoinsBaseMultiplier) * CoinsMultiplierUpgradeFactor;
        }
    }

    public float HullDamageFactor
    {
        get
        {
            return (HullDamageUpgradeCount * HullBaseDamage) * CoinsMultiplierUpgradeFactor;
        }
    }

    public static string NumberToText(int num)
    {
        int outInt = 0;
        string output = num.ToString();
        if (num >= 1000)
        {
            outInt = (int)(num / 1000);
            num -= outInt * 1000;
            output = outInt.ToString();
            if (num >= 100)
            {
                outInt = (int)(num / 100);
                output += "." + outInt.ToString();
            }
            output += "k";
        }
        return output;
    }

    public static string NumberToText(float num)
    {
        return NumberToText((int)num);
    }
}
