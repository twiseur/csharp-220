using FurnitureDB;
using System.Collections.Generic;
using System.Linq;

// CSHP220 Project
// Author: Thaddée Wiseur

namespace FurnitureRepository
{
    public class FurnitureModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Value { get; set; }
    }

    public class FurnitureRepository
    {
        public FurnitureModel Add(FurnitureModel furnitureModel)
        {
            var furnitureDB = ToDbModel(furnitureModel);

            FurnitureDatabaseManager.Instance.Furniture.Add(furnitureDB);
            FurnitureDatabaseManager.Instance.SaveChanges();

            furnitureModel = new FurnitureModel
            {
                Id = furnitureDB.FurnitureId,
                Description = furnitureDB.FurnitureDescription,
                Price = (double)furnitureDB.FurniturePrice,
                Quantity = (int)furnitureDB.FurnitureQuantity,
                Cost = (double)furnitureDB.FurnitureCost,
                Value = (double)furnitureDB.FurnitureValue
            };
            return furnitureModel;
        }

        public List<FurnitureModel> GetAll()
        {
            var furnitures = FurnitureDatabaseManager.Instance.Furniture
              .Select(t => new FurnitureModel
              {
                  Id = t.FurnitureId,
                  Description = t.FurnitureDescription,
                  Price = (double)t.FurniturePrice,
                  Quantity = (int)t.FurnitureQuantity,
                  Cost = (double)t.FurnitureCost,
                  Value = (double)t.FurnitureValue
              }).ToList();

            return furnitures;
        }

        public bool Update(FurnitureModel furnitureModel)
        {
            var original = FurnitureDatabaseManager.Instance.Furniture.Find(furnitureModel.Id);

            if (original != null)
            {
                FurnitureDatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(furnitureModel));
                FurnitureDatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        public bool Remove(int furnitureId)
        {
            var items = FurnitureDatabaseManager.Instance.Furniture
                                .Where(t => t.FurnitureId == furnitureId);

            if (items.Count() == 0)
            {
                return false;
            }

            FurnitureDatabaseManager.Instance.Furniture.Remove(items.First());
            FurnitureDatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Furniture ToDbModel(FurnitureModel furnitureModel)
        {
            var furnitureDb = new Furniture
            {
                FurnitureId = furnitureModel.Id,
                FurnitureDescription = furnitureModel.Description,
                FurniturePrice = furnitureModel.Price,
                FurnitureQuantity = furnitureModel.Quantity,
                FurnitureCost = furnitureModel.Cost,
                FurnitureValue = furnitureModel.Value,
            };

            return furnitureDb;
        }
    }
}
