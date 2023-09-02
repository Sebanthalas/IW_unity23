using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private float cherries = 0f;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Butts :" + cherries;
            collectionSoundEffect.Play();
        }
    }
    
}
