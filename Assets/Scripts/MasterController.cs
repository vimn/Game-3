﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] UI_Inventory uiInventory;
   
private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }
}
