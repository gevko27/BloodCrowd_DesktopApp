using Interface.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Interface
{
    public partial class AddDonatorForm : Form
    {
        public AddDonatorForm()
        {
            InitializeComponent();

            //Conteudo da comboBox do sexo
            genreComboBox.Items.Add("male");
            genreComboBox.Items.Add("female");
            genreComboBox.SelectedIndex = 1;

            //Conteudo da comboBox do grupo sanguíneo
            bloodTypeComboBox.Items.Add("A+");
            bloodTypeComboBox.Items.Add("A-");
            bloodTypeComboBox.Items.Add("B+");
            bloodTypeComboBox.Items.Add("B-");
            bloodTypeComboBox.Items.Add("AB+");
            bloodTypeComboBox.Items.Add("AB-");
            bloodTypeComboBox.Items.Add("O+");
            bloodTypeComboBox.Items.Add("O-");
            bloodTypeComboBox.SelectedIndex = 0;




        }

        private void AddDonatorForm_Load(object sender, EventArgs e)
        {
            firstNameTextBox.Text = "João";
            lastNameTextBox.Text = "Ferreira";
            genreComboBox.SelectedIndex = 1;
            streetAddressTextBox.Text = "Rua Principal 39";
            cityTextBox.Text = "Alcobaça";
            stateFullTextBox.Text = "Leiria";
            zipCodeTextBox.Text = "2460-611";
            emailTextBox.Text = "jfa@gmail.com";
            userNameTextBox.Text = "Jferr";
            telephoneTextBox.Text = "927068903";
            mothersMaidenTextBox.Text = "Santos";
            occupationTextBox.Text = "Operador fabril";
            companyTextBox.Text = "Frubaça";
            vehicleTextBox.Text = "BMW 320d";
            kilogramsTextBox.Text = "92,5";
            centimetersTextBox.Text = "170,5";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void birthdayDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void telephoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void genreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void AddDonatorButton_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            Donator d1 = new Donator();
            bool resultadoint = int.TryParse(telephoneTextBox.Text, out var n);
            bool resultadodouble = double.TryParse(kilogramsTextBox.Text, out var p);
            bool resultaddouble2 = double.TryParse(centimetersTextBox.Text, out var l);



            string especiais = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            //validar campos preenchidos

            if (genreComboBox.Text == String.Empty || firstNameTextBox.Text == String.Empty || lastNameTextBox.Text == String.Empty ||
                streetAddressTextBox.Text == String.Empty || cityTextBox.Text == String.Empty || stateFullTextBox.Text == String.Empty ||
                zipCodeTextBox.Text == String.Empty || emailTextBox.Text == String.Empty || userNameTextBox.Text == String.Empty ||
                telephoneTextBox.Text == String.Empty || mothersMaidenTextBox.Text == String.Empty || occupationTextBox.Text == String.Empty ||
                companyTextBox.Text == String.Empty || vehicleTextBox.Text == String.Empty || kilogramsTextBox.Text == String.Empty ||
                 centimetersTextBox.Text == String.Empty || resultadoint == false || resultaddouble2 == false || resultadodouble == false||
                !Regex.IsMatch(firstNameTextBox.Text, @"^[\sa-zA-Z" + especiais+"]*$" ) || !Regex.IsMatch(lastNameTextBox.Text, @"^[\sa-zA-Z" + especiais + "]*$") || 
               !Regex.IsMatch(cityTextBox.Text, @"^[\sa-zA-Z" + especiais + "]*$") || !Regex.IsMatch(stateFullLabel.Text, @"^[\sa-zA-Z" + especiais + "]*$") || !Regex.IsMatch(mothersMaidenTextBox.Text, @"^[\sa-zA-Z" + especiais + "]*$")  ||
               !Regex.IsMatch(occupationTextBox.Text, @"^[\sa-zA-Z" + especiais + "]*$") || !Regex.IsMatch(companyTextBox.Text, @"^[\sa-zA-Z" + especiais + "]*$")||
               !Regex.IsMatch(streetAddressTextBox.Text, @"^[\sa-zA-Z" + especiais + "0-9]*$"))
            {
                MessageBox.Show("Fill all the fields correctly!");
            }
            else
            {

                d1.Sexo = genreComboBox.SelectedItem.ToString();
                d1.FirstName = firstNameTextBox.Text;
                d1.LastName = lastNameTextBox.Text;
                d1.StreetAddress = streetAddressTextBox.Text;
                d1.City = cityTextBox.Text;
                d1.Statefull = stateFullTextBox.Text;
                d1.ZipCode = zipCodeTextBox.Text;
                d1.EMail = emailTextBox.Text;
                d1.UserName = userNameTextBox.Text;
                d1.TelephoneNumber = Convert.ToInt64(telephoneTextBox.Text);
                d1.MothersMaiden = mothersMaidenTextBox.Text;
                String birthday = birthDaydateTimePicker.Text;
                d1.Occupation = occupationTextBox.Text;
                d1.Company = companyTextBox.Text;
                d1.Vehicle = vehicleTextBox.Text;
                d1.BloodType = bloodTypeComboBox.SelectedItem.ToString();
                d1.Kilograms = Convert.ToDouble(kilogramsTextBox.Text)*10;
                d1.Centimeters = Convert.ToDouble(centimetersTextBox.Text);
                d1.Password = "";
                d1.Guid = "";
                d1.Latitude = "";

                d1.Longitude = "";

                //calcular idade
                var hoje = DateTime.Today;

                String[] bday = birthday.Split(' ');
                int bd = Convert.ToInt32(bday[4]);

                int idade = hoje.Year - bd;
                d1.Age = idade;

                //colocar bem a data
                //  1 / 10 / 1953
                int b;
                String dn = "";
                String[] meses = { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };
                for (int k = 0; k < meses.Count(); k++)
                {
                    if (bday[2].Equals(meses[k]))
                    {
                        b = k + 1;
                        dn = b + "/" + bday[0] + "/" + bday[4];
                    }


                }
                d1.BirthDay = dn;



                client.AddNewDonator(d1);
                client.Close();
                 this.Close();

            }
            }

        private void bloodTypeLabel_Click(object sender, EventArgs e)
        {

        }
    }
    }
