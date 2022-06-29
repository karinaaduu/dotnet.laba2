using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Linq;


namespace lab2dn
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Storage> storages = new List<Storage>
            {
                new Storage { _StorageID =  1,
                            _CurrentWeight = 0,
                            _MaxWeight = 1000.88 },

                 new Storage { _StorageID =  2,
                            _CurrentWeight = 0,
                            _MaxWeight = 20000.54 },

                  new Storage { _StorageID =  3,
                            _CurrentWeight = 0,
                            _MaxWeight = 10000.21 },

                   new Storage { _StorageID =  4,
                            _CurrentWeight = 0,
                            _MaxWeight = 15000.33 }
            };
            List<Product> products = new List<Product> {
                  new Product {                                   //0
                _ProductID = "DF395398",
                _ProductName = "Кава Ground Coffee",
                _ProductWeightPack = 0.5,
                _ProductPrice = 310.64,
                _ManufacturerName = "Dunkin Donuts"
                },
                new Product {                                   //1
                _ProductID = "SW985323",
                _ProductName = "Печиво Choco Cow",
                _ProductWeightPack = 0.7,
                _ProductPrice = 60.34,
                _ManufacturerName = "Milka"
                },
                new Product {                                   //2
                _ProductID = "GT398762",
                _ProductName = "Холодильник GR-187",
                _ProductWeightPack = 61,
                _ProductPrice = 22500.67,
                _ManufacturerName = "Samsung"
                },
                new Product {                                   //3
                _ProductID = "PH761129",
                _ProductName = "Духовка Induction Freestanding Range",
                _ProductWeightPack = 114.67,
                _ProductPrice = 91012.5,
                _ManufacturerName = "Electrolux"
                },
                 new Product {                                   //4
                _ProductID = "YU892647",
                _ProductName = "Стiл Solid Acacia Wood ",
                _ProductWeightPack = 43.3,
                _ProductPrice = 16200,
                _ManufacturerName = "Castlery"
                },
                new Product {                                   //5
                _ProductID = "KL064573",
                _ProductName = "Диван Campbelltown",
                _ProductWeightPack = 48.08,
                _ProductPrice = 17010.4,
                _ManufacturerName = "Wayfair"
                },
                 new Product {                                   //6
                _ProductID = "MN456783",
                _ProductName = "Печиво Savoiardi",
                _ProductWeightPack = 1.2,
                _ProductPrice = 110.64,
                _ManufacturerName = "Ital.Tiram"
                },
                new Product {                                   //7
                _ProductID = "IO983012",
                _ProductName = "Буфетниця Solid Acacia Wood ",
                _ProductWeightPack = 38.4,
                _ProductPrice = 20370,
                _ManufacturerName = "Castlery"
                },
                 new Product {                                   //8
                _ProductID = "WE067548",
                _ProductName = "Шоколад Wholenut Caramel ",
                _ProductWeightPack = 0.1,
                _ProductPrice = 55.99,
                _ManufacturerName = "Milka"
                },
                  new Product {                                   //9
                _ProductID = "JK813254",
                _ProductName = "Вафлi Choco Wafer ",
                _ProductWeightPack = 0.3,
                _ProductPrice = 45.9,
                _ManufacturerName = "Milka"
                }
            };
            products[0].ArrivalDate(storages[0], new DateTime(2021, 12, 18), 100);
            products[0].ArrivalDate(storages[0], new DateTime(2022, 1, 11), 150);
            products[0].ArrivalDate(storages[0], new DateTime(2022, 2, 16), 200);

            products[1].ArrivalDate(storages[0], new DateTime(2022, 2, 1), 200);
            products[1].ArrivalDate(storages[0], new DateTime(2022, 3, 22), 300);

            products[2].ArrivalDate(storages[1], new DateTime(2022, 2, 4), 50);
            products[2].ArrivalDate(storages[1], new DateTime(2022, 4, 28), 70);

            products[3].ArrivalDate(storages[1], new DateTime(2022, 5, 21), 100);

            products[4].ArrivalDate(storages[2], new DateTime(2022, 3, 2), 50);
            products[4].ArrivalDate(storages[2], new DateTime(2022, 5, 19), 65);

            products[5].ArrivalDate(storages[2], new DateTime(2022, 4, 17), 20);
            products[5].ArrivalDate(storages[2], new DateTime(2022, 6, 5), 30);

            products[6].ArrivalDate(storages[3], new DateTime(2022, 6, 9), 100);

            products[7].ArrivalDate(storages[2], new DateTime(2022, 3, 12), 25);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("ProductsAtStorage.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ProductsAtStorage");

                writer.WriteStartElement("Products");
                foreach (Product product in products)
                {
                    writer.WriteStartElement("product");
                    writer.WriteElementString("ProductID", product._ProductID);
                    writer.WriteElementString("ProductName", product._ProductName);
                    writer.WriteElementString("ProductWeightPack", product._ProductWeightPack.ToString());
                    writer.WriteElementString("ProductPrice", product._ProductPrice.ToString());
                    writer.WriteElementString("ManufacturerName", product._ManufacturerName);

                    writer.WriteStartElement("ArrivalDates");
                    foreach (ProductArrivalDates arrivalDate in product._productArrivalDates)
                    {
                        writer.WriteStartElement("arrivalDate");
                        writer.WriteElementString("ProductsStorageID", arrivalDate._ProductStorage._StorageID.ToString());
                        writer.WriteElementString("ArrivalDate", arrivalDate._Date.ToString());
                        writer.WriteElementString("AmountOfProductPacks", arrivalDate._AmountOfProductPacks.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteStartElement("Storages");
                foreach (Storage storage in storages)
                {
                    writer.WriteStartElement("storage");
                    writer.WriteElementString("StorageID", storage._StorageID.ToString());
                    writer.WriteElementString("CurrentWeight", storage._CurrentWeight.ToString());
                    writer.WriteElementString("MaxWeight", storage._MaxWeight.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            XDocument xmlDoc = XDocument.Load("ProductsAtStorage.xml");
            getAllProductsAndStorages(xmlDoc);
            getTotalProductWeightOnStorages(xmlDoc);
            getProductPricesMoreThan(xmlDoc, 1000);
            getMostExpesiveProduct(xmlDoc);
            getSortedProducts(xmlDoc, 3);
            getLargestProductsAmountAtStorage(xmlDoc, 3);
            getDesiredProduct(xmlDoc, "Печиво");
            getGroupedProducts(xmlDoc);
            getProductsWithStorages(xmlDoc);
            getAllProductPrice(xmlDoc);
            getSelection(xmlDoc, 1000, 50000);
            collectionToArray(xmlDoc);
            collectionZIP(xmlDoc);
            collectionsUnion(xmlDoc);
            collectionsIntersect(xmlDoc);

            addStorageElementsToXML(xmlDoc);
            Console.ReadKey();
        }
        static void getAllProductsAndStorages(XDocument xmlDoc)   //1.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Виведення всього XML файлу.\n1. Вивести всi товари на складах");
            Console.ResetColor();
            var selectedproducts = xmlDoc.Descendants("product").Select(p => p);
            foreach (var product in selectedproducts)
            {
                outputProduct(product);
                Console.WriteLine("\nСписок дат надходжень товару :");
                outputArrivalDates(product);
                Console.WriteLine("----------------------------------------");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nВивести всi склади");
            Console.ResetColor();

            foreach (var storage in xmlDoc.Descendants("storage").Select(row => row))
            {
                outputStorage(storage);
            }
        }
        
        static void getTotalProductWeightOnStorages(XDocument xmlDoc)     //2.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n2. Загальна вага всiх товарiв на складах:");
            Console.ResetColor();

            //create linq query to get total product weight on storages
            var totalProductWeightOnStorages = from product in xmlDoc.Descendants("product")
                                               select new
                                               {
                                                   weight = Double.Parse((string)product.Element("ProductWeightPack")) * product.Element("ArrivalDates")
                                                   .Elements("arrivalDate").Sum(x => Int32.Parse(x.Element("AmountOfProductPacks").Value)),
                                                   name = (string)product.Element("ProductName")
                                               };
            foreach (var row in totalProductWeightOnStorages)
            {
                Console.WriteLine("Продукта {0} всього {1} кг", row.name, row.weight);
            }
        }

        static void getProductPricesMoreThan(XDocument xmlDoc, double price)       //3.
        {
            var selectedproducts = from p in xmlDoc.Descendants("product")
                                   where Double.Parse((string)p.Element("ProductPrice")) > price
                                   orderby Double.Parse((string)p.Element("ProductPrice"))
                                   select new
                                   {
                                       name = (string)p.Element("ProductName"),
                                       price = Double.Parse((string)p.Element("ProductPrice"))
                                   };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n3. Товари, в яких цiна вища {0} грн:", price);
            Console.ResetColor();

            foreach (var row in selectedproducts)
            {
                Console.WriteLine("Товар: {0},  Цiна={1}", row.name, row.price);
            }
        }

        static void getMostExpesiveProduct(XDocument xmlDoc) //4.
        {
            var mostExpensiveProduct = xmlDoc.Descendants("product")
                .Aggregate((expensive, next) => Double.Parse((string)expensive.Element("ProductPrice"))
                                             < Double.Parse((string)next.Element("ProductPrice")) ? next : expensive);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n4. Найдорожчий товар з колекцii: \n");
            Console.ResetColor();
            outputProduct(mostExpensiveProduct);
        }

        static void getSortedProducts(XDocument xmlDoc, int storageID)   //5.
        {

            var sel = from p in xmlDoc.Descendants("product")
                      where p.Element("ArrivalDates").Elements("arrivalDate").Any(x => Int32.Parse((string)x.Element("ProductsStorageID")) == storageID)
                      orderby (string)p.Element("ProductName")
                      select new
                      {
                          name = (string)p.Element("ProductName"),
                          id = (string)p.Element("ProductID"),
                      };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n5. Вiдсортованi товари по алфавiту за назвою на {0} складi: \n", storageID);
            Console.ResetColor();
            foreach (var row in sel)
            {
                Console.WriteLine("Товар: {0},  Номер: {1}", row.name, row.id);
            }
        }

        static void getLargestProductsAmountAtStorage(XDocument xmlDoc, int storageID) //6.
        {
            var maxQuantityProduct = xmlDoc.Descendants("product")
                                           .Where(p => p.Element("ArrivalDates").Elements("arrivalDate")
                                           .Any(x => Int32.Parse((string)x.Element("ProductsStorageID")) == storageID))
                                           .Aggregate((largest, next) =>
                                            largest.Element("ArrivalDates").Elements("arrivalDate").Sum(x => Int32.Parse(x.Element("AmountOfProductPacks").Value))
                                           < next.Element("ArrivalDates").Elements("arrivalDate").Sum(x => Int32.Parse(x.Element("AmountOfProductPacks").Value)) ? next : largest);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n6. Товар, який поставлявся в найбiльшiй кiлькостi на складi №{0} : ", storageID);
            Console.ResetColor();
            outputProduct(maxQuantityProduct);
            Console.WriteLine("Його кiлькiсть на складу {0}: {1}", storageID, maxQuantityProduct.Element("ArrivalDates").Elements("arrivalDate")
                                                                                                .Sum(x => Int32.Parse(x.Element("AmountOfProductPacks").Value)));
        }

        static void getDesiredProduct(XDocument xmlDoc, string productName)     //7. 
        {
            var selectedproducts = from p in xmlDoc.Descendants("product")
                                   where p.Element("ProductName").Value.Contains(productName)
                                   select new
                                   {
                                       id = (string)p.Element("ProductID"),
                                       name = (string)p.Element("ProductName"),
                                       manufacturer = (string)p.Element("ManufacturerName")
                                   };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n7. Товари, якi мають в назвi {0} : ", productName);
            Console.ResetColor();
            foreach (var row in selectedproducts)
            {
                Console.WriteLine("Товар: №{0},  {1}\nВиробник: {2}\n", row.id, row.name, row.manufacturer);
            }
        }
        static void getGroupedProducts(XDocument xmlDoc)    //8.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n8. Товари, згрупованi по виробникам:");
            Console.ResetColor();
            var selectedproducts = xmlDoc.Descendants("product").GroupBy(g => g.Element("ManufacturerName").Value);
            foreach (var group in selectedproducts)
            {
                Console.WriteLine("Виробник: {0}", group.Key);
                foreach (var row in group)
                {
                    outputProduct(row);
                }
            }
        }

        static void getProductsWithStorages(XDocument xmlDoc)     //9.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n9. Вивiд товарiв з вказанням складiв, на яких вони зберiгаються:");
            Console.ResetColor();

            foreach (var p in xmlDoc.Descendants("product"))
            {
                var productsAtStorages = from arrivalDate in p.Element("ArrivalDates").Elements("arrivalDate")
                                         join storage in xmlDoc.Descendants("storage") on Int32.Parse((string)arrivalDate.Element("ProductsStorageID"))
                                                                                          equals
                                                                                          Int32.Parse((string)storage.Element("StorageID"))
                                         //arrivalDate._ProductStorage._StorageID equals storage._StorageID
                                         select new
                                         {
                                             ProductName = (string)p.Element("ProductName"),
                                             StorageName = (string)storage.Element("StorageID"),
                                             ProductID = (string)p.Element("ProductID"),
                                         };
                foreach (var row in productsAtStorages.Distinct())
                {
                    Console.WriteLine("Код товару: {0}          Склад:{2}             Назва товару: {1}", row.ProductID,
                        row.ProductName, row.StorageName);
                }
            }
        }
        static void getAllProductPrice(XDocument xmlDoc)        //10.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n10. Загальна цiна всiх партiй кожного з товарiв:");
            Console.ResetColor();

            foreach (var product in xmlDoc.Descendants("product"))
            {
                Console.WriteLine("На складi вартiсть всiх партiй товару {0}: ={1} грн", product.Element("ProductName").Value,
               product.Element("ArrivalDates").Elements("arrivalDate")
                      .Sum(x => Int32.Parse((string)x.Element("AmountOfProductPacks"))) * Double.Parse((string)product.Element("ProductPrice")));
            }
        }

        static void getSelection(XDocument xmlDoc, double start, double end)       //11.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n11. Використання SkipWhile и TakeWhile. Вивiд товарiв, в яких цiна знаходиться в промiжку ({0};{1}]", start, end);
            Console.ResetColor();

            var selectedProducts = xmlDoc.Descendants("product").OrderBy(x => Double.Parse((string)x.Element("ProductPrice")))
                                           .SkipWhile(x => (Double.Parse((string)x.Element("ProductPrice")) < start))
                                           .TakeWhile(x => Double.Parse((string)x.Element("ProductPrice")) <= end);
            foreach (var product in selectedProducts)
                Console.WriteLine("Товар:  {0}    Цiна: {1} грн", product.Element("ProductName").Value, product.Element("ProductPrice").Value);
        }

        static void collectionToArray(XDocument xmlDoc)      //12.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n12. Результат перетворюється в масив");
            Console.ResetColor();

            var productsArray = (from x in xmlDoc.Descendants("product").Elements("ProductName") select (string)x).ToArray();

            Console.WriteLine("Який тип був:");
            Console.WriteLine(xmlDoc.Element("ProductsAtStorage").Element("Products").Elements("product").Elements("ProductName").GetType().Name);
            Console.WriteLine("Який тип став:");
            Console.WriteLine(productsArray.GetType().Name);

            foreach (var productString in productsArray)
                Console.WriteLine(productString);
        }

        static void collectionZIP(XDocument xmlDoc)       //13.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n13. Використання Zip:");
            Console.ResetColor();
            List<Storage> storages2 = new List<Storage>
            {
                   new Storage { _StorageID =  5,
                            _CurrentWeight = 0,
                            _MaxWeight = 2400.88 },

                   new Storage { _StorageID =  6,
                            _CurrentWeight = 0,
                            _MaxWeight = 30100.54 },

                   new Storage { _StorageID =  7,
                            _CurrentWeight = 0,
                            _MaxWeight = 18934.4 },

                   new Storage { _StorageID =  8,
                            _CurrentWeight = 0,
                            _MaxWeight = 100500.2 },
            };
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            //create the writer object and write the XML to a file products, storages using the settings object
            using (XmlWriter writer = XmlWriter.Create("xmlFor13Query.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Storages2");
                foreach (Storage storage in storages2)
                {
                    writer.WriteStartElement("storage");
                    writer.WriteElementString("StorageID", storage._StorageID.ToString());
                    writer.WriteElementString("CurrentWeight", storage._CurrentWeight.ToString());
                    writer.WriteElementString("MaxWeight", storage._MaxWeight.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();  //закриває елемент Storages
                writer.WriteEndDocument();
            }
            XDocument xmlDocFor13query = XDocument.Load("xmlFor13Query.xml");

            var ZIPstorages = xmlDoc.Descendants("storage").Zip(xmlDocFor13query.Descendants("storage"), (first, second) => "Номер складiв:                "
            + first.Element("StorageID").Value + "        " + second.Element("StorageID").Value + "\n" +
              "Максимальна наповненiсть: " + first.Element("MaxWeight").Value + "   " + second.Element("MaxWeight").Value + "\n");

            foreach (var row in ZIPstorages)
                Console.WriteLine(row);
        }
        static void collectionsUnion(XDocument xmlDoc)       //14.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n14. Union - об'єднання для об'єктiв з виключенням дублiкатiв:");
            Console.ResetColor();

            List<Storage> storages3 = new List<Storage>
            {
                   new Storage { _StorageID =  1,
                            _CurrentWeight = 575,
                            _MaxWeight = 1000.88 },

                   new Storage { _StorageID =  2,
                            _CurrentWeight = 18787,
                            _MaxWeight = 20000.54 },

                   new Storage { _StorageID =  5,
                            _CurrentWeight = 0,
                            _MaxWeight = 18934.4 },

                   new Storage { _StorageID =  6,
                            _CurrentWeight = 0,
                            _MaxWeight = 100500.2 },
            };
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            //create the writer object and write the XML to a file products, storages using the settings object
            using (XmlWriter writer = XmlWriter.Create("xmlFor14Query.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Storages3");
                foreach (Storage storage in storages3)
                {
                    writer.WriteStartElement("storage");
                    writer.WriteElementString("StorageID", storage._StorageID.ToString());
                    writer.WriteElementString("CurrentWeight", storage._CurrentWeight.ToString());
                    writer.WriteElementString("MaxWeight", storage._MaxWeight.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();  //закриває елемент Storages3
                writer.WriteEndDocument();
            }
            XDocument xmlDocFor14query = XDocument.Load("xmlFor14Query.xml");

            foreach (var storage in xmlDoc.Descendants("storage").Union(xmlDocFor14query.Descendants("storage"), new StorageEqualityComparer()))
            {
                outputStorage(storage);
            }
        }
        static void collectionsIntersect(XDocument xmlDoc)       //15.
        {
            List<Storage> storages4 = new List<Storage>
            {
                   new Storage { _StorageID =  1,
                            _CurrentWeight = 575,
                            _MaxWeight = 1000.88 },

                   new Storage { _StorageID =  2,
                            _CurrentWeight = 18787,
                            _MaxWeight = 20000.54 },

                   new Storage { _StorageID =  5,
                            _CurrentWeight = 0,
                            _MaxWeight = 18934.4 },

                   new Storage { _StorageID =  6,
                            _CurrentWeight = 0,
                            _MaxWeight = 100500.2 },
            };
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("xmlFor15Query.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Storages4");
                foreach (Storage storage in storages4)
                {
                    writer.WriteStartElement("storage");
                    writer.WriteElementString("StorageID", storage._StorageID.ToString());
                    writer.WriteElementString("CurrentWeight", storage._CurrentWeight.ToString());
                    writer.WriteElementString("MaxWeight", storage._MaxWeight.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();  //закриває елемент Storages3
                writer.WriteEndDocument();
            }
            XDocument xmlDocFor15query = XDocument.Load("xmlFor15Query.xml");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n15. Intersect - перетин множин для об'єктiв ");
            Console.ResetColor();

            foreach (var storage in xmlDoc.Descendants("storage").Intersect(xmlDocFor15query.Descendants("storage"), new StorageEqualityComparer()))
            {
                outputStorage(storage);
            }
        }
        static void addStorageElementsToXML(XDocument xmlDoc)
        {
            Console.WriteLine("Input an ID of new Storage: ");
            string id = Console.ReadLine();
            bool original = false;
            do
            {
                var selectedstorages = from p in xmlDoc.Descendants("storage")
                                       where p.Element("StorageID").Value.Contains(id)
                                       select p;
                if (selectedstorages.Count() != 0)
                {
                    Console.WriteLine("Storage with that ID is already exist. Try again: ");
                    id = Console.ReadLine();
                }
                else original = true;
            } while (original == false);

            Console.WriteLine("Input a MaxWeight of new Storage: ");
            double maxWeight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Input a CurrentWeight of new Storage: ");
            double currentWeight = Convert.ToDouble(Console.ReadLine());
            original = false;
            do
            {
                if (maxWeight < currentWeight)
                {
                    Console.WriteLine("MaxWeight exceeds CurrentWeight. Try again: ");
                    currentWeight = Convert.ToDouble(Console.ReadLine());
                }
                else original = true;

            } while (original == false);

            xmlDoc.Element("ProductsAtStorage").Element("Storages").Add(
                    new XElement("storage",
                    new XElement("StorageID", id),
                    new XElement("MaxWeight", maxWeight.ToString()),
                    new XElement("CurrentWeight", currentWeight.ToString())
                )
            );

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The new Storage has been successfully added.");
            Console.ResetColor();

            xmlDoc.Save("ProductsAtStorage.xml");
        }

        static void outputProduct(XElement productElement)
        {
            XElement productIDAttribute = productElement.Element("ProductID");
            XElement productNameElement = productElement.Element("ProductName");
            XElement productWeightPackElement = productElement.Element("ProductWeightPack");
            XElement productPriceElement = productElement.Element("ProductPrice");
            XElement productManufacturerElement = productElement.Element("ManufacturerName");

            if (productIDAttribute != null && productNameElement != null && productManufacturerElement
               != null && productPriceElement != null && productWeightPackElement != null)
            {
                Console.WriteLine("\n" + @"Товар:
                Код товара: {0}
                Назва товару: {1}
                Виробник: {2}
                Ціна за одиниці: {3}
                Вага одиниці: {4}", productIDAttribute.Value,
                                    productNameElement.Value,
                                    productManufacturerElement.Value,
                                    productPriceElement.Value,
                                    productWeightPackElement.Value);

            }
        }

        static void outputStorage(XElement storageElement)
        {
            XElement storageIDAttribute = storageElement.Element("StorageID");
            XElement storageCurrentWeight = storageElement.Element("CurrentWeight");
            XElement storageMaxWeight = storageElement.Element("MaxWeight");

            if (storageIDAttribute != null && storageCurrentWeight != null && storageMaxWeight != null)
            {
                Console.WriteLine("\n" + @"Склад:
                Код складу: {0}
                Назва складу: {1}
                Максимальна наповненiсть: {2}", storageIDAttribute.Value,
                                                storageCurrentWeight.Value,
                                                storageMaxWeight.Value);
            }
        }

        static void outputArrivalDates(XElement productElement)
        {
            foreach (XElement arrivalDate in productElement.Element("ArrivalDates").Elements("arrivalDate"))
            {
                Console.WriteLine(string.Format(@"
                    ID складу {0}              
                    Дата прибуття на склад: {1}
                    Кількість продукту: {2}",
                arrivalDate.Element("ProductsStorageID").Value,
                arrivalDate.Element("ArrivalDate").Value,
                arrivalDate.Element("AmountOfProductPacks").Value
                ));
            }
        }
    }
}
