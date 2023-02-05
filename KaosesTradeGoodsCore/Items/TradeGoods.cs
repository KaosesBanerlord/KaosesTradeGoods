using KaosesCommon.Utils;
using KaosesTradeGoodsCore.Objects;
using TaleWorlds.Core;
using TaleWorlds.Library;
using static TaleWorlds.Core.ItemObject;

using CoreConfig = KaosesTradeGoodsCore.Settings.KaosesTradeGoodsCoreConfig;
using CoreFactory = KaosesTradeGoodsCore.Objects.KaosesTradeGoodsCoreFactory;

namespace KaosesTradeGoodsCore.Items
{
    public static class TradeGoods
    {
        public static void ProcessAnimalGoodsWeight(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.ItemType == ItemTypeEnum.Animal)
                {
                    float multipleValue = item.Weight * CoreFactory.Settings.weightAnimalMultiplier;
                    DebugWeight(item, multipleValue, CoreFactory.Settings.weightAnimalMultiplier);
                    typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                }
            }
        }

        public static void ProcessAnimalGoodsValue(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.ItemType == ItemTypeEnum.Animal)
                {
                    float multipleValue = item.Value * CoreFactory.Settings.valueAnimalMultiplier;
                    int newValue = (int)multipleValue;
                    DebugValue(item, multipleValue, CoreFactory.Settings.valueAnimalMultiplier);
                    typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);
                }
            }
        }

        public static void ProcessFoodGoodsWeight(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.IsFood)
                {
                    float multipleValue = item.Weight * CoreFactory.Settings.weightFoodMultiplier;
                    DebugWeight(item, multipleValue, CoreFactory.Settings.weightFoodMultiplier);
                    typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                }
            }
        }

        public static void ProcessFoodGoodsValue(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.IsFood)
                {
                    float multipleValue = item.Value * CoreFactory.Settings.valueFoodMultiplier;
                    int newValue = (int)multipleValue;
                    DebugValue(item, multipleValue, CoreFactory.Settings.valueFoodMultiplier);
                    typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);
                }
            }
        }

        public static void ProcessFoodGoodsWeightByMoral(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.IsFood)
                {
                    float multiplier = 1.0f;
                    if (item.HasFoodComponent)
                    {
                        TradeItemComponent tc = item.FoodComponent;
                        if (tc.MoraleBonus == 0)
                        {
                            multiplier = CoreFactory.Settings.weightFoodByMoral0Multiplier;
                        }
                        else if (tc.MoraleBonus == 1)
                        {
                            multiplier = CoreFactory.Settings.weightFoodByMoral1Multiplier;
                        }
                        else if (tc.MoraleBonus == 2)
                        {
                            multiplier = CoreFactory.Settings.weightFoodByMoral2Multiplier;
                        }
                        else if (tc.MoraleBonus == 3)
                        {
                            multiplier = CoreFactory.Settings.weightFoodByMoral3Multiplier;
                        }
                        float multipleValue = item.Weight * multiplier;
                        DebugWeight(item, multipleValue, multiplier);
                        typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                    }
                }
            }
        }

        public static void ProcessFoodGoodsValueByMoral(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.IsFood)
                {
                    float multiplier = 1.0f;
                    if (item.HasFoodComponent)
                    {
                        TradeItemComponent tc = item.FoodComponent;
                        if (tc.MoraleBonus == 0)
                        {
                            multiplier = CoreFactory.Settings.valueFoodByMoral0Multiplier;
                        }
                        else if (tc.MoraleBonus == 1)
                        {
                            multiplier = CoreFactory.Settings.valueFoodByMoral1Multiplier;
                        }
                        else if (tc.MoraleBonus == 2)
                        {
                            multiplier = CoreFactory.Settings.valueFoodByMoral2Multiplier;
                        }
                        else if (tc.MoraleBonus == 3)
                        {
                            multiplier = CoreFactory.Settings.valueFoodByMoral3Multiplier;
                        }
                        float multipleValue = item.Value * multiplier;
                        int newValue = (int)multipleValue;
                        DebugValue(item, multipleValue, multiplier);
                        typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);

                    }
                }
            }
        }

        public static void ProcessTradeGoodsWeight(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (!item.IsFood && item.ItemType != ItemTypeEnum.Animal && item.IsTradeGood)
                {
                    float multipleValue = item.Weight * CoreFactory.Settings.weightGoodsMultiplier;
                    DebugWeight(item, multipleValue, CoreFactory.Settings.weightGoodsMultiplier);
                    typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                }
            }
        }

        public static void ProcessTradeGoodsValue(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (!item.IsFood && item.ItemType != ItemTypeEnum.Animal && item.IsTradeGood)
                {
                    float multipleValue = 0.0f;
                    float multiplier = 1.0f;
                    int newValue = 0;
                    multiplier = CoreFactory.Settings.valueGoodsMultiplier;
                    multipleValue = item.Value * multiplier;
                    newValue = (int)multipleValue;
                    DebugValue(item, multipleValue, CoreFactory.Settings.valueGoodsMultiplier);

                    typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);


                }
            }
        }


        private static void DebugValue(ItemObject item, float newValue, float multiplier)
        {
            if (CoreFactory.Settings.Debug)
            {
                IM.MessageDebug(item.Name.ToString() + " Old Value: " + item.Value.ToString() + "  New Value: " + newValue.ToString() + " using multiplier: " + multiplier);
            }
            else if (CoreFactory.Settings.LogToFile)
            {
                KaosesCommon.Utils.Logger.Lm(item.Name.ToString() + " Old Value: " + item.Value.ToString() + "  New Value: " + newValue.ToString() + " using multiplier: " + multiplier);
            }
        }
        private static void DebugWeight(ItemObject item, float newValue, float multiplier)
        {
            if (CoreFactory.Settings.Debug)
            {
                IM.MessageDebug(item.Name.ToString() + " Old Weight: " + item.Weight.ToString() + "  New Weight: " + newValue.ToString() + " using multiplier: " + multiplier);
            }
            else if (CoreFactory.Settings.LogToFile)
            {
                KaosesCommon.Utils.Logger.Lm(item.Name.ToString() + " Old Weight: " + item.Weight.ToString() + "  New Weight: " + newValue.ToString() + " using multiplier: " + multiplier);
            }
        }

    }
}
