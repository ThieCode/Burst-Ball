using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Translate(0, GameController.Game.data.BaseBulletSpeed * Time.deltaTime, 0);
        if (transform.position.y >= 6) Destroy(gameObject);
	}
}
