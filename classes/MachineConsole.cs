using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{

    public class MachineConsole
    {
        public void Start()
        {
            try
            {
                MainMenu();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Problem with access to DB.");
            }
            Console.WriteLine("End");
        }
        public void MainMenu()
        {
            Menu menu = new Menu("Select one option: ");
            menu.Add(new MenuItem("Print",
                new Action(() =>
                {
                    var m = MenuSelect();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Add",
                new Action(() =>
                {
                    var m = MenuAdd();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Delete",
              new Action(() =>
              {
                  var m = MenuDelete();
                  var item = m.Execute();
                  item.Execute();
              })));
            menu.Add(new MenuItem("Change",
             new Action(() =>
             {
                 var m = MenuChange();
                 var item = m.Execute();
                 item.Execute();
             })));
            menu.Add(new MenuItem("Exit program", new Action(() => { exit = true; })));

            while (!exit)
            {
                var item = menu.Execute();
                item.Execute();
            }
        }

        private bool exit = false;


        private Menu MenuSelect()
        {

            Console.WriteLine("Select table: ");
            MachineDAO machineDAO = new MachineDAO();
            ReplacementDAO replacementDAO = new ReplacementDAO();
            SparePartsDAO sparePartsDAO = new SparePartsDAO();
            ManufacturerDAO manufacturerDAO = new ManufacturerDAO();
            PhoneNumberDAO phoneNumberDAO = new PhoneNumberDAO();

            Console.WriteLine("1. machine");
            Console.WriteLine("2. replacement");
            Console.WriteLine("3. spare parts");
            Console.WriteLine("4. manufacturer");
            Console.WriteLine("5. phone number");
            Console.WriteLine("6. end");
            Console.WriteLine("7. back");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    foreach (Machine machine in machineDAO.GetAll())
                    {
                        Console.WriteLine($"{machine.ToString()}");
                    }
                    MainMenu();

                    break;
                case 2:
                    foreach (Replacement replacement in replacementDAO.GetAll())
                    {
                        Console.WriteLine($"{replacement.ToString()}");
                    }
                    MainMenu();
                    break;
                case 3:

                    foreach (SpareParts part in sparePartsDAO.GetAll())
                    {
                        Console.WriteLine($"{part.ToString()}");
                    }


                    MainMenu();
                    break;
                case 4:
                    foreach (Manufacturer manufacturer in manufacturerDAO.GetAll())
                    {
                        Console.WriteLine($"{manufacturer.ToString()}");
                    }
                    MainMenu();
                    break;
                case 5:
                    foreach (var variable in phoneNumberDAO.GetAll())
                    {
                        Console.WriteLine($"{variable.ToString()}");
                    }
                    MainMenu();
                    break;
                case 6:
                    Console.WriteLine("end");
                    break;
                case 7:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("invalid value");
                    MainMenu();
                    break;
            }

            return null;

        }
        private Menu MenuAdd()
        {

            Console.WriteLine("Add to table: ");
            MachineDAO machineDAO = new MachineDAO();
            ReplacementDAO replacementDAO = new ReplacementDAO();
            SparePartsDAO sparePartsDAO = new SparePartsDAO();
            ManufacturerDAO manufacturerDAO = new ManufacturerDAO();
            PhoneNumberDAO phoneNumberDAO = new PhoneNumberDAO();

            Console.WriteLine("1. machine");
            Console.WriteLine("2. replacement");
            Console.WriteLine("3. spare parts");
            Console.WriteLine("4. manufacturer");
            Console.WriteLine("5. phone number");
            Console.WriteLine("6. end");
            Console.WriteLine("7. back");

            int option = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("insert in order:  name, type, dimenX, dimenY, dimenZ,  price, weight,  manufacturer id,  isNew");
                        Machine machine = new Machine(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), (float)Convert.ToDouble(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToBoolean(Console.ReadLine()));
                        machineDAO.Save(machine);

                        MainMenu();

                        break;
                    case 2:

                        Console.WriteLine("insert in order:  machine id,spare parts id,date");
                        Replacement replacement = new Replacement(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToDateTime(Console.ReadLine()));
                        replacementDAO.Save(replacement);


                        MainMenu();
                        break;
                    case 3:

                        Console.WriteLine("insert in order:  name, type, dimenX, dimenY, dimenZ,  price");
                        SpareParts spareParts = new SpareParts(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                        sparePartsDAO.Save(spareParts);


                        MainMenu();
                        break;
                    case 4:
                        Console.WriteLine("insert name of manufacturer");
                        Manufacturer manufacturer = new Manufacturer(Console.ReadLine());
                        manufacturerDAO.Save(manufacturer);
                        MainMenu();
                        break;
                    case 5:
                        Console.WriteLine("insert in order:  manufacturer id, phone number");
                        PhoneNumber phoneNumber = new PhoneNumber(Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                        phoneNumberDAO.Save(phoneNumber);

                        MainMenu();
                        break;
                    case 6:
                        Console.WriteLine("end");
                        break;
                    case 7:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("invalid value");
                        MainMenu();
                        break;
                }


            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }
        private Menu MenuDelete()
        {
            Console.WriteLine("Delete from table: ");
            MachineDAO machineDAO = new MachineDAO();
            ReplacementDAO replacementDAO = new ReplacementDAO();
            SparePartsDAO sparePartsDAO = new SparePartsDAO();
            ManufacturerDAO manufacturerDAO = new ManufacturerDAO();
            PhoneNumberDAO phoneNumberDAO = new PhoneNumberDAO();

            Console.WriteLine("1. machine");
            Console.WriteLine("2. replacement");
            Console.WriteLine("3. spare parts");
            Console.WriteLine("4. manufacturer");
            Console.WriteLine("5. phone number");
            Console.WriteLine("6. end");
            Console.WriteLine("7. back");
            int index;
            int option = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("insert index for deletion");
                        index = Convert.ToInt32(Console.ReadLine());
                        machineDAO.Delete(index);

                        MainMenu();

                        break;
                    case 2:
                        Console.WriteLine("insert index for deletion");
                        index = Convert.ToInt32(Console.ReadLine());
                        replacementDAO.Delete(index);
                        MainMenu();
                        break;
                    case 3:

                        Console.WriteLine("insert index for deletion");
                        index = Convert.ToInt32(Console.ReadLine());
                        sparePartsDAO.Delete(index);


                        MainMenu();
                        break;
                    case 4:
                        Console.WriteLine("insert index for deletion");
                        index = Convert.ToInt32(Console.ReadLine());
                        manufacturerDAO.Delete(index);
                        MainMenu();
                        break;
                    case 5:
                        Console.WriteLine("insert index for deletion");
                        index = Convert.ToInt32(Console.ReadLine());
                        phoneNumberDAO.Delete(index);
                        MainMenu();
                        break;
                    case 6:
                        Console.WriteLine("end");
                        break;
                    case 7:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("invalid value");
                        MainMenu();
                        break;
                }


            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;

        }
        private Menu MenuChange()
        {
            Console.WriteLine("Change in table: ");
            MachineDAO machineDAO = new MachineDAO();
            ReplacementDAO replacementDAO = new ReplacementDAO();
            SparePartsDAO sparePartsDAO = new SparePartsDAO();
            ManufacturerDAO manufacturerDAO = new ManufacturerDAO();
            PhoneNumberDAO phoneNumberDAO = new PhoneNumberDAO();

            Console.WriteLine("1. machine");
            Console.WriteLine("2. replacement");
            Console.WriteLine("3. spare parts");
            Console.WriteLine("4. manufacturer");
            Console.WriteLine("5. phone number");
            Console.WriteLine("6. end");
            Console.WriteLine("7. back");

            int option = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (option)
                {
                    case 1:
                        Console.WriteLine("insert in order:  id,name, type, dimenX, dimenY, dimenZ,  price, weight,  manufacturer id,  isNew");
                        Machine machine = new Machine(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), (float)Convert.ToDouble(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToBoolean(Console.ReadLine()));
                        machineDAO.Save(machine);

                        MainMenu();

                        break;
                    case 2:

                        Console.WriteLine("insert in order: id, machine id,spare parts id,date");
                        Replacement replacement = new Replacement(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToDateTime(Console.ReadLine()));
                        replacementDAO.Save(replacement);


                        MainMenu();
                        break;
                    case 3:

                        Console.WriteLine("insert in order:  id, name, type, dimenX, dimenY, dimenZ,  price");
                        SpareParts spareParts = new SpareParts(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                        sparePartsDAO.Save(spareParts);


                        MainMenu();
                        break;
                    case 4:
                        Console.WriteLine("insert id + name of manufacturer");
                        Manufacturer manufacturer = new Manufacturer(Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                        manufacturerDAO.Save(manufacturer);
                        MainMenu();
                        break;
                    case 5:
                        Console.WriteLine("insert in order:  id, manufacturer id, phone number");
                        PhoneNumber phoneNumber = new PhoneNumber(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                        phoneNumberDAO.Save(phoneNumber);

                        MainMenu();
                        break;
                    case 6:
                        Console.WriteLine("end");
                        break;
                    case 7:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("invalid value");
                        MainMenu();
                        break;
                }


            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }
    }
}
