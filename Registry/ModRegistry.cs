﻿using Kitchen;
using KitchenData;
using KitchenLib.Event;
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace GrilledCheese.Registry
{
    [UpdateBefore(typeof(GrantUpgrades))]
    internal class ModRegistry : GenericSystemBase
    {
        private EntityQuery Upgrades;

        private static readonly List<Tuple<ILocalisedRecipeHolder, Dish>> RecipeHolders = new List<Tuple<ILocalisedRecipeHolder, Dish>>();
        private static readonly List<Dish> BaseDishes = new List<Dish>();

     //   private static bool GameDataBuilt = false;

        public static void AddLocalisedRecipe(ILocalisedRecipeHolder holder, Dish dish)
        {
            RecipeHolders.Add(new Tuple<ILocalisedRecipeHolder, Dish>(holder, dish));
        }

        public static void AddBaseDish(Dish dish)
        {
            BaseDishes.Add(dish);
        }

        public static void HandleBuildGameDataEvent(BuildGameDataEventArgs args)
        {
        }

        protected override void Initialise()
        {
            Upgrades = GetEntityQuery(typeof(CUpgrade));
        }

        protected override void OnUpdate()
        {
            // Base dishes
            NativeArray<CUpgrade> existing = Upgrades.ToComponentDataArray<CUpgrade>(Allocator.Temp);
            foreach (var dish in BaseDishes)
            {
                foreach (CUpgrade item in existing)
                {
                    if (item.ID == dish.ID)
                    {
                        goto next_dish;
                    }
                }

                var entity = EntityManager.CreateEntity(typeof(CUpgrade), typeof(CPersistThroughSceneChanges));
                EntityManager.AddComponentData(entity, new CUpgrade
                {
                    ID = dish.ID
                });
                Main.LogInfo($"Registered base dish {dish.Name} ({dish.ID})");

            next_dish: { }
            }

            existing.Dispose();
        }
    }
}
