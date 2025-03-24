using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Database")]

public class ItemDatabaseSO : ScriptableObject
{
    public List<ItemSO> items = new List<ItemSO>();          //ItemSO�� ����Ʈ�� ���� �Ѵ�.

    private Dictionary<int, ItemSO> itemsByld;               //ID�� ������ ã�� ���� ĳ��
    private Dictionary<string, ItemSO> itemsByName;          //�̸����� ������ ã��

    public void Initialize()                                 //�ʱ� ���� �Լ�
    {
        itemsByld = new Dictionary<int, ItemSO>();           //���� ���� �߱� ������ Dictionary �Ҵ�
        itemsByName = new Dictionary<string, ItemSO>();      //items ����Ʈ�� ���� �Ǿ� �ִ°��� ������ Dictionary�� �Է��Ѵ�

        foreach (var item in items)
        {
            itemsByld[item.id] = item;
            itemsByName[item.itemName] = item;               
        }
    }

    //ID�� ������ ã��
    public ItemSO GetItemByld(int id)
    {
        if(itemsByld == null)                               //itemByld �� ĳ���� �Ǿ� ���� �ʴٸ� �ʱ�ȭ �Ѵ�.
        {
            Initialize();
        }
        if (itemsByld.TryGetValue(id, out ItemSO item))     //id ���� ã�Ƽ� ItemSO �� ���� �Ѵ�.
            return item;

        return null;                                        //���� ��� NULL
    }

    //�̸����� ������ ã��
    public ItemSO GetItemByName(string name)
    {
        if (itemsByName == null)                               //itemByName �� ĳ���� �Ǿ� ���� �ʴٸ� �ʱ�ȭ �Ѵ�.
        {
            Initialize();
        }
        if (itemsByName.TryGetValue(name, out ItemSO item))     //name ���� ã�Ƽ� ItemSO �� ���� �Ѵ�.
            return item;

        return null;                                        //���� ��� NULL
    }

    //Ÿ������ ������ ���͸�
    public List<ItemSO> GetitemByType(ItemType type)
    {
        return items.FindAll(item => item.itemType == type);
    }
}
