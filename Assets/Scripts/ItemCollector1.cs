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
    private int apple = 0;
    
    [SerializeField] private Text coinText;
    [SerializeField] private Text appleText;

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
                if (collectedItems >15)
                {
                    Destroy(GameObject.Find("FinalWall"));
                }
            }

            if (collision.gameObject.CompareTag("Apple"))
            {
                collectionSoundEffect.Play();
                Destroy(collision.gameObject);
                apple++;
                appleText.text = "Apple: " + apple;
                collectedItems++;
                if (collectedItems >15)
                {
                    Destroy(GameObject.Find("FinalWall"));
                }
            }
            
            Debug.Log($"collected {collectedItems}");
    }
    
}
