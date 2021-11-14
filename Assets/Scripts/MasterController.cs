using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    private Inventory inventory;
   
private void Awake()
    {
        inventory = new Inventory();
    }
}
