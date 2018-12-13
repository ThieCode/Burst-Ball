using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CannonController : MonoBehaviour {

    public float lerpAmount;
    float displacement;
    float radius = 0.2065f;
    Gun gun;
    int[][] m;

    // Use this for initialization
    void Start () {
        gun = GetComponent<Gun>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            float xCurrent = transform.position.x;
            float mousePositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float targetX = Mathf.Lerp(transform.position.x, mousePositionX, lerpAmount);
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
            displacement = transform.position.x - xCurrent;
            transform.GetChild(0).transform.Rotate(0,0, (-displacement / radius) * Mathf.Rad2Deg);
            transform.GetChild(1).transform.Rotate(0,0, (-displacement / radius) * Mathf.Rad2Deg);
            gun.Active(true);
        }
        if(Input.GetMouseButtonUp(0)) gun.Active(false);
        System.Globalization.NumberFormatInfo nfm = new System.Globalization.NumberFormatInfo();
    }
}
