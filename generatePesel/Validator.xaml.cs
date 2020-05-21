using System;
using System.Windows;
using System.Windows.Media;

namespace generatePesel
{
    public partial class Validator
    {
        public Validator()
        {
            InitializeComponent();
        }

        private int _controlSumGiven;
        private int _controlSum;
        private int _dayInRange;
        private int _monthInRange;
        private string _day;
        private string _month;
        private string _year;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pesel = txbPesel.Text;
                char[] peselChars = pesel.ToCharArray();
                _controlSumGiven = int.Parse(peselChars[10].ToString());
                _controlSum = int.Parse(peselChars[0].ToString()) + int.Parse(peselChars[1].ToString()) * 3 + int.Parse(peselChars[2].ToString()) * 7 + int.Parse(peselChars[3].ToString()) * 9 + int.Parse(peselChars[4].ToString()) + int.Parse(peselChars[5].ToString()) * 3 + int.Parse(peselChars[6].ToString()) * 7 + int.Parse(peselChars[7].ToString()) * 9 + int.Parse(peselChars[8].ToString()) + int.Parse(peselChars[9].ToString()) * 3;
                _controlSum %= 10;
                _controlSum = 10 - _controlSum;
                _controlSum %= 10;
                _day = peselChars[4].ToString() + peselChars[5].ToString();
                _dayInRange = int.Parse(_day);
                _month = peselChars[2].ToString() + peselChars[3].ToString();
                _monthInRange = int.Parse(_month);
                if (_controlSumGiven == _controlSum && (_dayInRange >= 0 && _dayInRange <= 31) && ((_monthInRange < 13 && _monthInRange > 20) || (_monthInRange < 33 && _monthInRange > 40) || (_monthInRange < 53 && _monthInRange > 60) || (_monthInRange < 73 && _monthInRange > 80) || _monthInRange < 93)) //https://www.gov.pl/web/gov/czym-jest-numer-pesel
                {
                    lblPeselStatus.Content = "Pesel validate";
                    lblPeselStatus.Foreground = Brushes.Green;
                    if (int.Parse(peselChars[2].ToString()) == 8 || int.Parse(peselChars[2].ToString()) == 9)
                    {
                        _year = "18";
                        if (peselChars[2] == '8')
                        {
                            peselChars[2] = '0';
                        }
                        else
                            peselChars[2] = '1';
                    }
                    else if (int.Parse(peselChars[2].ToString()) == 0 || int.Parse(peselChars[2].ToString()) == 1)
                    {
                        _year = "19";
                    }
                    else if (int.Parse(peselChars[2].ToString()) == 2 || int.Parse(peselChars[2].ToString()) == 3)
                    {
                        _year = "20";
                        if (peselChars[2] == '2')
                        {
                            peselChars[2] = '0';
                        }
                        else
                            peselChars[2] = '1';
                    }
                    else if (int.Parse(peselChars[2].ToString()) == 4 || int.Parse(peselChars[2].ToString()) == 5)
                    {
                        _year = "21";
                        if (peselChars[2] == '4')
                        {
                            peselChars[2] = '0';
                        }
                        else
                            peselChars[2] = '1';
                    }
                    else if (int.Parse(peselChars[2].ToString()) == 6 || int.Parse(peselChars[2].ToString()) == 7)
                    {
                        _year = "22";
                        if (peselChars[2] == '6')
                        {
                            peselChars[2] = '0';
                        }
                        else
                            peselChars[2] = '1';
                    }
                    _month = peselChars[2].ToString() + peselChars[3].ToString();
                    lblBirthStatus.Content = _day + "." + _month + "." + _year + peselChars[0] + peselChars[1];
                    lblSexStatus.Content = int.Parse(peselChars[9].ToString()) % 2 == 0 ? "Female" : "Male";
                }
                else
                {
                    lblPeselStatus.Content = "Pesel not validate";
                    lblPeselStatus.Foreground = Brushes.Red;
                    lblBirthStatus.Content = "";
                    lblSexStatus.Content = "";
                }
            }
            catch (Exception)
            {
                lblPeselStatus.Content = "Enter a valid value";
                lblPeselStatus.Foreground = Brushes.Red;
            }
        }
    }
}
