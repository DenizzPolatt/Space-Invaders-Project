using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject enemyShotPrefab;
    private float timer;
    private float timer2;
    private float gameBegun;
    // Start is called before the first frame update
    void Start()
    {
        timer += Random.Range(3, 40);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        ShootPlayer();
    }

    private void ShootPlayer()
    {
        float randomTime = Random.Range(5, 30);
        if (timer < 0)
        {
            timer += randomTime;
            Instantiate(enemyShotPrefab, transform.position, Quaternion.identity);
        }

    }
    
}
