using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int value;
    // Use this for initialization
    void Start () {
        Vector2 v = new Vector2(Random.Range(-100, 100), Random.Range(100, 140));
        GetComponent<Rigidbody2D>().AddForce(v);
        Physics2D.IgnoreLayerCollision(8, 8);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.transform.tag == "Player")
        {
            Destroy(gameObject);
            GameController.Game.data.PlayerTotalCoins += value;
            GameController.Game.UpdateCoins();
        }
    }
}
