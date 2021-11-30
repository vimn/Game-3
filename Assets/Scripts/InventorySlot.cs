using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour, IPointerEnterHandler {

	public Image icon;
	public Button removeButton;
	public Image reforgeSlot;
	public Button reforgeButton;
	public Button cancelReforge;
	public Text name;

	Item item;  // Current item in the slot

    
    public void AddItem (Item newItem)
	{
		item = newItem;
		item.highDamageEnd = 10;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
		reforgeButton.interactable = true;
	}

	public void ReforgeItem(Item reforgeItem)
    {
		item = reforgeItem;

		reforgeSlot.sprite = item.icon;
		reforgeSlot.enabled = true;
		icon.enabled = true;
		cancelReforge.interactable = true;
    }

	// Clear the slot
	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
		reforgeButton.interactable = false;
	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory ()
	{
		Inventory.instance.Remove(item);
	}

	// Use the item
	public void UseItem ()
	{
		if (item != null)
		{
			item.Use();
		}
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
		Debug.Log("pointer detected");
		if(item != null)
        {
			name.text = item.name;
		}
		
    }
}
