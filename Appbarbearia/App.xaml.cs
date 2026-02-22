using Appbarbearia.Models;

namespace Appbarbearia
{
    public partial class App : Application
    {
        
        public static DataBaseService Database { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "barbearia.db3");

            Database = new DataBaseService(dbPath);

            MainPage = new NavigationPage(new CadastroPage());
        }
    }
}