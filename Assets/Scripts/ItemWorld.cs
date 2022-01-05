using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item){
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        
        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item){
        ItemWorld itemWorld = SpawnItemWorld(dropPosition, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(Vector3.zero,ForceMode2D.Impulse);
        return itemWorld;
    }

    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item){
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }            

    public Item GetItem(){
        return item;
    }

    public void DestroySelf(){
        Destroy(gameObject);
    }
}
