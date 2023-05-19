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
    public void TryEatItem(ItemMob food)
    {
        if (Hunger.GetPercentage() < 1)
        {
            foreach (DigestResult diet in Diet)
            {
                if (diet.eatRequirement == food.ediblecategory)
                {
                    Hunger.GiveValue(diet.hungerResult);
                    PoopItem(diet.resultingItem);
                    food.Kill();
                }
            }
        }
    }
    void PoopItem(GameObject item)
    {
        if (item != null)
        {
            GameObject poopObject = Instantiate(item);
            poopObject.transform.position = transform.position;
        }
    }
}
