using System;
using System.Collections;
using System.Collections.Generic;

namespace NRPG {

  public class InventoryItemCategory {
    public string Id;
    public string Name;
  }

  public class InventoryItemDefinition {
    
    public string Id;
    public string Name;
    public string Description;
    public InventoryItemCategory Category;
    public string Icon;
    public int Weight;
    public int RequiredLevel;
    public int Qualify;
    public int BuyPrice;
    public int SellPrice;
    public bool Droppable;
    public bool Sellable;
    public bool Stoable;
    public int StackSize;
    public InventoryProperty Properties;

  }

  public class InventoryItem {

    public InventoryItemDefinition Definition;

  }

}