using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	
	public Sprite icon = null;				
	public bool showInInventory = true;

	public string damageRange;
	public int lowDamageEnd;
	public int highDamageEnd;
	public string damageType;
	public int primaryStat1;
	public int primaryStat2;
	public int primaryStat3;
	public int primaryStat4;
	public int secondaryStat1;
	public int secondaryStat2;
	public string primaryStatType1;
	public string primaryStatType2;
	public string primaryStatType3;
	public string primaryStatType4;
	public string secondaryStatType1;
	public string secondaryStatType2;


	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}

}
