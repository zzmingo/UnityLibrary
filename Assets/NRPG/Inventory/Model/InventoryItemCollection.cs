namespace NRPG {

  public class InventoryItemCollectionCatagory {

    public string Id;
    public string Name;
    
  }

  public class InventoryItemCollection {

    public InventoryItemCollectionCatagory Catagory;
    public string Name;
    
    private InventoryItem[] mItems;

  }

}