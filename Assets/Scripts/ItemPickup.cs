using UnityEngine;

public class ItemPickup : Interactable {

	public Item item1;
	public Item item2; // Item to put in the inventory if picked up
	public Item item3;
	public Item item4;
	public Item item5;
	public Item item6;
	public Item item7;
	public Item item8;
	public Item item9;
	public Item item10;
	public Item item11;
	public Item item12;
	public Item item13;
	public Item item14;
	public Item item15;
	
	int itemIndex = 0;

	public void Awake()
    {
		Debug.Log("woke up one day");
    }
    // When the player interacts with the item
    public override void Interact()
	{
		base.Interact();

		PickUp();
	}

	// Pick up the item
	void PickUp ()
	{
		itemIndex = Random.Range(1,16);
		if (itemIndex == 1)
        {
			Inventory.instance.Add(item1);  // Add to inventory
		}
		if(itemIndex == 2)
        {
			Inventory.instance.Add(item2);
        }
		if (itemIndex == 3)
		{
			Inventory.instance.Add(item3);
		}
		if (itemIndex == 4)
		{
			Inventory.instance.Add(item4);
		}
		if (itemIndex == 5)
		{
			Inventory.instance.Add(item5);
		}
		if (itemIndex == 6)
		{
			Inventory.instance.Add(item6);
		}
		if (itemIndex == 7)
		{
			Inventory.instance.Add(item7);
		}
		if (itemIndex == 8)
		{
			Inventory.instance.Add(item8);
		}
		if (itemIndex == 9)
		{
			Inventory.instance.Add(item9);
		}
		if (itemIndex == 10)
		{
			Inventory.instance.Add(item10);
		}
		if (itemIndex == 11)
		{
			Inventory.instance.Add(item11);
		}
		if (itemIndex == 12)
		{
			Inventory.instance.Add(item12);
		}
		if (itemIndex == 13)
		{
			Inventory.instance.Add(item13);
		}
		if (itemIndex == 14)
		{
			Inventory.instance.Add(item14);
		}
		if (itemIndex == 15)
		{
			Inventory.instance.Add(item15);
		}
		Debug.Log(itemIndex + " index.");
		Debug.Log("Picking up " + item1.name);
		item1.primaryStat1 = Random.Range(450, 650);
		Debug.Log("randomizing stats, " + item1.primaryStat1 + "agility");

		//Destroy(gameObject);	// Destroy item from scene
	}

}
