using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private TiQuayController tiQuayController;
    private void Awake(){
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetTiQuayController(TiQuayController tiQuayController){
        this.tiQuayController = tiQuayController;
    }

    public void SetInventory(Inventory inventory){
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshInventoryItems();    
    }

    private void RefreshInventoryItems(){
        foreach(Transform child in itemSlotContainer){
            if(child == itemSlotTemplate) 
                continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 43f;
        foreach(Item item in inventory.GetItemList()){
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>{
                //Use Item
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>{
                inventory.RemoveItem(item);
                ItemWorld.DropItem(tiQuayController.GetPosition(), item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x*itemSlotCellSize, -y*itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>(); 
            image.sprite = item.GetSprite();

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if(item.amount > 1){
                uiText.SetText(item.amount.ToString()); 
            } else {
                uiText.SetText("");
            }
             
            x++;
            if(x > 9){
                x = 0; 
                y++;
            }
        }
    }
}
