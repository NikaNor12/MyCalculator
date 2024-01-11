using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G19_20240110
{
    internal class MathOperations
    {
        private double currentNumber = 0;
        string currentOperation;

        public void AttachButtonClickHandlers(Form form, TextBox textBox)
        {
            foreach (Control control in form.Controls)
            {
                if (control is Button button) 
                {
                    button.Click += (sender, e) => UpdateTextBox(button.Text, textBox);
                }
            }
        }

        public double Calculate(double firstNumber, double secondNumber, string operation)
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "×":
                    return firstNumber * secondNumber;
                case "÷":
                    return firstNumber / secondNumber;
                default:
                    return -1;
            }
        }

        private void UpdateTextBox(string buttonText, TextBox textBox)
        {

            switch (buttonText)
            {
                case "+":
                case "-":
                case "×":
                case "÷":
                    currentNumber = double.Parse(textBox.Text);
                    currentOperation = buttonText;
                    textBox.Text = "";
                    break;

                case "=":
                    if (!string.IsNullOrEmpty(currentOperation))
                    {
                        double secondNumber = double.Parse(textBox.Text);
                        double result = Calculate(currentNumber, secondNumber, currentOperation);
                        textBox.Text = result.ToString();
                        currentOperation = "";
                    }
                    break;

                case "C":
                    textBox.Text = "";
                    currentNumber = 0;
                    currentOperation = "";
                    break;

                case "Del":

                    if (textBox.Text.Length > 0)
                    {
                        textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                    }
                    break;

                default:
                    textBox.Text += buttonText;
                    break;
            }
        }
    }
}
