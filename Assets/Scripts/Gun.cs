using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public float barrelDistance = 0.75f;
    public float barrelSpacing = 0.25f;

    float TimeSinceLastBullet, TimeSinceLastExtraBullet;
    float timer;
    bool active = false;
    int extraBulletsLaunched = 0;
    int maxBPS = 28;
    int barrelCount;
    int BarrelCount
    {
        get
        {
            return (int)(GameController.Game.data.GunTotalBPS / maxBPS);
        }
    }
    int ExtraBullets
    {
        get
        {
            return (int) (GameController.Game.data.GunTotalBPS - (barrelCount * maxBPS));
        }
    }
    Vector2 barrelPosition;

    public float GunCoolDown
    {
        get
        {
            return Mathf.Clamp(1f / GameController.Game.data.GunTotalBPS, 1f/maxBPS, 1f);
        }
    }

    private void Update()
    {
        if (active)
        {
            Fire();
        }
    }

    public void Active(bool value)
    {
        if (value && !active)
        {
            active = value;
            timer = Time.time;
            extraBulletsLaunched = 0;
            barrelCount = BarrelCount;
        }
        else if (!value && active)
        {
            active = value;
        }
    }

    public void Fire()
    {

        barrelPosition = Vector2.zero;
        float barrelWidth = (BarrelCount%2!=0)? (barrelCount - 1) * barrelSpacing : (barrelCount - 1) * barrelSpacing - (barrelSpacing / 2f);
        if ((Time.timeSinceLevelLoad - TimeSinceLastBullet) > GunCoolDown)
        {
            for (int i = 0; i < barrelCount; i++)
            {
                barrelPosition.y = transform.position.y + barrelDistance;
                barrelPosition.x = (transform.position.x - barrelWidth) + (i * barrelSpacing);

                Instantiate(bullet, barrelPosition, Quaternion.identity);
                TimeSinceLastBullet = Time.timeSinceLevelLoad;
            }
        }
        if (extraBulletsLaunched < ExtraBullets)
        {
            if ((Time.timeSinceLevelLoad - TimeSinceLastExtraBullet) > 1f / ExtraBullets)
            {
                barrelPosition.y = transform.position.y + barrelDistance;
                barrelPosition.x = (transform.position.x - barrelWidth) + (barrelCount * barrelSpacing);
                extraBulletsLaunched++;
                Instantiate(bullet, barrelPosition, Quaternion.identity);
                TimeSinceLastExtraBullet = Time.timeSinceLevelLoad;
            }
        }
        if (Time.time - timer >= 1)
        {
            extraBulletsLaunched = 0;
            timer = Time.time;
        }
    }
}
