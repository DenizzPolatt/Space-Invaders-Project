using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private GameObject _shotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ShootEnemy();
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
}
