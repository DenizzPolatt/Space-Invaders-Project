using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private GameObject _shotPrefab;
    [SerializeField] private GameObject live1;
    [SerializeField] private GameObject live2;
    [SerializeField] private GameObject live3;
    private int lives = 3;
    [SerializeField] private Text GameOverText;
    [SerializeField] private Text WinText;
    [SerializeField] private Button restartButton;

    private int score = 0;
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        WinCheck();
        
        scoreText.text = score.ToString();
        MovePlayer();
        ShootEnemy();
        
        if (lives == 2)
        {
            Destroy(live3);
        }

        if (lives == 1)
        {
            Destroy(live2);
        }

        if (lives == 0)
        {
            Destroy(live1);
            GameOver();
        }
    }

    private void MovePlayer()
    {
        //bir kere basarsa
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           transform.Translate(Vector3.right * 2);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * 2);
        }
        
        //basili tutarsa
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 20 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * 20 * Time.deltaTime);
        }
    }

    private void ShootEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_shotPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "EnemyShot(Clone)")
        {
            lives -= 1;
            Destroy(col.gameObject);
        }
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void Enemy1Score()
    {
        score += 10;
    }
    
    public void Enemy2Score()
    {
        score += 20;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void WinCheck()
    {
        var enemy = GameObject.FindObjectsOfType<EnemyController>();
        if (enemy.Length == 0)
        {
            WinText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
}
