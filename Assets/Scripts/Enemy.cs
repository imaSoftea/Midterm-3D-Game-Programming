using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager manager;
    public float frequency = 1f; // Speed of sine wave movement
    public float amplitude = 1f; // Height of sine wave movement

    private Vector3 startPosition;

    void Start()
    {
        manager.UpdateGuiCount(1);
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(0, newY, 0);
    }

    void Death()
    {
        manager.UpdateGuiCount(-1);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision Detected with {other.gameObject.name}");
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Death();
        }

    }

}
