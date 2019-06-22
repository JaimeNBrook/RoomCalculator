using System;
using System.Text.RegularExpressions;

namespace RoomCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //configuration
            int numberOfCoatsRequired = 2; // assume 2 coats of paint are required for a good finish
            double litresPerSquareMetre = 0.1; //the amount of paint needed to cover a square meter of wall
            double doorSize = (1.981 * 0.762); // typical interior door size in the UK
            double windowSize = (1.050 * 0.915); // window sizes vary, but this is the median window size in the UK

            //get input from user
            double roomWidth = GetInput("How wide is the room in metres?");
            double roomLength = GetInput("How long is the room in metres?");
            double roomHeight = GetInput("How tall is the room in metres?");
            double numberOfDoors = GetInput("How many doors are there in the room?");
            double numberOfWindows = GetInput("How many windows are there in the room?");

            // create instance of room object
            Room room = new Room{
                WidthInMetres = roomWidth,
                LengthInMetres = roomLength,
                HeightInMetres = roomHeight,
                NumberOfDoors = numberOfDoors,
                NumberOfWindows = numberOfWindows,
                DoorSize = doorSize,
                WindowSize = windowSize
            };
           
           //write output to user
            Console.WriteLine($"Floor area of the room = {room.GetFloorArea()}m²");
            Console.WriteLine($"Volume of the room is {room.GetVolume()}m³");
            Console.WriteLine(
                $"Assuming {numberOfCoatsRequired} coats of paint, the amount of paint required to paint the walls is " + 
                $"{Math.Round((room.GetTotalWallSurfaceArea() * litresPerSquareMetre),2)} litres" // round to 2 dp
            );
            
        }

        static double GetInput(string requestText){ // asks a user for a double parameter
            double output = 0;
            while(output == 0){ // while output has not been set
                try{
                    Console.WriteLine(requestText);
                    //use regex to strip all but valid numbers
                    output = Convert.ToDouble(Regex.Replace(Console.ReadLine(), "[^0-9.]", ""));
                }
                catch{ // user has input something that is not a valid double
                    Console.WriteLine("That is not a valid number, please try again");
                }
            }
            return output;
        }
    }

    public class Room {
        public double WidthInMetres {get;set;}
        public double LengthInMetres {get;set;}
        public double HeightInMetres {get;set;}

        public double NumberOfDoors {get;set;}
        public double NumberOfWindows {get;set;}

        public double DoorSize {get;set;}
        public double WindowSize{get;set;}

        public double GetPerimeter(){ // calculate perimeter (assumming room is 4 walls)
            return (LengthInMetres * 2) + (WidthInMetres * 2);
        }

        public double GetTotalWallSurfaceArea(){ // calculate total wall surface area
             return (GetPerimeter() * HeightInMetres) 
                    - (NumberOfDoors * DoorSize) - (NumberOfWindows * WindowSize);
        }

        public double GetFloorArea(){ // calculate floor area
            return LengthInMetres * WidthInMetres;
        }

        public double GetVolume(){// calculate the volume of the room
            return LengthInMetres * WidthInMetres * HeightInMetres;
        }
    }
}
