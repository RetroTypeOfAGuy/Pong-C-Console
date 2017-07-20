using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gamestart
{
    class dot
    {

        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }
        public int Xspeed { get; set; }
        public int Yspeed { get; set; }

        public virtual void DrawPlayer()
        {
            Console.SetCursorPosition(this.Xcoordinate, this.Ycoordinate);
            Console.Write('*');
        }

        public virtual void DeletePlayer()
        {
            Console.SetCursorPosition(this.Xcoordinate, this.Ycoordinate);
            Console.Write(' ');
        }

        public  dot(int h,int w)
        {
            this.Xcoordinate = w/2;
            this.Ycoordinate = h/2;
            this.Xspeed = 0;
            this.Yspeed = 0;
        }

        public void move()
        {
            
            this.Ycoordinate += Xspeed;
            this.Xcoordinate += Yspeed;
        }
        
        public void Directions(char key)
        {
            switch (key)
            {
                case  'a':
                    this.Yspeed = -1;
                    this.Xspeed = 0;
                    break;
                case 'd':
                    this.Yspeed = 1;
                    this.Xspeed = 0;
                    break;
                case 'w':
                    this.Yspeed = 0;
                    this.Xspeed = -1;
                    break;
                case 's':
                    this.Yspeed = 0;
                    this.Xspeed = 1;
                    break;  
                default:
                    break;
            }
            move();
        }

        public virtual char Bounce(int borderY, int borderX, char currentKey)
        {
            char bounceKey = currentKey;   

            if (this.Ycoordinate == 1 )
            {
                bounceKey = 's';
            }
            if (this.Xcoordinate == 1)
            {
                bounceKey = 'd';
            }
            if (this.Ycoordinate == borderY-2)
            {
                bounceKey = 'w';
            }
            if (this.Xcoordinate == borderX-2)
            {
                bounceKey = 'a';
            }
            return bounceKey;
        }


    }
}

