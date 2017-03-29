using System.Windows;

// CSHP220 Project
// Author: Thaddée Wiseur

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static FurnitureRepository.FurnitureRepository furnitureRepository;

        static App()
        {
            furnitureRepository = new FurnitureRepository.FurnitureRepository();
        }

        public static FurnitureRepository.FurnitureRepository FurnitureRepository
        {
            get
            {
                return furnitureRepository;
            }
        }
    }
}
