using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {    
    public enum ItemType{
        Banana,
        Straw
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() {
        switch(itemType) {
        default:
        case ItemType.Banana:   return ItemAssets.Instance.bananaSprite;
        case ItemType.Straw:    return ItemAssets.Instance.strawSprite;
        }
    }

    public bool IsStackable(){
        switch(itemType){
        default:
        case ItemType.Banana:   return true;
        case ItemType.Straw:    return true;
        }
    }
    
}