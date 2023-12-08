using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int totalItems = 33;
    private int collectedItems = 0;
    
    private int coin = 0;
    private int kiwi = 0;
    private int orange = 0;

    private bool levelCompleted = false;

    [SerializeField] private Text coinText;
    [SerializeField] private Text kiwiText;
    [SerializeField] private Text orangeText;

    [SerializeField] private AudioSource collectionSoundEffect;
    private AudioSource finishSound;

    void Start()
    {
        finishSound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectedItems++;
        levelCompleted = true;
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();
            if (collectedItems==totalItems)
            {
                Invoke("CompleteLevel", 2f);
            }

        }

        if (collision.gameObject.CompareTag("GoldCoin"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coin++;
            coinText.text = "Coins: " + coin;
        }

        if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            kiwi++;
            kiwiText.text = "Kiwis: " + kiwi;
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            orange++;
            orangeText.text = "Oranges: " + orange;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
