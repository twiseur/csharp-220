using System;

namespace InventoryApp.Models
{
    public class FurnitureModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public double Value { get; set; }

        internal FurnitureModel Clone()
        {
            return (FurnitureModel)MemberwiseClone();
        }

        public FurnitureRepository.FurnitureModel ToRepositoryModel()
        {
            var repositoryModel = new FurnitureRepository.FurnitureModel
            {
                Id = Id,
                Description = Description,
                Price = Price,
                Quantity = Quantity,
                Cost = Cost,
                Value = Value
            };

            return repositoryModel;
        }

        public static FurnitureModel ToModel(FurnitureRepository.FurnitureModel respositoryModel)
        {
            var contactModel = new FurnitureModel
            {
                Id = respositoryModel.Id,
                Description = respositoryModel.Description,
                Price = respositoryModel.Price,
                Quantity = respositoryModel.Quantity,
                Cost = respositoryModel.Cost,
                Value = respositoryModel.Value
            };

            return contactModel;
        }
    }
}
