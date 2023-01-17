using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_5
{
    public class EditTextBox : TextBox
    {
        protected new string text;

        public EditTextBox()
        {
            this.text = $"{GetType()}:Type text.";
        }

        protected override void TypeText()
        {
            Console.WriteLine(text);
        }

        public override void EditTextAllowed()
        {
            base.TypeText();
            Console.WriteLine(base.text);
            Console.WriteLine(base.baseText);
        }

        public override void EditTextDisAllowed()
        {
            //TextBox baseObj = (TextBox)this;
            //baseObj.TypeText();
            //baseObj.text += "ss";
            //baseObj.baseText += "ss";
        }
    }
}
