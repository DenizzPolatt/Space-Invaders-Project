using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject enemyShotPrefab;

    private float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        ShootPlayer();
    }

    private void ShootPlayer()
    {
        float randomTime = Random.Range(1, 5);

        if (timer < 0)
        {
            timer += randomTime;
            Instantiate(enemyShotPrefab, transform.position, Quaternion.identity);
        }

    }
}
