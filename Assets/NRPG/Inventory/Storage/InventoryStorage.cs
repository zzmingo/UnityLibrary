using System;
using System.Collections;

namespace NRPG {

  public interface IStorageCallback {

    void onSuccess(IInventoryStorage storage, InventoryItemCollection collection);

    void onFail(IInventoryStorage storage, InventoryItemCollection collection, Exception error);

  }

  public interface IInventoryStorage {

    void Load(InventoryItemCollection collection);

    void LoadAsync(InventoryItemCollection collection, IStorageCallback callback);

    IEnumerator LoadCoroutine(InventoryItemCollection collection);

    void Save(InventoryItemCollection collection);

    void SaveAsync(InventoryItemCollection collection, IStorageCallback callback);

    IEnumerator SaveCoroutine(InventoryItemCollection collection);

  }

}