using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading; 
using System.ComponentModel;

namespace SJF___Non_Preemptive_Case
{

    // C# program to implement Shortest Job first with Arrival
    // Time


    public class GFG
    {
        protected static void Display(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(s);

        }

        static int[,] mat = new int[8, 10];

        static void arrangeArrival(int Total_Pesanan, int[,] mat)
        {
            //
            for (int i = 0; i < Total_Pesanan; i++)
            {
                for (int j = 0; j < Total_Pesanan - i - 1; j++)
                {
                    if (mat[j, 1] > mat[j + 1, 1])
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            int temp = mat[j, k];
                            mat[j, k] = mat[j + 1, k];
                            mat[j + 1, k] = temp;
                        }
                    }
                }

            }

        }

        static void completionTime(int Total_Pesanan, int[,] mat)
        {
            //
            int temp, val = -1;
            mat[0, 3] = mat[0, 1] + mat[0, 2];
            mat[0, 5] = mat[0, 3] - mat[0, 1];
            mat[0, 4] = mat[0, 5] - mat[0, 2];

            for (int i = 1; i < Total_Pesanan; i++)
            {
                temp = mat[i - 1, 3];
                int low = mat[i, 2];
                for (int j = i; j < Total_Pesanan; j++)
                {
                    if (temp >= mat[j, 1] && low >= mat[j, 2])
                    {
                        low = mat[j, 2];
                        val = j;
                    }
                }
                mat[val, 3] = temp + mat[val, 2];
                mat[val, 5] = mat[val, 3] - mat[val, 1];
                mat[val, 4] = mat[val, 5] - mat[val, 2];
                for (int k = 0; k < 6; k++)
                {
                    int tem = mat[val, k];
                    mat[val, k] = mat[i, k];
                    mat[i, k] = tem;
                }
            }
        }

        // Driver Code
        static public void Main()    // PROGRAM UTAMA.
        {
            string e;
            Get_Costumer();




            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //Display(15, 0, "Rumah Makan Cendana");
            //Console.ResetColor();





            //Berikut list 

            Console.WriteLine("\t\tList Menu");

            // inisialisasi kelas RM_Cendana dengan objek one - six. 
            RM_Cendana one = new RM_Cendana("Nasi Goreng", 15000);

            // Copy Constructor
            RM_Cendana two = new RM_Cendana("Bakso", 12000);
            RM_Cendana three = new RM_Cendana("Mie Ayam", 15000);
            RM_Cendana four = new RM_Cendana("Es Teh", 5000);
            RM_Cendana five = new RM_Cendana("Es Jeruk", 6000);
            RM_Cendana six = new RM_Cendana("Air Putih", 4000);

            // Objek" dibuat ke list. , Mungkin bisa arrray List.
            List<RM_Cendana> Daftar_Menu = new List<RM_Cendana>();
            Daftar_Menu.Add(one);
            Daftar_Menu.Add(two);
            Daftar_Menu.Add(three);
            Daftar_Menu.Add(four);
            Daftar_Menu.Add(five);
            Daftar_Menu.Add(six);

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < Daftar_Menu.Count; i++)
            {
                Console.WriteLine($"\t\t{i}. {Daftar_Menu[i].Menu_Food} = Rp.{Daftar_Menu[i].price} ");
            }


            Console.WriteLine();
            Console.WriteLine();



            //Daftar_Menu.Select(x => x.Menu_Food).ToArray();


            Ordering(Daftar_Menu);


            // Final. 







        }
        static void Ordering(List<RM_Cendana> Order)
        {

            // Ordering untuk makanan. 
            Console.WriteLine();
            Console.WriteLine("Ingin pesan berapa menu = ");
            Console.WriteLine("Untuk Makanan : ");

            // RM_Cendana one = new RM_Cendana("",2000);
            Console.Beep();
            Console.Write("Input : ");
            int Order_Food = int.Parse(Console.ReadLine());
            //  Array
            string[] arr = new string[Order_Food];

            // Pemesanan makanan menggunakan perulangan. 
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Beep();
                Console.Write($"{i}. ");
                arr[i] = Console.ReadLine();
            }


            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i].Contains("Nasi Goreng") || arr[i].Contains("nasi goreng"))
                {
                    Console.Beep();
                    Console.Write($"Ingin pesan {arr[i]} berapa porsi ?");
                    Console.WriteLine();

                    Console.Write("Input = ");

                    int v = int.Parse(Console.ReadLine());

                }
                Console.WriteLine();

                if (arr[i].Contains("Bakso") || arr[i].Contains("bakso"))
                {
                    Console.Beep();
                    Console.Write($"Ingin pesan {arr[i]} berapa porsi ?");
                    Console.WriteLine();

                    Console.Write("Input = ");

                    int val2 = int.Parse(Console.ReadLine());
                }

                if (arr[i].Contains("Mie Ayam") || arr[i].Contains("mie ayam"))
                {
                    Console.Beep();
                    Console.Write($"Ingin pesan {arr[i]} berapa porsi ?");
                    Console.WriteLine();
                    Console.Write("Input = ");

                    int val3 = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Ingin pesan berapa menu = ");


            Console.WriteLine("Untuk Minuman : ");
            Console.Beep();
            Console.Write("Input : ");
            int Order_Drink = int.Parse(Console.ReadLine());

            string[] arr_drink = new string[Order_Drink];


            for (int i = 0; i < arr_drink.Length; i++)
            {
                Console.Beep();
                Console.Write($"{i}. ");
                arr_drink[i] = Console.ReadLine();
            }


            // Tampilkan, searching.
            for (int i = 0; i < arr_drink.Length; i++)
            {

                if (arr_drink[i].Contains("Air Mineral") || arr_drink[i].Contains("air mineral"))
                {
                    Console.Beep();
                    Console.Write($"Ingin pesan {arr_drink[i]} berapa porsi ?");
                    Console.WriteLine();

                    Console.Write("Input = ");
                    int val4 = int.Parse(Console.ReadLine());
                }


                if (arr_drink[i] == "Es Teh" || arr_drink[i] == "es teh")
                {
                    Console.Beep();
                    Console.Write($"Ingin pesan {arr_drink[i]} berapa porsi ?");
                    Console.WriteLine();

                    Console.Write("Input = ");
                    _ = int.Parse(Console.ReadLine());
                }

                if (arr_drink[i] == "Es Jeruk" || arr_drink[i] == "es jeruk")
                {
                    Console.Beep();
                    Console.Write($"Ingin pesan {arr_drink[i]} berapa porsi ?");
                    Console.WriteLine();

                    Console.Write("Input = ");

                    int val6 = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            //  string food_names;

            int Total_Pesanan = Order_Food + Order_Drink;


            Console.WriteLine();
            Console.Write("Pelanggan dengan antrean ke-");
            int queue = int.Parse(Console.ReadLine());

            // Console.WriteLine($"{}");

            Console.WriteLine("\tTotal Pesanan : ");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\t\t {Order_Food} + {Order_Drink} = {Total_Pesanan}");
            Console.ResetColor();
            Console.WriteLine();
            // Console.WriteLine("Pelanggan ke- ");


            Console.WriteLine("Antrian........");
            Console.WriteLine();

            string[] lar = new string[Total_Pesanan];


            for (int i = 0; i < lar.Length; i++)
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("...Proses ke" + (i + 1) + "...");
                Console.WriteLine("");
                Console.ResetColor();


                Console.Write($"Order Queue : ");
                mat[i, 0] = Convert.ToInt32(Console.ReadLine());

                // Masih tambah variable khusus untuk makanan. 
                Console.Write("Order Menu Name : ");
                lar[i] = Console.ReadLine();


                Console.Write("Enter Arrival Time: ");
                mat[i, 1] = Convert.ToInt32(Console.ReadLine());


                Console.Write("Enter Burst Time: ");
                mat[i, 2] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Before Arrange...");
            Console.ResetColor();


            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Order Queue\t\tOrder Menu\t\t\tArrival Time\t\tBurst Time");
            Console.ResetColor();

            // string Menu_Makanan;

            for (int i = 0; i < Total_Pesanan; i++)
            {
                Console.WriteLine($"    {mat[i, 0]} \t\t\t  {lar[i]}         \t\t\t\t  {mat[i, 1]}   \t\t\t  {mat[i, 2]}");
            }

            arrangeArrival(Total_Pesanan, mat);
            completionTime(Total_Pesanan, mat);

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Final Result...");
            Console.ResetColor();
            Console.WriteLine();

            //Console.WriteLine("Order Queue\tArrival Time\tBurst Time\tWaiting Time\tTurnaround Time");
            Console.ForegroundColor = ConsoleColor.DarkYellow;


            Console.WriteLine("Order Queue\t\tArrival Time\t\tBurst Time\t\tWaiting Time\t\tTurnaround Time");
            Console.ResetColor();

            Console.WriteLine();


            for (int i = 0; i < Total_Pesanan; i++)
            {

                Console.WriteLine($"{mat[i, 0]} \t\t\t{mat[i, 1]} \t\t\t{mat[i, 2]}  \t\t\t {mat[i, 4]}\t\t\t{mat[i, 5]} ");
            }




        }

        private static void Counters(List<RM_Cendana> Count)
        {
            //  int TOTAL =  
        }
        public static void Get_Costumer()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Click \'ENTER\' to launch the program");
            Console.Beep();
            Console.WriteLine();
            Console.ResetColor();
            Console.ReadKey(true);

            Console.Write("Masukkan Nama Anda = ");
            string costumer = Console.ReadLine();

           

            Console.WriteLine($"Halo {costumer}, Selamat datang di RM CENDANA, silahkan memesan makanan yang tersedia di menu");

            Console.WriteLine("\n\n");



        }

      
    }

    class RM_Cendana
    {
        
        //field 

        public string Menu_Food;  // objek" bisa nnti diatur , intinya data" angka
        public int price;



        public RM_Cendana(string Menu_Food, int price)
        {
            this.Menu_Food = Menu_Food;
            this.price = price; 
        }
    
    
    }

    // This code is contributed by
    // Dharanendra L V.


}
