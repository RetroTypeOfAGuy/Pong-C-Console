using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameStart
{
    class ConsoleEngine:GameEngins
    {
        IRenderer Renderer { get; set; }
        IControls Controls { get; set; }
        Direction Direction { get; set; }
        Position Position { get; set; }


        public ConsoleEngine(IRenderer rend,IControls contr, Direction dir)
        {
            this.Direction = dir;
            this.Renderer = rend;
            this.Controls = contr;
        }


        public void GameStart()
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 160;
            Console.BufferHeight = 61;
            Console.BufferWidth = 190;
            string playerName ="";

            Border Border = new Border(Renderer, Direction, Position = new Position(Console.WindowHeight + 1, Console.WindowWidth * 2 / 3));

            Console.WriteLine("Chose Player 1 name:");
            playerName = Console.ReadLine();
            Player Player1 = new Player(playerName, Position = new Position(1, 108), Position = new Position(2, 108));

            Console.WriteLine("Chose Player 1 name:");
            playerName = Console.ReadLine();
            Player Player2 = new Player(playerName, Position = new Position(Player1.NamePosition.Y + 2, Player1.NamePosition.X), Position = new Position(Player1.ScorePosition.Y + 2, Player1.NamePosition.X));

            Console.Clear();

            Border.Draw();

            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(Player1.NamePosition.X, Player1.NamePosition.Y);
            Console.Write("Player1 : {0}",Player1.Name);
            Console.SetCursorPosition(Player1.ScorePosition.X, Player1.ScorePosition.Y);
            Console.Write("Score : {0}",Player1.Score);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Player2.NamePosition.X, Player2.NamePosition.Y);
            Console.Write("Player2 : {0}", Player2.Name);
            Console.SetCursorPosition(Player1.ScorePosition.X, Player2.ScorePosition.Y);
            Console.Write("Score : {0}", Player2.Score);

            int PadHeight = (Border.Position.Y-2)%10;

            GameElement Pad1 = new Pad(this.Renderer, Direction = new Direction(), Position = new Position(Border.Position.Y / 2 - PadHeight , 2), PadHeight, "White", Border.Position);

            GameElement Pad2 = new Pad(this.Renderer, Direction = new Direction(), Position = new Position(Border.Position.Y / 2, Border.Position.X - 3), PadHeight, "Red", Border.Position);

            Ball Ball = new Ball(Renderer, Direction = new Direction(), Position = new Position(Border.Position.Y/2, (Border.Position.X-2)/2), "Yellow");

            GamePhysics Physics = new GamePhysics(Pad1, Pad2, Ball, Border);

            //const int delay = 101;
            //DateTime check =  DateTime.Now.AddMilliseconds(delay);
            
            

            while (true)
            {
                
                Pad1.Remove();
                Pad2.Remove();
                Ball.Remove();
               // while (check > DateTime.Now)
               // {
                    if (Console.KeyAvailable)
                    {
                        ManageDirection(Pad1, Pad2, Ball);
                    }
                    else
                    {
                        Pad1.Direction.Stop();
                        Pad2.Direction.Stop();
                    }
               // }
                //check = DateTime.Now.AddMilliseconds(delay);
                
                Pad1.ChangePosition();
                Pad2.ChangePosition();
                //Ball.Bounce(Pad1, Pad2, Border);
                Physics.BorderBounce();
                if (Ball.Position.X == Pad1.Position.X+1)
                {
                    Physics.PadBounce(Pad1);
                }
                if (Ball.Position.X == Pad2.Position.X-1)
                {
                    Physics.PadBounce(Pad2);
                }
                if (Ball.Position.X == 1)
                {
                    Physics.BallReset();
                    Player2.Score++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(Player2.ScorePosition.X + 8, Player2.ScorePosition.Y);
                    Console.Write(Player2.Score);
                }
                if (Ball.Position.X == Border.Position.X - 2)
                {
                    Physics.BallReset();
                    Player1.Score++;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(Player1.ScorePosition.X + 8, Player1.ScorePosition.Y);
                    Console.Write(Player1.Score);
                }
                Ball.ChangePosition();
                Pad1.Draw();
                Pad2.Draw();
                Ball.Draw();
                
                Thread.Sleep(50);
            }
        }


        private void ManageDirection(GameElement element,GameElement element2, GameElement ball)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            key = Console.ReadKey(true);
            switch (key.Key)
            {
              //  case ConsoleKey.A:
              //      element.Direction.MoveLeft();
              //      break;
              //  case ConsoleKey.D:
              //      element.Direction.MoveRight();
              //      break;
                case ConsoleKey.W:
                    element.Direction.MoveUp();
                    break;
                case ConsoleKey.S:
                    element.Direction.MoveDown();
                    break;
              //  case ConsoleKey.LeftArrow:
              //      element2.Direction.MoveLeft();
              //      break;
              //  case ConsoleKey.RightArrow:
              //      element2.Direction.MoveRight();
              //      break;
                case ConsoleKey.UpArrow:
                    element2.Direction.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    element2.Direction.MoveDown();
                    break;
                case ConsoleKey.Spacebar:
                    ball.Direction.RandomDiag();
                    break;
                default:
                    break;
            }
        }



        public void GameOver()
        {
            throw new NotImplementedException();
        }
    }
}
