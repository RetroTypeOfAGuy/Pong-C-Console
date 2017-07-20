using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gamestart
{
    class recrtangle:dot
    {
        public int hight { get; set; }
        public int wight { get; set; }


         public recrtangle(int h,int w):base(h,w)
        {
            this.hight = h;
            this.wight = hight + hight / 2;
            this.Xcoordinate = w / 2;
            this.Ycoordinate = h / 2;
            this.Xspeed = 0;
            this.Yspeed = 0;
        }

         public override void DrawPlayer()
         {
             for (int col = 0; col < wight; col++)
             {
                 for (int row = 0; row < hight; row++)
                 {
                     Console.SetCursorPosition(this.Xcoordinate+col, this.Ycoordinate+row);
                     Console.Write('*');
                 }
             }
             
         }
         public override void DeletePlayer()
         {
             for (int col = 0; col < wight; col++)
             {
                 for (int row = 0; row < hight; row++)
                 {
                     Console.SetCursorPosition(this.Xcoordinate + col, this.Ycoordinate + row);
                     Console.Write(' ');
                 }
             }

         }
         public override char Bounce(int borderY, int borderX, char currentKey)
         {
             char bounceKey = currentKey;

             if (this.Ycoordinate == 1)
             {
                 bounceKey = 's';
             }
             if (this.Xcoordinate == 1)
             {
                 bounceKey = 'd';
             }
             if (this.Ycoordinate + wight== borderY )
             {
                 bounceKey = 'w';
             }
             if (this.Xcoordinate + hight == borderX - 2)
             {
                 bounceKey = 'a';
             }
             return bounceKey;


         }

    }
}
