using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    public Collider Bola;
    public GameObject Coin;
    private SpawnCoin Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Spawner = FindObjectOfType<SpawnCoin>();
    }

    // Update is called once per frame
    void Update()
    {
        SpinTheCoin();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Bola"))
        {
            Spawner.CoinDespawned();
            Destroy(gameObject);
        }
    }

    private void SpinTheCoin()
    {
        transform.Rotate(0f, 0f, 50f * Time.deltaTime, Space.Self);
    }
}
