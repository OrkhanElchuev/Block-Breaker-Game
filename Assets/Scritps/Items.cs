using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // configuration parameters
    [SerializeField] GameObject itemSparkleVFX;
    [SerializeField] Sprite[] hitSprites;
     
    // variables
    LevelScript level;

    // state variables
    [SerializeField] int timesHit;  

    private void Start()
    {
        CountBreakableItems();
    }

    // Counting breakable items in the level, created for debugging purposes
    private void CountBreakableItems()
    {
        level = FindObjectOfType<LevelScript>();
        // Items with tag "breakable" will be counted
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

    // Handling different representations of object after getting damaged
    private void HandleHit()
    {
        // Different amount of damage stages can be handled
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

    // Loading next condition(damaged) of item after collision with ball
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Item's sprite is missing from array" + gameObject.name);
        }
    }

    // Destroying item and triggering sparkle animation on destroy
    private void DestroyItem()
    {
        FindObjectOfType<GameStatus>().AddToScore();

        Destroy(gameObject);
        level.ItemDestroyed();

        TriggerSparklesVFX();
    }

    // Sparkle animation handling
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(itemSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

