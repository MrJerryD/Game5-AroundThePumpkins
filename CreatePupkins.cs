using System.Collections;
using UnityEngine;

public class CreatePupkins : MonoBehaviour
{
    public GameObject pupkins;
    private float waitTime = 1f;
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
        Instantiate(pupkins, new Vector2(-5f, Random.Range(-1.8f, 1.8f)), Quaternion.identity);
        yield return new WaitForSeconds(waitTime); // чтобы не зависла игра, а dick появлялись каждую секунду

        // Завершение корутины после остановки
        isSpawn = false;
    }
}
