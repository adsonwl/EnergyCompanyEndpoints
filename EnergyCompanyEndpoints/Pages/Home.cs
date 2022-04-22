using EnergyEndpoint.ConsoleApp.Interfaces;

namespace EnergyEndpoint.ConsoleApp.Pages
{
    public class Home : IHome
    {
        private IInsert _insert;
        private IEdit _edit;
        private IDelete _delete;
        private ISelect _select;

        public Home(IInsert insert, IEdit edit, IDelete delete, ISelect select)
        {
            _insert = insert;
            _edit = edit;
            _delete = delete;
            _select = select;
        }

        public void InitialOptions()
        {
            bool doNotExit = true;
            do {
                Console.Clear();
                Console.WriteLine("Choose one of the following options(type the correponding number):");
                Console.WriteLine("1 - Insert a new endpoint");
                Console.WriteLine("2 - Edit an existing endpoint");
                Console.WriteLine("3 - Delete an existing endpoint");
                Console.WriteLine("4 - List all endpoints");
                Console.WriteLine("5 - Find a endpoint by 'Endpoint Serial Number'");
                Console.WriteLine("6 - Exit");
                Console.WriteLine(":");

                string option = Console.ReadLine();

                if (option != null && option.All(char.IsDigit))
                {
                    int intOption = Int32.Parse(option);
                    switch (intOption)
                    {
                        case 1:
                            _insert.InsertOptions();
                            break;
                        case 2: 
                            _edit.EditOptions();
                            break;
                        case 3:
                            _delete.DeleteOptions();
                            break;
                        case 4:
                            _select.SelectAll();
                            break;
                        case 5:
                            _select.SelectBySerialNumber();
                            break;
                        case 6:
                            doNotExit = false;
                            break;    
                        default: 
                            Console.WriteLine();
                            break;

                    }
                }
                
                Console.WriteLine(option);
            } while (doNotExit);
        }
    }
}
