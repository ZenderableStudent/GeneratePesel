using System;
using System.Windows;
using System.Windows.Media;

namespace generatePesel
{
    public partial class Verifier
    {
        public Verifier()
        {
            InitializeComponent();
        }

        private String chosenSex;
        private void Male_Checked(object sender, RoutedEventArgs e)
        {
            if (chbMale.IsChecked == true)
            {
                chbFemale.IsChecked = false;
                chosenSex = "Male";
            }
        }

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
            if (chbFemale.IsChecked == true)
            {
                chbMale.IsChecked = false;
                chosenSex = "Female";
            }
        }

        private string _birthDate;
        private string _givenBirthDate;
        private int _controlSumGiven;
        private int _controlSum;
        private int _dayInRange;
        private int _monthInRange;
        private string _day;
        private string _month;
        private string _year;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (chbFemale.IsChecked == true || chbMale.IsChecked == true)
            {
                if (dataPicker.SelectedDate != null)
                {
                    _birthDate =
                        dataPicker.SelectedDate.Value.Date
                            .ToShortDateString();
                    //birthDate for example is 09.03.2020
                    try
                    {
                        string pesel = txbYourPesel.Text;
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
                            lblPeselStatus.Content = "Pesel is valid";
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
                            _givenBirthDate = _day + "." + _month + "." + _year + peselChars[0] + peselChars[1];
                            if (chosenSex == "Female" && int.Parse(peselChars[9].ToString()) % 2 == 0)
                            {
                                lblGenderStatus.Content = "Gender is valid";
                                lblGenderStatus.Foreground = Brushes.Green;
                                if (_birthDate == _givenBirthDate)
                                {
                                    lblBirtDateStatus.Content = "Birth date is valid";
                                    lblBirtDateStatus.Foreground = Brushes.Green;
                                    lblVerifyStatus.Content = "Data match";
                                    lblVerifyStatus.Foreground = Brushes.Green;
                                }
                                else
                                {
                                    lblBirtDateStatus.Content = "Birth date is not valid";
                                    lblBirtDateStatus.Foreground = Brushes.Red;
                                    lblVerifyStatus.Content = "Data do not match";
                                    lblVerifyStatus.Foreground = Brushes.Red;
                                }
                            }
                            else if (chosenSex == "Male" && int.Parse(peselChars[9].ToString()) % 2 != 0)
                            {
                                lblGenderStatus.Content = "Gender is valid";
                                lblGenderStatus.Foreground = Brushes.Green;
                                if (_birthDate == _givenBirthDate)
                                {
                                    lblBirtDateStatus.Content = "Birth date is valid";
                                    lblBirtDateStatus.Foreground = Brushes.Green;
                                    lblVerifyStatus.Content = "Data match";
                                    lblVerifyStatus.Foreground = Brushes.Green;
                                }
                                else
                                {
                                    lblBirtDateStatus.Content = "Birth date is not valid";
                                    lblBirtDateStatus.Foreground = Brushes.Red;
                                    lblVerifyStatus.Content = "Data do not match";
                                    lblVerifyStatus.Foreground = Brushes.Red;
                                }
                            }
                            else
                            {
                                if (_birthDate == _givenBirthDate)
                                {
                                    lblBirtDateStatus.Content = "Birth date is valid";
                                    lblBirtDateStatus.Foreground = Brushes.Green;
                                }
                                else
                                {
                                    lblBirtDateStatus.Content = "Birth date is not valid";
                                    lblBirtDateStatus.Foreground = Brushes.Red;
                                }
                                lblGenderStatus.Content = "Gender is not valid";
                                lblGenderStatus.Foreground = Brushes.Red;
                                lblVerifyStatus.Content = "Data do not match";
                                lblVerifyStatus.Foreground = Brushes.Red;
                            }
                        }
                        else
                        {
                            lblPeselStatus.Content = "";
                            lblGenderStatus.Content = "";
                            lblBirtDateStatus.Content = "";
                            lblPeselStatus.Content = "Pesel is not valid";
                            lblPeselStatus.Foreground = Brushes.Red;
                            lblVerifyStatus.Content = "Data do not match";
                            lblVerifyStatus.Foreground = Brushes.Red;
                        }
                    }
                    catch (Exception)
                    {
                        lblPeselStatus.Content = "";
                        lblGenderStatus.Content = "";
                        lblBirtDateStatus.Content = "";
                        lblVerifyStatus.Content = "Enter a valid value";
                        lblVerifyStatus.Foreground = Brushes.Red;
                    }
                }
                else
                {
                    lblPeselStatus.Content = "";
                    lblGenderStatus.Content = "";
                    lblBirtDateStatus.Content = "";
                    lblVerifyStatus.Content = "Pick a datetime";
                    lblVerifyStatus.Foreground = Brushes.Red;
                }
            }
            else
            {
                lblPeselStatus.Content = "";
                lblGenderStatus.Content = "";
                lblBirtDateStatus.Content = "";
                lblVerifyStatus.Content = "Pick a gender";
                lblVerifyStatus.Foreground = Brushes.Red;
            }
        }
    }
}