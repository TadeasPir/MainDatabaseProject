using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
           /// <summary>
           /// Displays the main menu and handles user input.
           /// </summary>
        public void MainMenu()
        {
            Menu menu = new Menu("Select one option to edit: ");
            menu.Add(new MenuItem("Machine",
                new Action(() =>
                {
                    var m = MenuMachine();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Replacement",
             new Action(() =>
             {
                 var m = MenuReplacement();
                 var item = m.Execute();
                 item.Execute();
             })));

            menu.Add(new MenuItem("Manufacturer",
                new Action(() =>
                {
                    var m = MenuManufacturer();
                    var item = m.Execute();
                    item.Execute();
                })));
            menu.Add(new MenuItem("Spare parts",
              new Action(() =>
              {
                  var m = MenuSpareParts();
                  var item = m.Execute();
                  item.Execute();
              })));
            menu.Add(new MenuItem("Phone number",
             new Action(() =>
             {
                 var m = MenuPhoneNumber();
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

        /// <summary>
        /// Displays a menu for selecting a table and lists its contents.
        /// </summary>
        /// <returns>The selected menu.</returns>
        /// 

        private Menu MenuMachine() 
        {

            Menu m = new Menu("select one: ");
            MachineDAO machineDAO = new MachineDAO();
          
          
            m.Add(new MenuItem("print",
                new Action(() =>
                {
                    foreach (Machine machine in machineDAO.GetAll())
                    {
                        Console.WriteLine($"{machine.ToString()}");
                    }


                })));
            m.Add(new MenuItem("add",
              new Action(() =>
              {
                  Console.WriteLine("insert in order:  name, type, dimenX, dimenY, dimenZ,  price, weight,  manufacturer id,  isNew");
                  Machine machine = new Machine(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), (float)Convert.ToDouble(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToBoolean(Console.ReadLine()));
                  machineDAO.Save(machine);

              })));

            m.Add(new MenuItem("delete",
             new Action(() =>
             {
                 Console.WriteLine("insert index for deletion");
                 int index = Convert.ToInt32(Console.ReadLine());
                 machineDAO.Delete(index);


             })));
            
            m.Add(new MenuItem("update",
             new Action(() =>
             {
                 Console.WriteLine("insert in order:  id,name, type, dimenX, dimenY, dimenZ,  price, weight,  manufacturer id,  isNew");
                 Machine machine = new Machine(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), (float)Convert.ToDouble(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToBoolean(Console.ReadLine()));
                 machineDAO.Save(machine);


             })));
            m.Add(new MenuItem("import",
             new Action(() =>
             {
                 machineDAO.Import("Import.xml");


             })));

          
            return m;

        }
        
        private Menu MenuReplacement()
        {

            Menu m = new Menu("select one: ");
            ReplacementDAO replacementDAO = new ReplacementDAO();

            m.Add(new MenuItem("print",
                new Action(() =>
                {
                    foreach (Replacement replacement in replacementDAO.GetAll())
                    {
                        Console.WriteLine($"{replacement.ToString()}");
                    }


                })));
            m.Add(new MenuItem("add",
              new Action(() =>
              {
                  Console.WriteLine("insert in order:  machine id,spare parts id,date");
                  Replacement replacement = new Replacement(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToDateTime(Console.ReadLine()));
                  replacementDAO.Save(replacement);

              })));

            m.Add(new MenuItem("delete",
             new Action(() =>
             {
                 Console.WriteLine("insert index for deletion");
                int index = Convert.ToInt32(Console.ReadLine());
                 replacementDAO.Delete(index);


             })));

            m.Add(new MenuItem("update",
             new Action(() =>
             {
                 Console.WriteLine("insert in order: id, machine id,spare parts id,date");
                 Replacement replacement = new Replacement(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToDateTime(Console.ReadLine()));
                 replacementDAO.Save(replacement);


             })));
            m.Add(new MenuItem("import",
             new Action(() =>
             {
                 replacementDAO.Import("Import.xml");


             })));


            return m;

        }  
        private Menu MenuSpareParts()
        {
            SparePartsDAO sparePartsDAO = new SparePartsDAO();
            Menu m = new Menu("select one: ");
          

            m.Add(new MenuItem("print",
                new Action(() =>
                {

                    foreach (SpareParts part in sparePartsDAO.GetAll())
                    {
                        Console.WriteLine($"{part.ToString()}");
                    }


                })));
            m.Add(new MenuItem("add",
              new Action(() =>
              {
                  Console.WriteLine("insert in order:  name, type, dimenX, dimenY, dimenZ,  price");
                  SpareParts spareParts = new SpareParts(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                  sparePartsDAO.Save(spareParts);
              })));

            m.Add(new MenuItem("delete",
             new Action(() =>
             {
                 Console.WriteLine("insert index for deletion");
                int index = Convert.ToInt32(Console.ReadLine());
                 sparePartsDAO.Delete(index);



             })));

            m.Add(new MenuItem("update",
             new Action(() =>
             {
                 Console.WriteLine("insert in order:  id, name, type, dimenX, dimenY, dimenZ,  price");
                 SpareParts spareParts = new SpareParts(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                 sparePartsDAO.Save(spareParts);


             })));
            m.Add(new MenuItem("import",
             new Action(() =>
             {
                 sparePartsDAO.Import("Import.xml");


             })));


            return m;

        } 
        private Menu MenuManufacturer()
        {
     
            Menu m = new Menu("select one: ");
            ManufacturerDAO manufacturerDAO = new ManufacturerDAO();

            m.Add(new MenuItem("print",
                new Action(() =>
                {

                    foreach (Manufacturer manufacturer in manufacturerDAO.GetAll())
                    {
                        Console.WriteLine($"{manufacturer.ToString()}");
                    }


                })));
            m.Add(new MenuItem("add",
              new Action(() =>
              {
                  Console.WriteLine("insert name of manufacturer");
                  Manufacturer manufacturer = new Manufacturer(Console.ReadLine());
                  manufacturerDAO.Save(manufacturer);
              })));

            m.Add(new MenuItem("delete",
             new Action(() =>
             {
                 Console.WriteLine("insert index for deletion");
                 int index = Convert.ToInt32(Console.ReadLine());
                 manufacturerDAO.Delete(index);



             })));

            m.Add(new MenuItem("update",
             new Action(() =>
             {
                 Console.WriteLine("insert id + name of manufacturer");
                 Manufacturer manufacturer = new Manufacturer(Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                 manufacturerDAO.Save(manufacturer);


             })));
            m.Add(new MenuItem("import",
             new Action(() =>
             {
                 manufacturerDAO.Import("Import.xml");


             })));


            return m;

        } 
        
        private Menu MenuPhoneNumber()
        {
     
            Menu m = new Menu("select one: ");
            PhoneNumberDAO phoneNumberDAO = new PhoneNumberDAO();

            m.Add(new MenuItem("print",
                new Action(() =>
                {

                    foreach (var variable in phoneNumberDAO.GetAll())
                    {
                        Console.WriteLine($"{variable.ToString()}");
                    }


                })));
            m.Add(new MenuItem("add",
              new Action(() =>
              {
                  Console.WriteLine("insert in order:  manufacturer id, phone number");
                  PhoneNumber phoneNumber = new PhoneNumber(Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                  phoneNumberDAO.Save(phoneNumber);
              })));

            m.Add(new MenuItem("delete",
             new Action(() =>
             {
                 Console.WriteLine("insert index for deletion");
                 int index = Convert.ToInt32(Console.ReadLine());
                 phoneNumberDAO.Delete(index); 



             })));

            m.Add(new MenuItem("update",
             new Action(() =>
             {
                 Console.WriteLine("insert in order:  id, manufacturer id, phone number");
                 PhoneNumber phoneNumber = new PhoneNumber(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Console.ReadLine());
                 phoneNumberDAO.Save(phoneNumber);


             })));
            m.Add(new MenuItem("import",
             new Action(() =>
             {
                 phoneNumberDAO.Import("Import.xml");


             })));


            return m;

        }
      
    }
}
