using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam
{
    public class MenuItem
    {
        public string Text { get; set; }
        public Type ControlType { get; set; }
        public string About { get; set; }
        public MenuItem(string text, Type controlType, string about)
        {
            Text = text;
            ControlType = controlType;
            About = about;
        }

    }
}
