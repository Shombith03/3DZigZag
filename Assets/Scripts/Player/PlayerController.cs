using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    internal float _ballSpeed;
    [SerializeField]
    private GameObject _particle;
    [SerializeField]
    private AudioClip _colletiblesEffect;
    private bool started = false;
    private Rigidbody _rigidbody;
    bool gameOver = false;
    [SerializeField]
    private ScoreManager _scoreManager;
    [SerializeField]
    private PlatformSpawner _spawner;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(started)
        {
            if (!Physics.Raycast(transform.position, Vector3.down, 1f))
            {
                gameOver = true;
                _rigidbody.velocity = new Vector3(0, -25f, 0f);
                Camera.main.GetComponent<SmoothCameraFollow>()._gameOver = true;

                GameManager.Instance.GameOver();
            }

            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                SwitchDirections();
                _spawner.ChangePlatformColor();
            }
        }
    }

    public void StartGameButton()
    {
        if (!started)
        {
            _rigidbody.velocity = new Vector3(_ballSpeed, 0, 0);
            started = true;

            GameManager.Instance.StartGame();
        }
    }

    private void SwitchDirections()
    {
        if(_rigidbody.velocity.z > 0)
        {
            _rigidbody.velocity = new Vector3(_ballSpeed, 0, 0);
        }
        else if(_rigidbody.velocity.x > 0)
        {
            _rigidbody.velocity = new Vector3(0, 0, _ballSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectibles"))
        {
            GameObject particle = Instantiate(_particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(particle, 1f);
            Camera.main.GetComponent<AudioSource>().PlayOneShot(_colletiblesEffect);
            _scoreManager.IncrementScore();
        }
    }
}
