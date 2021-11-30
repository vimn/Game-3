using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items{

    public enum ItemType
    {
        Sword,
        Dagger,
        Potion,
        Shield,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:    return ItemAssets.Instance.swordSprite;
            case ItemType.Dagger:   return ItemAssets.Instance.daggerSprite;
            case ItemType.Potion:   return ItemAssets.Instance.potionSprite;
            case ItemType.Shield:   return ItemAssets.Instance.shieldSprite;
         
        }
    }
}
