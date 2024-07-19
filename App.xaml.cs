using fchTarea5.Utils;

namespace fchTarea5
{
    public partial class App : Application
    {
        public static PersonaRepositorio personRepo { get; set; }

        public App(PersonaRepositorio person)
        {
            InitializeComponent();

            MainPage = new Views.vHome();
            personRepo = person;
        }
    }
}
