using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _rigidbody;
    public float force;
    private AudioSource _audioSource;

    public Vector2 direct;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        //_audioSource=GetComponent<AudioSource>();
        Destroy(this.gameObject,1f);
    }

    private void OnEnable()
    {
        //_audioSource.Play();
    }

    public void SetSpeed(Vector2 direction)
    {
        direct = direction;
        _rigidbody.velocity = (direction * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.transform.CompareTag("Ground"))
        // {
        Destroy(gameObject);
        //}
    }
}