using Lab3.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BrandsList brandList = new BrandsList();
        public MainWindow()
        {
            InitializeComponent();
            ChooseBrand.Items.Add(new Audi());
            ChooseBrand.Items.Add(new BMW());
            ChooseBrand.Items.Add(new Mazda());
            ChooseBrand.Items.Add(new Volvo());
            ChooseBrand.Items.Add(new Toyota());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type type = ChooseBrand.SelectedItem.GetType();
            AutoBrands l = (AutoBrands)Activator.CreateInstance(type);
            if (l != null)
            {
                l.BrandName = AddBrandName.Text;
                l.YearOfCreation = Convert.ToInt32(AddYearOfCreation.Text);
                l.Country = Country.Text;
            }
            brandList.Add(t);
            ShowBrands.Items.Clear();
            foreach (AutoBrands brand in brandList)
                ShowBrands.Items.Add(brand.ShowInfo());
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializator s = new JsonSerializator();
            File.WriteAllText(FileToSerialize.Text, s.Serialize(langerstList));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            brandList.Remove(brandList.Get(ShowBrands.SelectedIndex));
            ShowBrands.Items.Clear();
            foreach (AutoBrands brand in brandList)
                 ShowBrands.Items.Add(brand.ShowInfo());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AutoBrands l = brandList.Get(ShowBrands.SelectedIndex);
            l.BrandName = EditLanguagename.Text;
            l.YearOfCreation = Convert.ToInt32(EditYearOfCreation.Text);
            l.Country = EditCountry.Text;
            ShowLanguages.Items.Clear();
            foreach (AutoBrands brand in brandList)
                ShowBrands.Items.Add(brand.ShowInfo());
        }

        private void Deserialize_Click(object sender, RoutedEventArgs e)
        {
            JsonSerializator s = new JsonSerializator();
            BrandsList tmp = s.Deserialize(File.ReadAllText(FileToDeserialize.Text));
            foreach (AutoBrands brand in tmp)
                =brandList.Add(brand);
            ShowBrands.Items.Clear();
            foreach (AutoBrands brand in brandList)
                ShowBrands.Items.Add(brand.ShowInfo());
        }
    }
}
