﻿using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GrilledCheese.ApplePiewIceCream
{
    class ApplePieWithIceCream : CustomItemGroup
    {
        public override string UniqueNameID => "Apple Pie with Ice Cream";
        public override GameObject Prefab => Main.TomatoSlice.Prefab; //Filler line until Models are made
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "APV";

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.ApplePie
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Main.VanillaIceCream
                }
            }

            /*
              public override void OnRegister(GameDataObject gameDataObject)
            {

                // setup materials on prefab

                Prefab.GetComponent<MyItemGroupView>()?.Setup();
             }
            */
        };

    }
}

