using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject enemyShotPrefab;
    private float timer;
    [SerializeField] private PlayerController _player;
    private bool gamestarted;


    // Start is called before the first frame update
    void Start()
    {
        timer += Random.Range(3, 40);
        gamestarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
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

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "PlayerShot(Clone)")
        {
            if (gameObject.CompareTag("Enemy1"))
            {
                _player.Enemy1Score();
            }
 
            if (gameObject.CompareTag("Enemy2"))
            {
               _player.Enemy2Score();
            }
            
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }

    private void MoveEnemy()
    {
        if(gamestarted) gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * 10;

        var enemies = GameObject.FindObjectsOfType<EnemyController>();
        foreach (var enemy in enemies)
        {
            if (enemy.transform.position.x < -55f)
            {
                gamestarted = false;
                gameObject.transform.Translate(Vector3.back * 10 * Time.deltaTime);
                gameObject.transform.GetComponent<Rigidbody>().velocity = Vector3.right * 10;
            }

            if (enemy.transform.position.x > 55f)
            {
                gamestarted = false;
                gameObject.transform.Translate(Vector3.back * 10 * Time.deltaTime);
                gameObject.transform.GetComponent<Rigidbody>().velocity = -Vector3.right * 10;
            }

            if (enemy.transform.position.z < -20)
            {
                _player.GameOver();
            }
        }
    }
    
}
