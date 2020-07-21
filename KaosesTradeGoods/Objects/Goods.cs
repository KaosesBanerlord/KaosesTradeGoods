using KaosesTradeGoods.Config;
using KaosesTradeGoods.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Library;
using static TaleWorlds.Core.ItemObject;

namespace KaosesTradeGoods.Objects
{

    public static class Goods
    {
        public static void processAnimalGoodsWeight(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.ItemType == ItemTypeEnum.Animal)
                {
                    float multipleValue = item.Weight * Settings.Instance.weightAnimalMultiplier;
                    typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                }
            }
        }

        public static void processAnimalGoodsValue(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.ItemType == ItemTypeEnum.Animal)
                {
                    float multipleValue = item.Value * Settings.Instance.valueAnimalMultiplier;
                    int newValue = (int)multipleValue;
                    typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);
                }
            }
        }

        public static void processFoodGoodsWeight(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.IsFood)
                {
                    float multipleValue = item.Weight * Settings.Instance.weightFoodMultiplier;
                    typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                }
            }
        }

        public static void processFoodGoodsValue(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (item.IsFood)
                {
                    float multipleValue = item.Value * Settings.Instance.valueFoodMultiplier;
                    int newValue = (int)multipleValue;
                    typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);
                }
            }
        }

        public static void processFoodGoodsWeightByMoral(MBReadOnlyList<ItemObject> ItemsList)
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
                            multiplier = Settings.Instance.weightFoodByMoral0Multiplier;
                        }else if (tc.MoraleBonus == 1)
                        {
                            multiplier = Settings.Instance.weightFoodByMoral1Multiplier;
                        }
                        else if (tc.MoraleBonus == 2)
                        {
                            multiplier = Settings.Instance.weightFoodByMoral2Multiplier;
                        }
                        else if (tc.MoraleBonus == 3)
                        {
                            multiplier = Settings.Instance.weightFoodByMoral3Multiplier;
                        }
                        float multipleValue = item.Weight * multiplier;
                        typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                    }
                }
            }
        }

        public static void processFoodGoodsValueByMoral(MBReadOnlyList<ItemObject> ItemsList)
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
                            multiplier = Settings.Instance.valueFoodByMoral0Multiplier;
                        }else if (tc.MoraleBonus == 1)
                        {
                            multiplier = Settings.Instance.valueFoodByMoral1Multiplier;
                        }
                        else if (tc.MoraleBonus == 2)
                        {
                            multiplier = Settings.Instance.valueFoodByMoral2Multiplier;
                        }
                        else if (tc.MoraleBonus == 3)
                        {
                            multiplier = Settings.Instance.valueFoodByMoral3Multiplier;
                        }
                        float multipleValue = item.Value * multiplier;
                        int newValue = (int)multipleValue;
                        typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);

                    }
                }
            }
        }

        public static void processTradeGoodsWeight(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (!item.IsFood && item.ItemType != ItemTypeEnum.Animal && item.IsTradeGood)
                {
                    float multipleValue = item.Weight * Settings.Instance.weightGoodssMultiplier;
                    typeof(ItemObject).GetProperty("Weight").SetValue(item, multipleValue);
                }
            }
        }

        public static void processTradeGoodsValue(MBReadOnlyList<ItemObject> ItemsList)
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                var item = ItemsList[i];
                if (!item.IsFood && item.ItemType != ItemTypeEnum.Animal && item.IsTradeGood)
                {
                    float multipleValue = item.Value * Settings.Instance.valueGoodsMultiplier;
                    int newValue = (int)multipleValue;
                    typeof(ItemObject).GetProperty("Value").SetValue(item, newValue);
                }
            }
        }






    }



}
