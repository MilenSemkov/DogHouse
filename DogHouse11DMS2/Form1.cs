using DogHouse11DMS2.Controller;
using DogHouse11DMS2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogHouse11DMS2
{
    public partial class Form1 : Form
    {
        DogsController dogsController = new DogsController();
        BreedController BreedController = new BreedController();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecors(Dog dog)
        {
            txt1.BackColor = Color.White;
            txt1.Text = dog.Id.ToString();
            txt2.Text = dog.Age.ToString();
            txt3.Text = dog.Name;
            cmb1.Text = dog.Breeds.Name;
        }
        private void ClearScreen()
        {
            txt1.BackColor = Color.White;
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            cmb1.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Breed> allBreeds = BreedController.GetAllBreeds();
            cmb1.DataSource = allBreeds;
            cmb1.DisplayMember = "Name";
            cmb1.ValueMember = "ID";

            btn5_Click(sender, e);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt3.Text) || txt3.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txt3.Focus();
                return;
                Dog newDog = new Dog();
                newDog.Age = int.Parse(txt2.Text);
                newDog.Name = txt3.Text;
                newDog.BreedsId = (int)cmb1.SelectedValue;
                dogsController.Create(newDog);
                MessageBox.Show("Записът е успешно добавен!");
                ClearScreen();
                btn5_Click(sender, e);
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            List<Dog> allDogs = dogsController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allDogs)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} - Age: {item.Age}  Breed:{item.Breeds.Name}");
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведеете ID за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Dog findedDog = dogsController.Get(findId);
            if (findedDog == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД\n Въведете ID за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecors(findedDog);


        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведеете ID за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            Dog findedDog = dogsController.Get(findId);
            if (findedDog == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД\n Въведете ID за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            LoadRecors(findedDog);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис №" + findId + " ?", "PROMPT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                dogsController.Delete(findId);

            }
            btn5_Click(sender, e);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txt1.Text) || !txt1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведеете ID за търсене!");
                txt1.BackColor = Color.Red;
                txt1.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txt1.Text);
            }
            if (string.IsNullOrEmpty(txt3.Text))
            {
                Dog findedDog = dogsController.Get(findId);
                if (findedDog == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС В БД\n Въведете ID за търсене!");
                    txt1.BackColor = Color.Red;
                    txt1.Focus();
                    return;
                }
                LoadRecors(findedDog);
            }
            else
            {
                Dog updateDog = new Dog();
                updateDog.Name = txt3.Text;
                updateDog.Age = int.Parse(txt2.Text);
                updateDog.BreedsId = (int)cmb1.SelectedValue;

                dogsController.Update(findId, updateDog);
            }
            btn5_Click(sender, e);

        }

    }
}
