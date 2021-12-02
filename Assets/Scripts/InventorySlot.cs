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
	public Text reforgeChoice1;
	public Text reforgeChoice2;
	public Button selectReforge;
	public Button confirmReforge;

	public Toggle reforgePrimary1Toggle;
	public Toggle reforgePrimary2Toggle;
	public Toggle reforgePrimary3Toggle;
	public Toggle reforgePrimary4Toggle;
	public Toggle reforgeSecondary1Toggle;
	public Toggle reforgeSecondary2Toggle;
	public Toggle reforgeChoice1Toggle;
	public Toggle reforgeChoice2Toggle;

	public string preForgeType;
	public int preForgeStat;
	public int forgeStat1;
	public int forgeStat2;
	public string forgeType1;
	public string forgeType2;
	private int seed;
	private int statSwitch;

	[SerializeField] AudioSource reforgeSet;
	[SerializeField] AudioSource reforgeDone;
	[SerializeField] AudioSource closeReforge;
	[SerializeField] AudioSource explode;


	public Image highlightedSlot;

	Item item;  // Current item in the slot

	public void DamageRange()
    {
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
	}
	public void PrimaryStat1()
    {
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
	}
	public void PrimaryStat2()
    {
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
	}
	public void PrimaryStat3()
    {
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
	}
	public void PrimaryStat4()
    {
		seed = Random.Range(1, 5);
		if (seed == 1)
		{
			item.primaryStatType4 = "% chance to Immobilize on hit";
			item.primaryStat4 = Random.Range(1, 3);
		}
		if (seed == 2)
		{
			item.primaryStatType4 = "% chance to poison on hit";
			item.primaryStat4 = Random.Range(5, 16);
		}
		if (seed == 3)
		{
			item.primaryStatType4 = "% chance to blind on hit";
			item.primaryStat4 = Random.Range(1, 6);
		}
		if (seed == 4)
		{
			item.primaryStatType4 = "% chance to confuse on hit";
			item.primaryStat4 = Random.Range(1, 11);
		}
	}
	public void SecondaryStat1()
    {
		seed = Random.Range(1, 3);
		if (seed == 1)
		{
			item.secondaryStatType1 = "% extra exp on kill";
			item.secondaryStat1 = Random.Range(1, 6);
		}
		if (seed == 2)
		{
			item.secondaryStatType1 = "% extra gold on kill";
			item.secondaryStat1 = Random.Range(1, 101);
		}
	}
	public void SecondaryStat2()
    {
		seed = Random.Range(1, 6);
		if (seed == 1)
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
	}

	public void AddItem(Item newItem)
	{
		item = newItem;

		//damage range
		DamageRange();

		//primary stat 1
		PrimaryStat1();

		//primary stat 2
		PrimaryStat2();

		//primary stat 3
		PrimaryStat3();

		//primary stat 4
		PrimaryStat4();

		//secondary stat 1
		SecondaryStat1();

		//secondary stat 2
		SecondaryStat2();

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
		reforgeButton.interactable = true;
	}

	public void CancelReforge()
    {
		closeReforge.Play();
		cancelReforge.interactable = false;
		reforgeSlot.sprite = null;
		reforgeSlot.enabled = false;
		reforgeBlock.SetActive(false);
    }

	public void ReforgeItem()
    {
		//item = reforgeItem;
		reforgeSet.Play();
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
		explode.Play();
		Inventory.instance.Remove(item);
	}

/*	public GameObject reforgeBlock;
	Text reforgeName;
	Text reforgeDamageRange;
	Text reforgePrimary1;
	Text reforgePrimary2;
	Text reforgePrimary3;
	Text reforgePrimary4;
	Text reforgeSecondary1;
	Text reforgeSecondary2;
	Text reforgeChoice1;
	Text reforgeChoice2;
	Button confirmReforge;

	Toggle reforgePrimary1Toggle;
	Toggle reforgePrimary2Toggle;
	Toggle reforgePrimary3Toggle;
	Toggle reforgePrimary4Toggle;
	Toggle reforgeSecondary1Toggle;
	Toggle reforgeSecondary2Toggle;
	Toggle reforgeChoice1Toggle;
	Toggle reforgeChoice2Toggle;*/

	public void ConfirmReforge()
    {

		reforgeDone.Play();
		if (reforgePrimary1Toggle.isOn)
		{
			reforgePrimary1Toggle.isOn = false;
			item.primaryStat1 = preForgeStat;
			item.primaryStatType1 = preForgeType;
			//Debug.Log("thing here");
		}

		if (reforgePrimary2Toggle.isOn)
		{
			reforgePrimary2Toggle.isOn = false;
			item.primaryStat2 = preForgeStat;
			item.primaryStatType2 = preForgeType;
		}

		if (reforgePrimary3Toggle.isOn)
		{
			reforgePrimary3Toggle.isOn = false;
			item.primaryStat3 = preForgeStat;
			item.primaryStatType3 = preForgeType;
		}

		if (reforgePrimary4Toggle.isOn)
		{
			reforgePrimary4Toggle.isOn = false;
			item.primaryStat4 = preForgeStat;
			item.primaryStatType4 = preForgeType;
		}

		if (reforgeSecondary1Toggle.isOn)
		{
			reforgeSecondary1Toggle.isOn = false;
			item.secondaryStat1 = preForgeStat;
			item.secondaryStatType1 = preForgeType;
		}

		if (reforgeSecondary2Toggle.isOn)
		{
			reforgeSecondary2Toggle.isOn = false;
			item.secondaryStat2 = preForgeStat;
			item.secondaryStatType2 = preForgeType;
		}

		if (reforgeChoice1Toggle.isOn)
		{
			reforgeChoice1Toggle.isOn = false;
			if (statSwitch == 1)
            {
				item.primaryStat1 = forgeStat1;
				item.primaryStatType1 = forgeType1;
			}
			if(statSwitch == 2)
            {
				item.primaryStat2 = forgeStat1;
				item.primaryStatType2 = forgeType1;
			}
			if (statSwitch == 3)
			{
				item.primaryStat3 = forgeStat1;
				item.primaryStatType3 = forgeType1;
			}
			if (statSwitch == 4)
			{
				item.primaryStat4 = forgeStat1;
				item.primaryStatType4 = forgeType1;
			}
			if (statSwitch == 5)
			{
				item.secondaryStat1 = forgeStat1;
				item.secondaryStatType1 = forgeType1;
			}
			if (statSwitch == 6)
			{
				item.secondaryStat2 = forgeStat1;
				item.secondaryStatType2 = forgeType1;
			}

		}

		if (reforgeChoice2Toggle.isOn)
		{
			reforgeChoice2Toggle.isOn = false;
			if (statSwitch == 1)
			{
				item.primaryStat1 = forgeStat2;
				item.primaryStatType1 = forgeType2;
			}
			if (statSwitch == 2)
			{
				item.primaryStat2 = forgeStat2;
				item.primaryStatType2 = forgeType2;
			}
			if (statSwitch == 3)
			{
				item.primaryStat3 = forgeStat2;
				item.primaryStatType3 = forgeType2;
			}
			if (statSwitch == 4)
			{
				item.primaryStat4 = forgeStat2;
				item.primaryStatType4 = forgeType2;
			}
			if (statSwitch == 5)
			{
				item.secondaryStat1 = forgeStat2;
				item.secondaryStatType1 = forgeType2;
			}
			if (statSwitch == 6)
			{
				item.secondaryStat2 = forgeStat2;
				item.secondaryStatType2 = forgeType2;
			}
		}
		ReforgeItem();
		ReforgeUI();

		
	}
	public void ReforgeUI()
    {
		confirmReforge.gameObject.SetActive(false);
		selectReforge.gameObject.SetActive(true);
		reforgeDamageRange.gameObject.SetActive(true);
		reforgePrimary1.gameObject.SetActive(true);
		reforgePrimary2.gameObject.SetActive(true);
		reforgePrimary3.gameObject.SetActive(true);
		reforgePrimary4.gameObject.SetActive(true);
		reforgeSecondary1.gameObject.SetActive(true);
		reforgeSecondary2.gameObject.SetActive(true);
	}
	public void Reforge()
    {
		selectReforge.gameObject.SetActive(false);
		confirmReforge.gameObject.SetActive(true);
		reforgeDamageRange.gameObject.SetActive(false);
		reforgePrimary1.gameObject.SetActive(false);
		reforgePrimary2.gameObject.SetActive(false);
		reforgePrimary3.gameObject.SetActive(false);
		reforgePrimary4.gameObject.SetActive(false);
		reforgeSecondary1.gameObject.SetActive(false);
		reforgeSecondary2.gameObject.SetActive(false);

		if (reforgePrimary1Toggle.isOn)
        {
			statSwitch = 1;
			reforgePrimary1Toggle.isOn = false;
			reforgePrimary1.gameObject.SetActive(true);
			//ReforgeSlot(reforgePrimary1);
			preForgeStat = item.primaryStat1;
			preForgeType = item.primaryStatType1;
			PrimaryStat1();
			forgeStat1 = item.primaryStat1;
			forgeType1 = item.primaryStatType1;
			reforgeChoice1.text = " - " + item.primaryStat1.ToString() + item.primaryStatType1;
			PrimaryStat1();
			forgeStat2 = item.primaryStat1;
			forgeType2 = item.primaryStatType1;
			reforgeChoice2.text = " - " + item.primaryStat1.ToString() + item.primaryStatType1;
		}
        if (reforgePrimary2Toggle.isOn)
        {
			statSwitch = 2;
			reforgePrimary2Toggle.isOn = false;
			ReforgeSlot(reforgePrimary2);
			preForgeStat = item.primaryStat2;
			preForgeType = item.primaryStatType2;
			PrimaryStat2();
			forgeStat1 = item.primaryStat2;
			forgeType1 = item.primaryStatType2;
			reforgeChoice1.text = " - " + item.primaryStat2.ToString() + item.primaryStatType2;
			PrimaryStat2();
			forgeStat2 = item.primaryStat2;
			forgeType2 = item.primaryStatType2;
			reforgeChoice2.text = " - " + item.primaryStat2.ToString() + item.primaryStatType2;
		}
        if (reforgePrimary3Toggle.isOn)
        {
			statSwitch = 3;
			reforgePrimary3Toggle.isOn = false;
			ReforgeSlot(reforgePrimary3);
			preForgeStat = item.primaryStat3;
			preForgeType = item.primaryStatType3;
			PrimaryStat3();
			forgeStat1 = item.primaryStat3;
			forgeType1 = item.primaryStatType3;
			reforgeChoice1.text = " - " + item.primaryStat3.ToString() + item.primaryStatType3;
			PrimaryStat3();
			forgeStat2 = item.primaryStat3;
			forgeType2 = item.primaryStatType3;
			reforgeChoice2.text = " - " + item.primaryStat3.ToString() + item.primaryStatType3;
		}
        if (reforgePrimary4Toggle.isOn)
        {
			statSwitch = 4;
			reforgePrimary4Toggle.isOn = false;
			ReforgeSlot(reforgePrimary4);
			preForgeStat = item.primaryStat4;
			preForgeType = item.primaryStatType4;
			PrimaryStat4();
			forgeStat1 = item.primaryStat4;
			forgeType1 = item.primaryStatType4;
			reforgeChoice1.text = " - " + item.primaryStat4.ToString() + item.primaryStatType4;
			PrimaryStat4();
			forgeStat2 = item.primaryStat4;
			forgeType2 = item.primaryStatType4;
			reforgeChoice2.text = " - " + item.primaryStat4.ToString() + item.primaryStatType4;
		}
        if (reforgeSecondary1Toggle.isOn)
        {
			statSwitch = 5;
			reforgeSecondary1Toggle.isOn = false;
			ReforgeSlot(reforgeSecondary1);
			preForgeStat = item.secondaryStat1;
			preForgeType = item.secondaryStatType1;
			SecondaryStat1();
			forgeStat1 = item.secondaryStat1;
			forgeType1 = item.secondaryStatType1;
			reforgeChoice1.text = " - " + item.secondaryStat1.ToString() + item.secondaryStatType1;
			SecondaryStat1();
			forgeStat2 = item.secondaryStat1;
			forgeType2 = item.secondaryStatType1;
			reforgeChoice2.text = " - " + item.secondaryStat1.ToString() + item.secondaryStatType1;
		}
        if (reforgeSecondary2Toggle.isOn)
        {
			statSwitch = 6;
			reforgeSecondary2Toggle.isOn = false;
			ReforgeSlot(reforgeSecondary2);
			preForgeStat = item.secondaryStat2;
			preForgeType = item.secondaryStatType2;
			SecondaryStat2();
			forgeStat1 = item.secondaryStat1;
			forgeType1 = item.secondaryStatType2;
			reforgeChoice1.text = " - " + item.secondaryStat2.ToString() + item.secondaryStatType2;
			SecondaryStat2();
			forgeStat2 = item.secondaryStat1;
			forgeType2 = item.secondaryStatType2;
			reforgeChoice2.text = " - " + item.secondaryStat2.ToString() + item.secondaryStatType2;
		}
    }

	public void ReforgeSlot(Text stat)
    {

		stat.gameObject.SetActive(true);
        
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
		highlightedSlot.color = new Color(highlightedSlot.color.r, highlightedSlot.color.g, highlightedSlot.color.b, .3f);
	}
}
