using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float currentHitPoints;
    public float initialHitPoints;
    public int coinWorth;
    public int size;
    public float maxHeight;
    Text text;

    public void Initialized(float initialHP, int size, float coinWorth)
    {
        initialHitPoints = initialHP;
        currentHitPoints = initialHP;
        this.size = size;
        this.coinWorth = (int) coinWorth;
        text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        text.text = Data.NumberToText(currentHitPoints);
        Physics2D.IgnoreLayerCollision(8, 8);
        UpdateGraphic();
    }

    void Start()
    {
        text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        text.text = Data.NumberToText(currentHitPoints);
        Physics2D.IgnoreLayerCollision(8, 8);
        UpdateGraphic();
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.transform.tag == "Bullet")
        {
            currentHitPoints -= GameController.Game.data.GunPowerFactor;
            GameController.Game.levelManager.UpdateScore(GameController.Game.data.GunPowerFactor);
            text.text = Data.NumberToText(currentHitPoints);//Update Text On Ball for ex: 1.2k
            Destroy(collide.gameObject);
            if (currentHitPoints <= 0) Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.transform.tag == "Ground")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x, -1.5f, 1.5f), maxHeight);
        }
        if (collide.transform.tag == "Walls")
        {
            //add rotational velocity to the canvas.....
        }
    }

    void UpdateGraphic()
    {
        Data data = GameController.Game.data;
        GetComponent<SpriteRenderer>().sprite = GameController.Game.graphicalAssets.ballsSprites[size];
        transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta= new Vector2(data.ballsRadius[size]*100, data.ballsRadius[size]*100);
        GetComponent<CircleCollider2D>().radius = data.ballsRadius[size];
        maxHeight = data.ballsMaxHeight[size];
    }

    void OnDestroy()
    {
        int[] coinPieces = new int[6];

        coinPieces[0] = (coinWorth >= 200) ? (coinWorth - (coinWorth % 200)) / 200 : 0;
        coinWorth = coinWorth % 200;

        coinPieces[1] = (coinWorth >= 100) ? (coinWorth - (coinWorth % 100)) / 100 : 0;
        coinWorth = coinWorth % 100;

        coinPieces[2] = (coinWorth >= 50) ? (coinWorth - (coinWorth % 50)) / 50 : 0;
        coinWorth = coinWorth % 50;

        coinPieces[3] = (coinWorth >= 10) ? (coinWorth - (coinWorth % 10)) / 10 : 0;
        coinWorth = coinWorth % 10;

        coinPieces[4] = (coinWorth >= 5) ? (coinWorth - (coinWorth % 5)) / 5 : 0;
        coinWorth = coinWorth % 5;

        coinPieces[5] = (coinWorth >= 1) ? (coinWorth - (coinWorth % 1)) / 1 : 0;
        coinWorth = coinWorth % 1;

        GameObject go;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < coinPieces[i]; j++)
            {
                //Debug.Log(i + " : " + j);
                switch (i)
                {
                    case 0:
                        go = Instantiate(GameController.Game.graphicalAssets.GetPrefabItem("Coin_200").go, transform.position, Quaternion.identity);
                        go.GetComponent<Coin>().value = 200;
                        break;
                    case 1:
                        go = Instantiate(GameController.Game.graphicalAssets.GetPrefabItem("Coin_100").go, transform.position, Quaternion.identity);
                        go.GetComponent<Coin>().value = 100;
                        break;
                    case 2:
                        go = Instantiate(GameController.Game.graphicalAssets.GetPrefabItem("Coin_50").go, transform.position, Quaternion.identity);
                        go.GetComponent<Coin>().value = 50;
                        break;
                    case 3:
                        go = Instantiate(GameController.Game.graphicalAssets.GetPrefabItem("Coin_10").go, transform.position, Quaternion.identity);
                        go.GetComponent<Coin>().value = 10;
                        break;
                    case 4:
                        go = Instantiate(GameController.Game.graphicalAssets.GetPrefabItem("Coin_5").go, transform.position, Quaternion.identity);
                        go.GetComponent<Coin>().value = 5;
                        break;
                    case 5:
                        go = Instantiate(GameController.Game.graphicalAssets.GetPrefabItem("Coin_1").go, transform.position, Quaternion.identity);
                        go.GetComponent<Coin>().value = 1;
                        break;
                }
            }
        }
    }

    public enum ShopType
    {
        AttackSpeed = 0,
        AttackPower = 1,
        CoinYeild = 2,
        HullDamage = 3
    }
}
