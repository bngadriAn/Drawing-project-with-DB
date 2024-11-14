using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace _1003_órai_console_léptetés
{
    public class Drawing
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CharPosX { get; set; }
        public int CharPosY { get; set; }
        public int GetCharNum { get; set; }
        public int GetColorNum { get; set; }
    }

    public class DrawingContext : DbContext
    {
        public DbSet<Drawing> Drawings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }

    internal class Program
    {
        static int x = 3, y = 8, cursorPosX = 0, cursorPosY = 0, charNum = 1, colorNum = 1;
        static int charPosX = 0, charPosY = 0, getCharNum = 0, getColorNum = 0, spacepress = 0;
        static string charAttributes = "";

        static void Main(string[] args)
        {
            //ensure db was created???
            Console.CursorVisible = false;
            int activeButton = 1;
            ConsoleKeyInfo input;
            DrawBorder();
            DrawButtons(activeButton);
            do
            {
                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (activeButton > 1)
                        {
                            activeButton--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (activeButton < 4)
                        {
                            activeButton++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, Console.WindowHeight - 2);
                        Console.WriteLine($"{activeButton}. option selected");
                        switch (activeButton)
                        {
                            case 1:
                                Console.Clear();
                                DrawingApp();
                                break;
                            case 2:
                                LoadDrawing();
                                break;
                            case 3:
                                DeleteDrawing();
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        break;
                }
                DrawButtons(activeButton);
            } while (input.Key != ConsoleKey.Escape);
        }

        static void DrawingApp()
        {
            string color = "Character color is: ";
            string character = "The set character is: ";
            char setCharacter = '░';
            Console.Write(color + "white    ");
            Console.Write("\n" + character + setCharacter);
            Console.Write("\nPlace characters with spacebar.");
            Console.Write("\nChange character color with numbers (1-5).");
            Console.Write("\nChange characters with letters (Q,W,E,R).");
            Console.Write("\nPress F12 to save drawing.");
            Console.SetCursorPosition(x, y);
            bool escPress = false;
            while (!escPress)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        escPress = true;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop < Console.WindowHeight - 1)
                        {
                            Console.CursorTop += 1;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop <= Console.WindowHeight - 1 && Console.CursorTop > 0)
                        {
                            Console.CursorTop -= 1;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.CursorLeft < Console.WindowWidth - 1)
                        {
                            Console.CursorLeft += 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft <= Console.WindowWidth - 1 && Console.CursorLeft > 0)
                        {
                            Console.CursorLeft -= 1;
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Write(setCharacter);
                        charPosX = cursorPosX;
                        charPosY = cursorPosY;
                        getColorNum = colorNum;
                        getCharNum = charNum;
                        charAttributes = (charPosX + "," + charPosY + "," + getColorNum + "," + getCharNum);
                        spacepress++;
                        break;
                    case ConsoleKey.D1:
                        Console.ForegroundColor = ConsoleColor.White;
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(color + "white  ");
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        colorNum = 1;
                        break;
                    case ConsoleKey.D2:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(color + "red    ");
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        colorNum = 2;
                        break;
                    case ConsoleKey.D3:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(color + "green   ");
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        colorNum = 3;
                        break;
                    case ConsoleKey.D4:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(color + "blue   ");
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        colorNum = 4;
                        break;
                    case ConsoleKey.D5:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(color + "magenta");
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        colorNum = 5;
                        break;
                    case ConsoleKey.Q:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        setCharacter = '░';
                        Console.SetCursorPosition(0, 0);
                        Console.Write("\n" + character + setCharacter);
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        charNum = 1;
                        break;
                    case ConsoleKey.W:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        setCharacter = '▒';
                        Console.SetCursorPosition(0, 0);
                        Console.Write("\n" + character + setCharacter);
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        charNum = 2;
                        break;
                    case ConsoleKey.E:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        setCharacter = '▓';
                        Console.SetCursorPosition(0, 0);
                        Console.Write("\n" + character + setCharacter);
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        charNum = 3;
                        break;
                    case ConsoleKey.R:
                        cursorPosX = Console.CursorLeft;
                        cursorPosY = Console.CursorTop;
                        setCharacter = '█';
                        Console.SetCursorPosition(0, 0);
                        Console.Write("\n" + character + setCharacter);
                        Console.SetCursorPosition(cursorPosX, cursorPosY);
                        charNum = 4;
                        break;
                    case ConsoleKey.F12:
                        SaveDrawing();
                        break;
                }
            }
            DateTime currentDate = DateTime.Now;
            Console.SetCursorPosition(0, 6);
            Console.WriteLine($"Drawing saved to database with date '{currentDate}'.");
        }

        static void LoadDrawing()
        {
            using (var context = new DrawingContext())
            {
                var drawings = context.Drawings.ToList();
                if (drawings.Any())
                {
                    foreach (var drawing in drawings)
                    {
                        Console.WriteLine($"ID: {drawing.Id}, Date: {drawing.Date}, Attributes: {drawing.Attributes}");
                    }
                }
                else
                {
                    Console.WriteLine("No drawings found.");
                }
            }
        }

        static void SaveDrawing()
        {
            string currentDate = DateTime.Now.ToString("MM_dd_yyyy");

            using (var context = new DrawingContext())
            {
                var drawing = new Drawing
                {
                    Date = currentDate,
                    Attributes = charAttributes
                    //TODO change saving the drawing chatacter data
                };
                context.Drawings.Add(drawing);
                context.SaveChanges();
            }
        }

        static void DrawButtons(int activeButton)
        {
            string[] options = { "Új rajz", "Korábbi szerkesztése", "Törlés", "Kilépés" };
            int buttonHeight = 6;
            int buttonWidth = 40;
            int verticalOffset = 1;

            int posX = (Console.WindowWidth - buttonWidth) / 2;
            int posy = (Console.WindowHeight - ((buttonHeight + verticalOffset) * options.Length)) / 2;
            posy = Math.Max(0, posy);
            for (int i = 0; i < options.Length; i++)
            {
                int buttonPosY = posy + i * (buttonHeight + verticalOffset) + 2;
                Console.SetCursorPosition(posX, buttonPosY);
                Console.Write('┌');
                for (int j = 1; j <= buttonWidth - 2; j++)
                {
                    Console.Write('─');
                }
                Console.WriteLine('┐');
                Console.SetCursorPosition(posX, buttonPosY + 1);
                Console.Write('│');
                if (i + 1 == activeButton)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else { Console.ResetColor(); }

                int buttonPadding = (buttonWidth - options[i].Length - 2) / 2;
                Console.Write(new string(' ', buttonPadding) + options[i] + new string(' ', buttonWidth - options[i].Length - 2 - buttonPadding));
                Console.ResetColor();
                Console.Write('│');

                Console.SetCursorPosition(posX, buttonPosY + 2);
                Console.Write('└');
                for (int j = 1; j <= buttonWidth - 2; j++)
                {
                    Console.Write('─');
                }
                Console.Write('┘');
            }
        }
        static void DrawBorder()
        {
            Console.Write('┌');
            for (int i = 1; i <= Console.WindowWidth - 2; i++)
            {
                Console.Write('─');
            }
            Console.WriteLine('┐');
            for (int i = 1; i <= Console.WindowHeight - 2; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('│');
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write('└');
            for (int i = 1; i <= Console.WindowWidth - 2; i++)
            {
                Console.Write('─');
            }
            Console.WriteLine('┘');
            for (int i = 1; i <= Console.WindowHeight - 2; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write('│');
            }
        }

        static void DeleteDrawing()
        {
            using (var context = new DrawingContext())
            {
                Console.Write("Enter the ID of the drawing to delete: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var drawing = context.Drawings.Find(id);
                    if (drawing != null)
                    {
                        context.Drawings.Remove(drawing);
                        context.SaveChanges();
                        Console.WriteLine("Drawing deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Drawing not found.");
                    }
                }
            }
        }
    }
}
