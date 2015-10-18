namespace Computers.UI
{
    public class Rammstein
    {
        private int value;

        internal Rammstein(int a)
        {
            this.Amount = a;
        }

        public int Amount
        {
            get;
            set;
        }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}