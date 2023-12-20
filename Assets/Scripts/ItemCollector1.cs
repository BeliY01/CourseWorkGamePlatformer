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
    
    [SerializeField] private Text coinText;
    [SerializeField] private Text kiwiText;
    [SerializeField] private Text orangeText;

    [SerializeField] private AudioSource collectionSoundEffect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("GoldCoin"))
            {
                collectionSoundEffect.Play();
                Destroy(collision.gameObject);
                coin++;
                coinText.text = "Coins: " + coin;
                collectedItems++;
                if (collectedItems >5)
                {
                    Destroy(GameObject.Find("FinalWall"));
                }
            }

            if (collision.gameObject.CompareTag("Kiwi"))
            {
                collectionSoundEffect.Play();
                Destroy(collision.gameObject);
                kiwi++;
                kiwiText.text = "Kiwis: " + kiwi;
                collectedItems++;
                if (collectedItems >5)
                {
                    Destroy(GameObject.Find("FinalWall"));
                }
            }

            if (collision.gameObject.CompareTag("Orange"))
            {
                collectionSoundEffect.Play();
                Destroy(collision.gameObject);
                orange++;
                orangeText.text = "Oranges: " + orange;
                collectedItems++;
                if (collectedItems >5)
                {
                    Destroy(GameObject.Find("FinalWall"));
                }
            }
            
            Debug.Log($"collected {collectedItems}");
    }
    
}
