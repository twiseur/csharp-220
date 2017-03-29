using FurnitureDB;

namespace FurnitureRepository
{
    class FurnitureDatabaseManager
    {
        private static readonly FurnituresEntities entities;

        // Initialize and open the database connection
        static FurnitureDatabaseManager()
        {
            entities = new FurnituresEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static FurnituresEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
