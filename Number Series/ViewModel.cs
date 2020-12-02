//Mrinal Bedi
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Number_Series
{
    class ViewModel : INotifyPropertyChanged
    {

        #region Properties

        const int MAX_VALUE = 10;

        const int ITERATION_MAX_VALUE = 100;


        String content = string.Empty;

        private double firstNumber;
        public double FirstNumber { get { return firstNumber; } set { firstNumber = value; changed(); } }

        private double secondNumber;
        public double SecondNumber { get { return secondNumber; } set { secondNumber = value; changed(); } }

        private double thirdNumber;
        public double ThirdNumber { get { return thirdNumber; } set { thirdNumber = value; changed(); } }

        private double iterations;
        public double Iterations { get { return iterations; } set { iterations = value; changed(); } }

        public ObservableCollection<string> Output { get; set; } = new ObservableCollection<string>();


        public void Evaluate()
        {
            try
            {
                double answer = 0;
                if (FirstNumber < MAX_VALUE && SecondNumber < MAX_VALUE && ThirdNumber < MAX_VALUE && Iterations < ITERATION_MAX_VALUE)
                {
                    Output.Add(FirstNumber.ToString());
                    Output.Add(SecondNumber.ToString());
                    Output.Add(ThirdNumber.ToString());
                    content += "Initial choices: " + FirstNumber.ToString() + "\n" + SecondNumber.ToString() + "\n" + ThirdNumber.ToString() + "\n" +
                        "Iterations: " + Iterations + "\n" + "\t" + "Final sequence: ";

                    for (int i = 0; i < Iterations; i++)
                    {
                        answer = firstNumber * secondNumber - thirdNumber;
                        Output.Add(answer.ToString());

                        firstNumber = secondNumber;
                        secondNumber = thirdNumber;
                        thirdNumber = answer;
                    }

                    foreach (var item in Output)
                        content += "\n" + item;
                }
                else
                {
                    Output.Add("Please enter values within the specified range only");
                }
            }
            catch (Exception)
            {
                Output.Add("Some error occurred");
            }
        }

        public void clear()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            ThirdNumber = 0;
            Iterations = 0;
            Output.Clear();
        }


        public void SaveFileDialog()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text Files(*.txt)|*.txt|All(*.*)|*";
            if (fileDialog.ShowDialog() == true)
            {
                File.AppendAllText(fileDialog.FileName, content);
            }
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void changed([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
