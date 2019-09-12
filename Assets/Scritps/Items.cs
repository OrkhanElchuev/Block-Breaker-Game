using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // configuration parameters
    [SerializeField] GameObject itemSparkleVFX;
    //[SerializeField] AudioClip breakSound;
    [SerializeField] Sprite[] hitSprites;
     
    // cached references
    LevelScript level;

    // state variables
    [SerializeField] int timesHit;  

    private void Start()
    {
        CountBreakableItems();
    }

    private void CountBreakableItems()
    {
        level = FindObjectOfType<LevelScript>();
        if (tag == "Breakable")
        {
            level.CountItems();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyItem();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyItem()
    {
        FindObjectOfType<GameStatus>().AddToScore();

        Destroy(gameObject);
        level.ItemDestroyed();

        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(itemSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

