using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Image icon;
	public Button removeButton;
	public Image reforgeSlot;
	public Button reforgeButton;
	public Button cancelReforge;
	public Text name;
	public Text damageRange;
	public Text primary1;
	public Text primary2;
	public Text primary3;
	public Text primary4;
	public Text secondary1;
	public Text secondary2;

	public GameObject reforgeBlock;
	public Text reforgeName;
	public Text reforgeDamageRange;
	public Text reforgePrimary1;
	public Text reforgePrimary2;
	public Text reforgePrimary3;
	public Text reforgePrimary4;
	public Text reforgeSecondary1;
	public Text reforgeSecondary2;
	private int seed;

	public Image highlightedSlot;

	Item item;  // Current item in the slot


	public void AddItem(Item newItem)
	{
		item = newItem;

		//damage range
		item.lowDamageEnd = Random.Range(1000, 2000);
		item.highDamageEnd = Random.Range(2000, 3500);
		seed = Random.Range(1, 8);
		if (seed == 1)
		{
			item.damageType = "Physical";
		}
		if (seed == 2)
		{
			item.damageType = "Arcane";
		}
		if (seed == 3)
		{
			item.damageType = "Cold";
		}
		if (seed == 4)
		{
			item.damageType = "Fire";
		}
		if (seed == 5)
		{
			item.damageType = "Holy";
		}
		if (seed == 6)
		{
			item.damageType = "Lightning";
		}
		if (seed == 7)
		{
			item.damageType = "Poison";
		}
		item.damageRange = item.lowDamageEnd + " - " + item.highDamageEnd + " " + item.damageType + " damage.";
		//primary stat 1
		seed = Random.Range(1, 4);
		item.primaryStat1 = Random.Range(500, 751);
		if (seed == 1)
		{
			item.primaryStatType1 = " Strength";
		}
		if (seed == 2)
		{
			item.primaryStatType1 = " Agility";
		}
		if (seed == 3)
		{
			item.primaryStatType1 = " Intelligence";
		}

		//primary stat 2
		seed = Random.Range(1, 4);
		if (seed == 1)
		{
			item.primaryStatType2 = " Armor";
			item.primaryStat2 = Random.Range(1, 501);
		}
		if (seed == 2)
		{
			item.primaryStatType2 = " % Life";
			item.primaryStat2 = Random.Range(1, 21);
		}
		if (seed == 3)
		{
			item.primaryStatType2 = " Resist All";
			item.primaryStat2 = Random.Range(1, 151);
		}

		//primary stat 3
		seed = Random.Range(1, 4);
		if (seed == 1)
		{
			item.primaryStatType3 = " Life on Hit";
			item.primaryStat3 = Random.Range(500, 1501);
		}
		if (seed == 2)
		{
			item.primaryStatType3 = " Life Regeneration";
			item.primaryStat3 = Random.Range(100, 501);
		}
		if (seed == 3)
        {
			item.primaryStatType3 = " % Life Steal on Hit";
			item.primaryStat3 = Random.Range(5, 11);
        }

		//primary stat 4
		seed = Random.Range(1, 5);
		if(seed == 1)
        {
			item.primaryStatType4 = "% chance to Immobilize on hit";
			item.primaryStat4 = Random.Range(1, 3);
        }
		if(seed == 2)
        {
			item.primaryStatType4 = "% chance to poison on hit";
			item.primaryStat4 = Random.Range(5, 16);
        }
		if(seed == 3)
        {
			item.primaryStatType4 = "% chance to blind on hit";
			item.primaryStat4 = Random.Range(1, 6);
        }
        if (seed == 4)
        {
			item.primaryStatType4 = "% chance to confuse on hit";
			item.primaryStat4 = Random.Range(1, 11);
        }

		//secondary stat 1
		seed = Random.Range(1, 3);
		if(seed == 1)
        {
			item.secondaryStatType1 = "% extra exp on kill";
			item.secondaryStat1 = Random.Range(1, 6);
        }
		if(seed == 2)
        {
			item.secondaryStatType1 = "% extra gold on kill";
			item.secondaryStat1 = Random.Range(1, 101);
        }

		//secondary stat 2
		seed = Random.Range(1, 6);
		if(seed == 1)
        {
			item.secondaryStatType2 = " Physical Resistance";
			item.secondaryStat2 = Random.Range(1, 151);
        }
		if (seed == 2)
		{
			item.secondaryStatType2 = " Lightning Resistance";
			item.secondaryStat2 = Random.Range(1, 151);

		}
		if (seed == 3)
		{
			item.secondaryStatType2 = " Poison Resistance";
			item.secondaryStat2 = Random.Range(1, 151);

		}
		if (seed == 4)
		{
			item.secondaryStatType2 = " Fire Resistance";
			item.secondaryStat2 = Random.Range(1, 151);

		}
		if (seed == 5)
		{
			item.secondaryStatType2 = " Cold Resistance";
			item.secondaryStat2 = Random.Range(1, 151);

		}

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
		reforgeButton.interactable = true;
	}

	public void CancelReforge()
    {
		cancelReforge.interactable = false;
		reforgeSlot.sprite = null;
		reforgeSlot.enabled = false;
		reforgeBlock.SetActive(false);
    }

	public void ReforgeItem()
    {
		//item = reforgeItem;

		reforgeSlot.sprite = item.icon;
		reforgeSlot.enabled = true;
		icon.enabled = true;
		cancelReforge.interactable = true;
        reforgeBlock.SetActive(true);
		reforgeName.text = "  " + item.name;
		reforgeDamageRange.text = " - " + item.damageRange;
		reforgePrimary1.text = " - " + item.primaryStat1.ToString() + item.primaryStatType1;
		reforgePrimary2.text = " - " + item.primaryStat2.ToString() + item.primaryStatType2;
		reforgePrimary3.text = " - " + item.primaryStat3.ToString() + item.primaryStatType3;
		reforgePrimary4.text = " - " + item.primaryStat4.ToString() + item.primaryStatType4;

		reforgeSecondary1.text = " - " + item.secondaryStat1.ToString() + item.secondaryStatType1;
		reforgeSecondary2.text = " - " + item.secondaryStat2.ToString() + item.secondaryStatType2;


	}

	// Clear the slot
	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
		reforgeButton.interactable = false;
		cancelReforge.interactable = false;
		reforgeSlot.enabled = false;
		reforgeBlock.SetActive(false);
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
		
		if(item != null)
        {
			highlightedSlot.color = new Color(highlightedSlot.color.r, highlightedSlot.color.g, highlightedSlot.color.b, 1f);
			name.text = "   " + item.name;
			damageRange.text = " - " + item.damageRange;
			primary1.text = " - " + item.primaryStat1.ToString() + item.primaryStatType1;
			primary2.text = " - " + item.primaryStat2.ToString() + item.primaryStatType2;
			primary3.text = " - " + item.primaryStat3.ToString() + item.primaryStatType3;
			primary4.text = " - " + item.primaryStat4.ToString() + item.primaryStatType4;

			secondary1.text = " - " + item.secondaryStat1.ToString() + item.secondaryStatType1;
			secondary2.text = " - " + item.secondaryStat2.ToString() + item.secondaryStatType2;


		}

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("test");
		highlightedSlot.color = new Color(highlightedSlot.color.r, highlightedSlot.color.g, highlightedSlot.color.b, .3f);
	}
}
