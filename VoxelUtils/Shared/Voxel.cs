﻿namespace VoxelUtils.Shared
{
    public class Voxel
    {
        private int _materialId;

        public int MaterialId
        {
            get => _materialId;
            set
            {
                if (value == Constant.MaterialAir)
                {
                    Amount = 0;
                }
                _materialId = value;
            }
        }

        public int Amount { get; private set; }
        public int EmptyNeighborCount { get; set; }
        public float FillingQuantity => (float)Amount / Constant.MaxMaterialAmount;

        public bool Exists => FillingQuantity > 1.0f / (2 * EmptyNeighborCount);

        public Voxel(int materialId, int amount, int emptyNeighborCount = 6)
        {
            _materialId = materialId;
            Amount = amount;
            EmptyNeighborCount = emptyNeighborCount;
        }

        public void AddMaterial(int amount)
        {
            Amount += amount;
        }

        public void TakeMaterial(int amount)
        {
            Amount -= amount;
            if (Amount == 0)
            {
                MaterialId = Constant.MaterialAir;
            }
        }
    }
}
