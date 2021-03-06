﻿using System;

namespace MyAccounting.Model
{
    // Do nothing, Null object pattern
    internal class StandardRewardCard : IRewardCard
    {
        public int RewardPoints { get; } = 0;

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance) { }
    }

    internal class BronzeRewardCard : IRewardCard
    {
        private readonly int BronzeTransactionCostPerPoint = 20;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor(transactionAmount / BronzeTransactionCostPerPoint), 0);
        }
    }

    internal class SilverRewardCard : IRewardCard
    {
        private readonly int SilverTransactionCostPerPoint = 10;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor(transactionAmount / SilverTransactionCostPerPoint), 0);
        }
    }

    internal class GoldRewardCard : IRewardCard
    {
        private readonly int GoldTransactionCostPerPoint = 5;
        private readonly int GoldBalanceCostPerPoint = 2000;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor((accountBalance / GoldBalanceCostPerPoint) + (transactionAmount / GoldTransactionCostPerPoint)), 0);
        }
    }

    internal class PlatinumRewardCard : IRewardCard
    {
        private readonly int PlatiniumTransactionCostPerPoint = 2;
        private readonly int PlatiniumBalanceCostPerPoint = 1000;
        public int RewardPoints { get; private set; }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor((accountBalance / PlatiniumBalanceCostPerPoint) + (transactionAmount / PlatiniumTransactionCostPerPoint)), 0);
        }
    }
}
