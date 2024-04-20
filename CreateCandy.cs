using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCandy : MonoBehaviour
{
    public GameObject candy;
    private float waitTime = 3.5f;
    private bool isSpawn;

    private void Update()
    {
        if (!isSpawn)
        {
            StartCoroutine(spawnDicks());
            isSpawn = true;
        }
    }

    IEnumerator spawnDicks()
    {
        Instantiate(candy, new Vector2(-7f, Random.Range(-1.2f, 1.2f)), Quaternion.identity);
        yield return new WaitForSeconds(waitTime); // чтобы не зависла игра, а dick появлялись каждую секунду

        // Завершение корутины после остановки
        isSpawn = false;
    }
}
