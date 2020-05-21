using System;
using System.Windows;

namespace generatePesel
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Male_Checked(object sender, RoutedEventArgs e)
        {
            if(chbMale.IsChecked == true)
            {
                chbFemale.IsChecked = false;
            }
        }

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
            if (chbFemale.IsChecked == true)
            {
                chbMale.IsChecked = false;
            }
        }

        private string _year, _month, _day, _birthDate, _wholeYear;
        private int _checkSum, _randSexDigit;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(chbFemale.IsChecked == true || chbMale.IsChecked == true)
            {
                try
                {
                    int[] pesel = new int[11];
                    if (dataPicker.SelectedDate != null)
                        _birthDate =
                            dataPicker.SelectedDate.Value.Date
                                .ToShortDateString(); //birthDate for example is 09.03.2020
                    _wholeYear = _birthDate[6] + _birthDate[7].ToString() + _birthDate[8] + _birthDate[9]; //this is needed for if statement
                    pesel[0] = int.Parse(_wholeYear[2].ToString());
                    pesel[1] = int.Parse(_wholeYear[3].ToString());
                    _year = pesel[0] + pesel[1].ToString();
                    pesel[2] = int.Parse(_birthDate[3].ToString());
                    pesel[3] = int.Parse(_birthDate[4].ToString());
                    pesel[4] = int.Parse(_birthDate[0].ToString());
                    pesel[5] = int.Parse(_birthDate[1].ToString());
                    _day = pesel[4] + pesel[5].ToString();
                    _month = pesel[2] + pesel[3].ToString();
                    if (int.Parse(_wholeYear) >= 2000 && int.Parse(_wholeYear) <= 2099)
                    {
                        pesel[2] += 2;
                        _month = pesel[2] + pesel[3].ToString();
                    }
                    else if (int.Parse(_wholeYear) >= 1800 && int.Parse(_wholeYear) <= 1899)
                    {
                        pesel[2] += 8;
                        _month = pesel[2] + pesel[3].ToString();
                    }
                    else if (int.Parse(_wholeYear) >= 2100 && int.Parse(_wholeYear) <= 2199)
                    {
                        pesel[2] += 4;
                        _month = pesel[2] + pesel[3].ToString();

                    }
                    else if (int.Parse(_wholeYear) >= 2200 && int.Parse(_wholeYear) <= 2299)
                    {
                        pesel[2] += 6;
                        _month = pesel[2] + pesel[3].ToString();

                    }

                    var random = new Random();
                    
                    var randCheckDigits = random.Next(0, 10).ToString();
                    pesel[6] = int.Parse(randCheckDigits);
                    randCheckDigits = random.Next(0, 10).ToString();
                    pesel[7] = int.Parse(randCheckDigits);
                    randCheckDigits = random.Next(0, 10).ToString();
                    pesel[8] = int.Parse(randCheckDigits);
                    randCheckDigits = pesel[6].ToString() + pesel[7] + pesel[8];
                    _randSexDigit = random.Next(0, 5);
                    if (chbFemale.IsChecked == true)
                    {
                        _randSexDigit *= 2;
                        pesel[9] = _randSexDigit;
                        //1-3-7-9-1-3-7-9-1-3
                        _checkSum = pesel[0] + pesel[1] * 3 + pesel[2] * 7 + pesel[3] * 9 + pesel[4] + pesel[5] * 3 + pesel[6] * 7 + pesel[7] * 9 + pesel[8] + pesel[9] * 3;
                        _checkSum %= 10;
                        _checkSum = 10 - _checkSum;
                        _checkSum %= 10;

                        lblGeneratedPesel.Content = _year + _month + _day + randCheckDigits + _randSexDigit + _checkSum;
                    }
                    else
                    {
                        _randSexDigit = _randSexDigit * 2 + 1;
                        pesel[9] = _randSexDigit;
                        //1-3-7-9-1-3-7-9-1-3
                        _checkSum = pesel[0] + pesel[1] * 3 + pesel[2] * 7 + pesel[3] * 9 + pesel[4] + pesel[5] * 3 + pesel[6] * 7 + pesel[7] * 9 + pesel[8] + pesel[9] * 3;
                        _checkSum %= 10;
                        _checkSum = 10 - _checkSum;
                        _checkSum %= 10;

                        lblGeneratedPesel.Content = _year + _month + _day + randCheckDigits + _randSexDigit + _checkSum;
                    }
                        
                }
                catch (Exception)
                {
                    lblGeneratedPesel.Content = "Pick a datetime";
                }
           
            }
            else
                lblGeneratedPesel.Content = "Pick a gender";

        }
    }
}