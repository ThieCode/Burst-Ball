using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Game;

    public LevelManager levelManager;
    int currentPanel;

    public Data data;
    public GraphicAssets graphicalAssets;
    public Image seperator, panel, upgradeButton;
    public Text panelName, panelValue, upgradeValue, coinText, score;

    void Awake () {
        Game = this;
        Show(0);
	}

    public void Upgrade()
    {
        int currentCost, nextCost = 0;
        switch (currentPanel)
        {
            case 0:
                currentCost =  (int)Mathf.Pow(GameController.Game.data.GunBPSCount + 1, 2);
                nextCost =  (int)Mathf.Pow(GameController.Game.data.GunBPSCount + 2, 2);
                if (GameController.Game.data.PlayerTotalCoins >= currentCost)
                {
                    GameController.Game.data.GunBPSCount += GameController.Game.data.GunBPSUpgradeFactor;
                    panelValue.text = Data.NumberToText(GameController.Game.data.GunTotalBPS) + " pbs";
                    upgradeValue.text = Data.NumberToText(nextCost);
                    GameController.Game.data.PlayerTotalCoins -= currentCost;
                }
                if (GameController.Game.data.PlayerTotalCoins < nextCost)
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                break;
            case 1:
                currentCost = (int)Mathf.Pow(GameController.Game.data.GunPowerUpgradeCount + 1, 2);
                nextCost = (int)Mathf.Pow(GameController.Game.data.GunPowerUpgradeCount + 2, 2);
                if (GameController.Game.data.PlayerTotalCoins >= currentCost)
                {
                    GameController.Game.data.GunPowerUpgradeCount++;
                    panelValue.text = Data.NumberToText(GameController.Game.data.GunPowerFactor * 10) + "0 %";
                    upgradeValue.text = Data.NumberToText(nextCost);
                    GameController.Game.data.PlayerTotalCoins -= currentCost;
                }
                if (GameController.Game.data.PlayerTotalCoins < nextCost)
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                break;
            case 2:
                currentCost = (int)Mathf.Pow(GameController.Game.data.CoinsMultiplierUpgradeCount + 1, 2);
                nextCost = (int)Mathf.Pow(GameController.Game.data.CoinsMultiplierUpgradeCount + 2, 2);
                if (GameController.Game.data.PlayerTotalCoins >= currentCost)
                {
                    GameController.Game.data.CoinsMultiplierUpgradeCount++;
                    panelValue.text = Data.NumberToText(GameController.Game.data.CoinsMultiplierFactor * 10) + "0 %";
                    upgradeValue.text = Data.NumberToText(nextCost);
                    GameController.Game.data.PlayerTotalCoins -= currentCost;
                }
                if (GameController.Game.data.PlayerTotalCoins < nextCost)
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                break;
            case 3:
                currentCost = (int)Mathf.Pow(GameController.Game.data.HullDamageUpgradeCount + 1, 2);
                nextCost = (int)Mathf.Pow(GameController.Game.data.HullDamageUpgradeCount + 2, 2);
                if (GameController.Game.data.PlayerTotalCoins >= currentCost)
                {
                    GameController.Game.data.HullDamageUpgradeCount++;
                    panelValue.text = Data.NumberToText(GameController.Game.data.HullDamageFactor) + " %";
                    upgradeValue.text = Data.NumberToText(nextCost);
                    GameController.Game.data.PlayerTotalCoins -= currentCost;
                }
                if (GameController.Game.data.PlayerTotalCoins < nextCost)
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                break;
        }
        UpdateCoins();
    }

    public void Show(int id)
    {
        switch (id)
        {
            case 0:
                panel.color = GameController.Game.graphicalAssets.GetBioColorItem("Fire Speed").color2;
                seperator.color = GameController.Game.graphicalAssets.GetBioColorItem("Fire Speed").color1;
                panelName.text = GameController.Game.graphicalAssets.GetBioColorItem("Fire Speed").name;
                panelValue.text = Data.NumberToText(GameController.Game.data.GunTotalBPS) + " pbs";
                upgradeValue.text = Data.NumberToText(Mathf.Pow(GameController.Game.data.GunBPSCount + 1, 2));
                if (GameController.Game.data.PlayerTotalCoins < Mathf.Pow(GameController.Game.data.GunBPSCount + 1, 2))
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                else upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Fire Speed").color1;
                currentPanel = 0;
                break;
            case 1:
                panel.color = GameController.Game.graphicalAssets.GetBioColorItem("Fire Power").color2;
                seperator.color = GameController.Game.graphicalAssets.GetBioColorItem("Fire Power").color1;
                panelName.text = GameController.Game.graphicalAssets.GetBioColorItem("Fire Power").name;
                panelValue.text = Data.NumberToText(GameController.Game.data.GunPowerFactor * 10) + "0 %";
                upgradeValue.text = Data.NumberToText(Mathf.Pow(GameController.Game.data.GunPowerUpgradeCount + 1, 2));
                if (GameController.Game.data.PlayerTotalCoins < Mathf.Pow(GameController.Game.data.GunPowerUpgradeCount + 1, 2))
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                else upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Fire Power").color1;
                currentPanel = 1;
                break;
            case 2:
                panel.color = GameController.Game.graphicalAssets.GetBioColorItem("Coins").color2;
                seperator.color = GameController.Game.graphicalAssets.GetBioColorItem("Coins").color1;
                panelName.text = GameController.Game.graphicalAssets.GetBioColorItem("Coins").name;
                panelValue.text = Data.NumberToText(GameController.Game.data.CoinsMultiplierFactor * 10) + "0 %";
                upgradeValue.text = Data.NumberToText(Mathf.Pow(GameController.Game.data.CoinsMultiplierUpgradeCount + 1, 2));
                if (GameController.Game.data.PlayerTotalCoins < Mathf.Pow(GameController.Game.data.CoinsMultiplierUpgradeCount + 1, 2))
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                else upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Coins").color1;
                currentPanel = 2;
                break;
            case 3:
                panel.color = GameController.Game.graphicalAssets.GetBioColorItem("Hull Damage").color2;
                seperator.color = GameController.Game.graphicalAssets.GetBioColorItem("Hull Damage").color1;
                panelName.text = GameController.Game.graphicalAssets.GetBioColorItem("Hull Damage").name;
                panelValue.text = Data.NumberToText(GameController.Game.data.HullDamageFactor) + " %";
                upgradeValue.text = Data.NumberToText(Mathf.Pow(GameController.Game.data.HullDamageUpgradeCount + 1, 2));
                if (GameController.Game.data.PlayerTotalCoins < Mathf.Pow(GameController.Game.data.HullDamageUpgradeCount + 1, 2))
                    upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Inactive Button").color1;
                else upgradeButton.color = GameController.Game.graphicalAssets.GetBioColorItem("Hull Damage").color1;
                currentPanel = 3;
                break;
        }
    }

    public void UpdateCoins()
    {
        coinText.text = Data.NumberToText(GameController.Game.data.PlayerTotalCoins);
    }

    public void StartLevel()
    {
        levelManager = new LevelManager(data.level);
    }

    public void Spawn()
    {
        if (levelManager.totalScoreSpent < levelManager.levelTotalScore)
        {
            BallData ballData = levelManager.GetNextBall();
            GameObject ballGO = Instantiate(graphicalAssets.prefabs[1].go, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            ballGO.layer = 8;
            ballGO.GetComponent<Ball>().Initialized(ballData.hitPoints, ballData.size, ballData.coinWorth);
        }
    }

    #region
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (levelManager == null) StartLevel();
            Spawn();
        }
    }
    #endregion

    public class LevelManager
    {
        public int level;
        public float levelTotalScore;
        public float levelCurrentScore;
        public float progress;
        public float totalScoreSpent;
        float ballWorth;

        public LevelManager(int level)
        {
            this.level = level;
            levelTotalScore = Random.Range(level * level * 7.5f, level * level * 12.5f);
            levelCurrentScore = 0;
            totalScoreSpent = 0;
            progress = 0f;
            ballWorth = level;
            GameController.Game.score.text = levelCurrentScore.ToString();
            Debug.Log("Level " + level + "Started with total score of: " + levelTotalScore);
        }

        public void UpdateScore(float increamentalValue)
        {
            levelCurrentScore += increamentalValue;
            GameController.Game.score.text = ((int)levelCurrentScore).ToString();
        }

        public BallData GetNextBall()
        {
            
            progress = levelCurrentScore / levelTotalScore;
            BallData ball = new BallData();
            float maxScorePerBall = levelTotalScore - levelCurrentScore;
            float ballChance = Random.Range(0f, 1f);
            ball.hitPoints = progress * progress * 10 * level + level;
            if (ballChance > 0.95f)
            {
                ball.size = 3;
            }
            else if(ballChance > 0.70f)
            {
                ball.size = 2;
            }
            else if (ballChance > 0.15f)
            {
                ball.size = 1;
            }
            else
            {
                ball.size = 0;
            }
            ball.hitPoints *= Mathf.Pow(2, ball.size);
            totalScoreSpent += ball.hitPoints;
            ball.coinWorth = (int)(ball.hitPoints / 10f);
            Debug.Log("Spent: " + ball.hitPoints + "Total Spent now: " + totalScoreSpent);
            return ball;
        }
    }

    public struct BallData
    {
        public int size;
        public float hitPoints;
        public int coinWorth;
    }
}
