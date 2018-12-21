using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour {

    [SerializeField]
    private Transform mouthPos;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private float timeBetweenShots = 0.4f;

    private void Start()
    {
        StartCoroutine(ShootFireBalls(10));
    }


    IEnumerator ShootFireBalls(int amount)
    {
        yield return new WaitForSecondsRealtime(3f);
        for (int i = 0; i < amount; i++)
        {
            GameObject fireballGO = Instantiate(fireball);
            fireballGO.transform.position = mouthPos.position;
            fireballGO.transform.rotation = mouthPos.rotation;
            yield return new WaitForSecondsRealtime(timeBetweenShots);
        }


    }
}
