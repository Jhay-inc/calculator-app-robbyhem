namespace CalculatorAppTask
{
    public partial class form1 : Form
    {
        Double result = 0;
        String operation = "";
        bool enterValue = false;
        string firstNumber, secondNumber; //char iOperation;
        public form1()
        {
            InitializeComponent();
        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if ((textDisplay.Text == "0") || (enterValue))
                    textDisplay.Text = "";
            enterValue = false;

            if (button.Text == ".")
            {
                if (!textDisplay.Text.Contains("."))
                    textDisplay.Text = textDisplay.Text + button.Text;
            }
            else 
            {
                textDisplay.Text = textDisplay.Text + button.Text;
            }
        }

        private void operatorsClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (result != 0)
            {
                equalButton.PerformClick();
                enterValue = true;
                operation = button.Text;
                labelShowOperator.Text = result + " " + operation;
            }
            else
            {
                operation = button.Text;
                result = Double.Parse(textDisplay.Text);
                enterValue = true;
                textDisplay.Text = "";
                labelShowOperator.Text = Convert.ToString(result) + "  " + operation;
            }

            firstNumber = labelShowOperator.Text;

            //operation = button.Text;
            //result = Double.Parse(textDisplay.Text);
            //enterValue = true;
            //textDisplay.Text = "";
            //labelShowOperator.Text = Convert.ToString(result) + "  " + operation;

        }

        private void equalsClick(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textDisplay.Text = (result + Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "-":
                    textDisplay.Text = (result - Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "*":
                    textDisplay.Text = (result * Double.Parse(textDisplay.Text)).ToString();
                    break;
                case "/":
                    textDisplay.Text = (result / Double.Parse(textDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textDisplay.Text);
            labelShowOperator.Text = "";
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            clearHistoryButton.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //textDisplay.Text = "0";
            int length = textDisplay.TextLength - 1;
            string text = textDisplay.Text;
            textDisplay.Clear();
            for (int i = 0; i < length; i++)
            {
                textDisplay.Text = textDisplay.Text + text[i];
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textDisplay.Text = "0";
            result = 0;
        }
    }
}