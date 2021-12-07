using System;
using System.Collections.Generic;


namespace DB_Managment_Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            String command = "";
            Console.Write("Do you want to connect to the database(y/n): ");
            command = Console.ReadLine();
            if(command == "y"){
                db.connect();
            }
            
            Console.WriteLine("Welcome to the college finder! This application will help you find a college that is right for you!");
            Console.WriteLine();

            //display menu 

            //give an option of which option to select
                //Filter on state 
                //Filter on public or private
                //Filter on max tuition 
                //Filter on major offered 
                //Filter on sports offered



        }

        public void displayMenu(){
            
        } 
    }
}
