using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    public abstract class TextBox : IUndoable
    {
        protected string baseText;
        protected string text;

        protected TextBox() 
        {
            this.baseText = $"{GetType()}:Type baseText";
            this.text = $"{GetType()}:Type text.";
        }

        protected virtual void TypeText()
        {
            Console.WriteLine(text);
        }

        public abstract void EditTextAllowed();

        public abstract void EditTextDisAllowed();

        protected virtual void Undo()
        {
            Console.WriteLine($"{GetType()}.Undo.");
        }

        void IUndoable.Undo()
        {
            this.Undo();
        }
    }
}
