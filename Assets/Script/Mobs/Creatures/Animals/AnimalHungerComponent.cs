using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHungerComponent : AnimalComponent
{
    public Resource Hunger;
    public float HungerDecay = 5;
    public override void Awake()
    {
        base.Awake();
        Hunger = new Resource(parent, 100, name + " hunger", false, false);
    }
    private void Update()
    {
        HandleMetabolism();
        TryEat();

        //SFX Maybe creature noise?
    }
    void HandleMetabolism()
    {
        Hunger.SubstractValue(HungerDecay * Time.deltaTime);
    }
    [System.Serializable]
    public class DigestResult
    {
        public ItemMob.Edibility eatRequirement;
        public float hungerResult;
        public GameObject resultingItem;
        public int StackCount;
    }
    public DigestResult[] Diet;

    #region Toucher

    public List<ItemMob> TouchedItems = new List<ItemMob>();
    public void OnTouchEnter(ItemMob item)
    {
        if (!TouchedItems.Contains(item))
            TouchedItems.Add(item);

    }
    public void OnTouchExit(ItemMob item)
    {
        if (!TouchedItems.Contains(item))
            TouchedItems.Remove(item);

    }
    public ItemMob GetTouchedItem()
    {
        if (TouchedItems.Count > 0)
            return TouchedItems[0];
        return null;
    }
    #endregion

    public void TryEat()
    {
        if (Hunger.GetPercentage() < 1)
        {
            foreach (ItemMob food in TouchedItems)
            {
                if (TryEatItem(food))
                {
                    //SFX Creature eats fruit
                    return;
                }
            }
        }
    }
        public bool TryEatItem(ItemMob food)
    {
            foreach (DigestResult diet in Diet)
            {
                if (diet.eatRequirement == food.ediblecategory)
                {
                    Hunger.GiveValue(diet.hungerResult);
                    PoopItem(diet.resultingItem, diet.StackCount) ;
                    food.Kill();
                return true;
                }
        }
        return false;
    }
    void PoopItem(GameObject item, int stackCount)
    {
        if (item != null)
        {
            GameObject poopObject = Instantiate(item);
            poopObject.transform.position = transform.position;
            if (poopObject.TryGetComponent(out ChunkItem chunk))
                chunk.SetQuantity(stackCount);
        }
    }
}
