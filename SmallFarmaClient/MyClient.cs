// Главный рабочий класс - он формирует внешний и внутренний циклы 
// взаимодействия с пользователем.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace SmallFarmaClient
{
    public class MyClient
    {
        // объект подключения к БД
        private SqlConnection sqlConn = null;

        // флаги завершения внешнего и внутреннего циклов взаимодействия с пользователем
        private bool FlagToStop0 = false;
        private bool FlagToStop1 = false;

        // Главный (внешний) цикл обработки
        public void MainCircle(SqlConnection sc)
        {
            sqlConn = sc;
            if (sqlConn != null)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Запущена программа 'Консольный клиент для работы с БД SmallFarma'.");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine();

                FlagToStop0 = false;
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("**************************************************************************");
                    Console.WriteLine("******** Главное Меню ********");
                    Console.WriteLine("**************************************************************************");
                    Console.WriteLine("Что вы хотите сделать? Выберите один из предложенных вариантов:");
                    Console.WriteLine("**************************************************************************");
                    Console.WriteLine(" * Наберите '1' - если хотите работать с Товарами.");
                    Console.WriteLine(" * Наберите '2' - если хотите работать с Аптеками.");
                    Console.WriteLine(" * Наберите '3' - если хотите работать со Складами.");
                    Console.WriteLine(" * Наберите '4' - если хотите работать с Партиями.");
                    Console.WriteLine(" * Наберите '5' - если хотите построить Отчет.");
                    Console.WriteLine(" * Наберите '6' - если хотите завершить работу с программой.");
                    Console.WriteLine("**************************************************************************");
                    Console.WriteLine();

                    string sInput1 = Console.ReadLine();
                    int iInput1 = 0;
                    if (int.TryParse(sInput1, out iInput1))
                    {
                        switch (iInput1)
                        {
                            case 1: // Работа с Товарами
                                {
                                    InternalCircle(iInput1, "с Товарами", "Товар");
                                    break;
                                }
                            case 2: // Работа с Аптеками
                                {
                                    InternalCircle(iInput1, "с Аптеками", "Аптеку");
                                    break;
                                }
                            case 3: // Работа со Складами
                                {
                                    InternalCircle(iInput1, "со Складами", "Склад");
                                    break;
                                }
                            case 4: // Работа с Партиями
                                {
                                    InternalCircle(iInput1, "с Партиями", "Партию");
                                    break;
                                }
                            case 5: // Построение Отчета
                                {
                                    MakeReport();
                                    break;
                                }
                            case 6: // Завершение работы с программой
                                {
                                    FlagToStop0 = true;
                                    break;
                                }
                        }
                    }

                    // выход по условию завершения
                    if (FlagToStop0)
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Программа 'Консольный клиент для работы с БД SmallFarma' - успешно завершена!");
                Console.WriteLine("Для выхода нажмите ENTER.");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Нет подключения к Базе Данных! Продолжение работы невозможно!");
                Console.WriteLine("Для выхода нажмите ENTER.");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.WriteLine("===============================================================================");
                Console.ReadLine();
            }
            
        }

        // ==============================================================================
        // Подчиненный (внутренний) цикл обработки
        private void InternalCircle(int table, string type, string name)
        {
            FlagToStop1 = false;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("    *****************************************************************");
                Console.WriteLine($"    **** Работа {type} ****");
                Console.WriteLine("    *****************************************************************");
                Console.WriteLine("    Что вы хотите сделать? Выберите один из предложенных вариантов: ");
                Console.WriteLine("    *****************************************************************");
                Console.WriteLine($"       ** Наберите '1' - если хотите добавить {name}.");
                Console.WriteLine($"       ** Наберите '2' - если хотите удалить {name}.");
                Console.WriteLine($"       ** Наберите '3' - если хотите вернуться в главное меню.");
                Console.WriteLine("    *****************************************************************");

                string sInput2 = Console.ReadLine();
                int iInput2 = 0;
                if (int.TryParse(sInput2, out iInput2))
                {
                    switch (iInput2)
                    {
                        case 1:
                        {
                            AddOneObject(table);
                            break;
                        }
                        case 2:
                        {
                            RemoveOneObject(table);
                            break;
                        }
                        case 3:
                        {
                            FlagToStop1 = true;
                            break;
                        }
                    }
                }

                if (FlagToStop1)
                    break;
            }
        }

        // -------------------------------------------------------------------------------------------------
        // Функция для добавления объекта из основной группы.
        private void AddOneObject(int i)
        {
            switch (i)
            {
                case 1: // добавить Товар
                {
                    AddProduct();
                    break;
                }
                case 2: // добавить Аптеку
                {
                    AddPharmace();
                    break;
                }
                case 3: // добавить Склад
                {
                    AddWarehouse();
                    break;
                }
                case 4: // добавить Партию
                {
                    AddParty();
                    break;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------------
        // Функция для удаления объекта из основной группы.
        private void RemoveOneObject(int i)
        {
            switch (i)
            {
                case 1: // удалить Товар
                {
                    DeleteProduct();
                    break;
                }
                case 2: // удалить Аптеку
                {
                    DeletePharmace();
                    break;
                }
                case 3: // удалить Склад
                {
                    DeleteWarehouse();
                    break;
                }
                case 4: // удалить Партию
                {
                    DeleteParty();
                    break;
                }
            }
        }

        // ===================================================================================================
        // ==== Добавление ====
        // ===================================================================================================
        // ----------------------------------------------------------------------------------------------------
        // Добавить Товар
        private void AddProduct()
        {
            Product p = new Product();
            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Добавление Товара ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор товара", ref iKey1))
            {
                p.id = iKey1;
            }
            else
            {
                return;
            }

            p.Prod_Name = GetIntValue("название товара");

            // все данные для продукта собраны. Можно добавлять.
            string sql = "Insert Into Products (id, Prod_Name) Values(@id, @Prod_Name)";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@Prod_Name", p.Prod_Name);
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine();
                    Console.WriteLine("         ******** НОВЫЙ ТОВАР БЫЛ УСПЕШНО ДОБАВЛЕН! ********");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    // Это выводит слишком много и слишком страшно
                    //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                    Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("         !!! ОШИБКА !!! Не удалось добавить Товар !!!");
                    Console.WriteLine();
                }
            }
        }
        
        // ----------------------------------------------------------------------------------------------------
        // Добавить Аптеку
        private void AddPharmace()
        {
            Pharmace pa = new Pharmace();

            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Добавление Аптеки ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор аптеки", ref iKey1))
            {
                pa.id = iKey1;
            }
            else
            {
                return;
            }
            pa.Phar_Name = GetIntValue("название аптеки");
            pa.Address = GetIntValue("адрес аптеки");
            pa.Phone = GetIntValue("телефон аптеки");

            // все данные для аптеки собраны. Можно добавлять.
            string sql = "Insert Into Pharmacies (id, Phar_Name, Address, Phone) Values(@id, @Phar_Name, @Address, @Phone)";

            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.Parameters.AddWithValue("@id", pa.id);
                cmd.Parameters.AddWithValue("@Phar_Name", pa.Phar_Name);
                cmd.Parameters.AddWithValue("@Address", pa.Address);
                cmd.Parameters.AddWithValue("@Phone", pa.Phone);
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine();
                    Console.WriteLine("         ******** НОВАЯ АПТЕКА БЫЛА УСПЕШНО ДОБАВЛЕНА! ********");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    // Это выводит слишком много и слишком страшно
                    //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                    Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("         !!! ОШИБКА !!! Не удалось добавить Аптеку !!!");
                    Console.WriteLine();
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------
        // Добавить Склад
        private void AddWarehouse()
        {
            Warehouse w = new Warehouse();

            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Добавление Склада ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор склада", ref iKey1))
            {
                w.id = iKey1;
            }
            else
            {
                return;
            }

            int iKey2 = 0;
            if (TryGetIntValue("идентификатор аптеки, к которой относится склад", ref iKey2))
            {
                w.id_phar = iKey2;
            }
            else
            {
                return;
            }

            w.Ware_Name = GetIntValue("название склада");

            // все данные для склада собраны. Можно добавлять.
            string sql = "Insert Into Warehouses (id, id_phar, Ware_Name) Values(@id, @id_phar, @Ware_Name)";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.Parameters.AddWithValue("@id", w.id);
                cmd.Parameters.AddWithValue("@id_phar", w.id_phar);
                cmd.Parameters.AddWithValue("@Ware_Name", w.Ware_Name);
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine();
                    Console.WriteLine("         ******** НОВЫЙ СКЛАД БЫЛ УСПЕШНО ДОБАВЛЕН! ********");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    // Это выводит слишком много и слишком страшно
                    //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                    Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("         !!! ОШИБКА !!! Не удалось добавить Склад !!!");
                    Console.WriteLine();
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------
        // Добавить Партию
        private void AddParty()
        {
            Party p = new Party();

            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Добавление Партии ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор партии", ref iKey1))
            {
                p.id = iKey1;
            }
            else
            {
                return;
            }

            int iKey2 = 0;
            if (TryGetIntValue("идентификатор товара, поставленного в этой партии", ref iKey2))
            {
                p.id_prod = iKey2;
            }
            else
            {
                return;
            }

            int iKey3 = 0;
            if (TryGetIntValue("идентификатор склада, где хранится эта партия", ref iKey3))
            {
                p.id_ware = iKey3;
            }
            else
            {
                return;
            }

            int iKey4 = 0;
            if (TryGetIntValue("количество единиц товара в этой партии", ref iKey4))
            {
                p.count = iKey4;
            }
            else
            {
                return;
            }

            // все данные для партии собраны. Можно добавлять.
            string sql = "Insert Into Parties (id, id_prod, id_ware, count) Values(@id, @id_prod, @id_ware, @count)";
            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.Parameters.AddWithValue("@id", p.id);
                cmd.Parameters.AddWithValue("@id_prod", p.id_prod);
                cmd.Parameters.AddWithValue("@id_ware", p.id_ware);
                cmd.Parameters.AddWithValue("@count", p.count);
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine();
                    Console.WriteLine("         ******** НОВАЯ ПАРТИЯ БЫЛА УСПЕШНО ДОБАВЛЕНА! ********");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    // Это выводит слишком много и слишком страшно
                    //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                    Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("         !!! ОШИБКА !!! Не удалось добавить Партию !!!");
                    Console.WriteLine();
                }
            }
        }

        // ===================================================================================================
        // ==== Удаление ====
        // ===================================================================================================
        // ----------------------------------------------------------------------------------------------------
        // Удалить Товар
        private void DeleteProduct()
        {
            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Удаление Товара ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор товара", ref iKey1))
            {
                string sql = $"Delete From Products Where id = {iKey1}";
                using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
                {   
                    try
                    {
                        int deletedRows = cmd.ExecuteNonQuery();

                        if (deletedRows > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВЫБРАННЫЙ ТОВАР БЫЛ УСПЕШНО УДАЛЕН! ********");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВНИМАНИЕ!!! ТОВАРА С ЗАДАННЫМ ИДЕНТИФИКАТОРОМ НЕ СУЩЕСТВУЕТ! ********");
                            Console.WriteLine();
                        }
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        // Это выводит слишком много и слишком страшно
                        //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                        Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        Console.WriteLine("         !!! ОШИБКА !!! Не удалось удалить Товар !!!");
                        Console.WriteLine();
                    }
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------
        // Удалить Аптеку
        private void DeletePharmace()
        {
            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Удаление Аптеки ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор аптеки", ref iKey1))
            {
                string sql = $"Delete From Pharmacies Where id = {iKey1}";
                using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
                {
                    try
                    {
                        int deletedRows = cmd.ExecuteNonQuery();

                        if (deletedRows > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВЫБРАННАЯ АПТЕКА БЫЛА УСПЕШНО УДАЛЕНА! ********");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВНИМАНИЕ!!! АПТЕКИ С ЗАДАННЫМ ИДЕНТИФИКАТОРОМ НЕ СУЩЕСТВУЕТ! ********");
                            Console.WriteLine();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        // Это выводит слишком много и слишком страшно
                        //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                        Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        Console.WriteLine("         !!! ОШИБКА !!! Не удалось удалить Аптеку !!!");
                        Console.WriteLine();
                    }
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------
        // Удалить Склад
        private void DeleteWarehouse()
        {
            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Удаление Склада ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор склада", ref iKey1))
            {
                string sql = $"Delete From Warehouses Where id = {iKey1}";
                using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
                {
                    try
                    {
                        int deletedRows = cmd.ExecuteNonQuery();

                        if (deletedRows > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВЫБРАННЫЙ СКЛАД БЫЛ УСПЕШНО УДАЛЕН! ********");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВНИМАНИЕ!!! СКЛАДА С ЗАДАННЫМ ИДЕНТИФИКАТОРОМ НЕ СУЩЕСТВУЕТ! ********");
                            Console.WriteLine();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        // Это выводит слишком много и слишком страшно
                        //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                        Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        Console.WriteLine("         !!! ОШИБКА !!! Не удалось удалить Склад !!!");
                        Console.WriteLine();
                    }
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------
        // Удалить Партию
        private void DeleteParty()
        {
            Console.WriteLine();
            Console.WriteLine("        *****************************************************************");
            Console.WriteLine("        **** Удаление Партии ****");
            Console.WriteLine("        *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор партии", ref iKey1))
            {
                string sql = $"Delete From Parties Where id = {iKey1}";
                using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
                {
                    try
                    {
                        int deletedRows = cmd.ExecuteNonQuery();

                        if (deletedRows > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВЫБРАННАЯ ПАРТИЯ БЫЛА УСПЕШНО УДАЛЕНА! ********");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("         ******** ВНИМАНИЕ!!! ПАРТИИ С ЗАДАННЫМ ИДЕНТИФИКАТОРОМ НЕ СУЩЕСТВУЕТ! ********");
                            Console.WriteLine();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        // Это выводит слишком много и слишком страшно
                        //Console.WriteLine("         !!! ОШИБКА: " + e.Message + " !!!");
                        Console.WriteLine("         !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        Console.WriteLine("         !!! ОШИБКА !!! Не удалось удалить Партию !!!");
                        Console.WriteLine();
                    }
                }
            }
        }

        // ===================================================================================================
        // ==== Построение отчета ====
        // ===================================================================================================
        private void MakeReport()
        {
            Console.WriteLine();
            Console.WriteLine("    *****************************************************************");
            Console.WriteLine("    **** Построение отчета ****");
            Console.WriteLine("    *****************************************************************");
            Console.WriteLine("    **** Будет определено общее количество всех товаров ****");
            Console.WriteLine("    **** на всех складах, относящихся к выбранной аптеке. ****");
            Console.WriteLine("    *****************************************************************");

            int iKey1 = 0;
            if (TryGetIntValue("идентификатор аптеки, для которой надо построить отчет", ref iKey1))
            {
                string sql1 = $"Select id_prod, Sum(Parties.count) As cnt From Warehouses, Parties Where Warehouses.id_phar = {iKey1} " +
                                "and Warehouses.id = Parties.id_ware " +
                                "Group by id_prod";
                string sql2 = $"Select Products.Prod_Name, TableX.cnt From Products, ({sql1}) TableX Where Products.id = TableX.id_prod";

                using (SqlCommand cmd = new SqlCommand(sql2, sqlConn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine();
                    Console.WriteLine("    {0}\t{1}", reader.GetName(0), reader.GetName(1));
                    Console.WriteLine("    ---------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine("    {0}\t{1}", reader.GetValue(0), reader.GetValue(1));
                    }
                    reader.Close();
                }
            }
        }
        

        // ===================================================================================================
        // ==== служебные функции ====
        // ===================================================================================================
        // Маленькая служебная функция - хочет ли пользователь продолжить работу после того, как
        // он ошибся со вводом данных - либо произошла какая-то другая проблема.
        private bool WhouldYouContinue()
        {
            Console.WriteLine();
            Console.WriteLine("         ######## Ошибка ввода! Недопустимое значение!");
            Console.WriteLine("         ######## Вы ходите продолжить работу (1 = ДА | 0 = НЕТ): ");
            string sInput = Console.ReadLine();
            int iInput = 0;
            if (int.TryParse(sInput, out iInput))
            {
                if (iInput == 1)
                    return true;
            }
            return false;
        }

        // ----------------------------------------------------------------------------------------------------
        // Маленькая служебная функция для получения целочисленного значения
        private bool TryGetIntValue(string q, ref int val)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"          *** Введите {q}:");
                string sInput3 = Console.ReadLine();
                int iInput3 = 0;
                if (int.TryParse(sInput3, out iInput3))
                {
                    val = iInput3;
                    return true;
                }
                if (!WhouldYouContinue())
                    return false;
            }
        }

        // ----------------------------------------------------------------------------------------------------
        // Маленькая служебная функция для получения строкового значения
        private string GetIntValue(string q)
        {
            Console.WriteLine();
            Console.WriteLine($"          *** Введите {q}:");
            return Console.ReadLine();
        }
    }
}
