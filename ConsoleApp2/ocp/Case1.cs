using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case1
    {
        interface ICoolGuy
        {
            void CallCoolGuy();
        }
        class User
        {
            private bool _isSelected;
            private string _image;

            public User(bool isSelected, string image)
            {
                _isSelected = isSelected;
                _image = image;
            }
            public void DrawUser()
            {
                if (_isSelected)
                    DrawEllipseAroundUser();
                if (_image != null)
                    DrawImageOfUser();
                if (this is ICoolGuy) // редкий случай
                    DrawCoolGuyGlasses();
                // И т. д.
            }
            void DrawEllipseAroundUser() { }
            void DrawImageOfUser() { }
            void DrawCoolGuyGlasses() { }
        }
    }
}
