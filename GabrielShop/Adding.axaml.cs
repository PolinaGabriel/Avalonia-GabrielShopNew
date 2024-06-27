using Avalonia.Controls;
using System;
using Avalonia.Media.Imaging;
using System.IO;
using Avalonia.Interactivity;
using Avalonia.Input;

namespace GabrielShop;

public partial class Adding : Window
{
    public Adding()
    {
        InitializeComponent();
        this.Show();
    }

    /// <summary>
    /// Ограничение на ввод в блок "на складе"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void EnableRestr(object sender, KeyEventArgs e)
    {
        if (addEnable.Text != "" &&
                (addEnable.Text.Contains("0") == false &&
                addEnable.Text.Contains("1") == false &&
                addEnable.Text.Contains("2") == false &&
                addEnable.Text.Contains("3") == false &&
                addEnable.Text.Contains("4") == false &&
                addEnable.Text.Contains("5") == false &&
                addEnable.Text.Contains("6") == false &&
                addEnable.Text.Contains("7") == false &&
                addEnable.Text.Contains("8") == false &&
                addEnable.Text.Contains("9") == false)
            )
        {
            addEnable.Text = "";
        }
    }

    /// <summary>
    /// Ограничение на ввод в блок "цена"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void PriceRestr(object sender, KeyEventArgs e)
    {
        if (addPrice.Text != "" &&
                (addPrice.Text.Contains(",") == false &&
                addPrice.Text.Contains("0") == false &&
                addPrice.Text.Contains("1") == false &&
                addPrice.Text.Contains("2") == false &&
                addPrice.Text.Contains("3") == false &&
                addPrice.Text.Contains("4") == false &&
                addPrice.Text.Contains("5") == false &&
                addPrice.Text.Contains("6") == false &&
                addPrice.Text.Contains("7") == false &&
                addPrice.Text.Contains("8") == false &&
                addPrice.Text.Contains("9") == false)
            )
        {
            addPrice.Text = "";
        }
    }

    /// <summary>
    /// Добавить товар
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Save(object sender, RoutedEventArgs e)
    {
        int i = 0;
        foreach (Product product in Assortiment.products)
        {
            if (product.name == addName.Text)
            {
                i++;
            }
        }
        if (i == 0 && addName.Text != null && addMan.SelectedIndex != 0 && addEnable.Text != null && addPrice.Text != null && Convert.ToDouble(addPrice.Text) != 0 && addCat.SelectedIndex != 0 && addDescr.Text != null)
        {
            string manufacturer = "";
            switch (addMan.SelectedIndex)
            {
                case 1:
                    manufacturer = "ООО 'Поставщик котов'";
                    break;

                case 2:
                    manufacturer = "ООО 'ААА'";
                    break;

                case 3:
                    manufacturer = "Неизвестен";
                    break;
            }
            Product newProduct = new Product()
            {
                id = Assortiment.products.Count,
                source = addSource.Text,
                image = new Bitmap(addSource.Text),
                name = addName.Text,
                cat = addCat.SelectedIndex,
                descr = addDescr.Text,
                manId = addMan.SelectedIndex,
                man = manufacturer,
                enable = Convert.ToInt32(addEnable.Text),
                price = Convert.ToDouble(addPrice.Text),
                quantity = 0,
                cost = 0
            };
            Assortiment.products.Add(newProduct);
            AdminListWindow adminList = new AdminListWindow();
            adminList.Show();
            this.Close();
        }
        else if (i > 0)
        {
            addEx1.IsVisible = true;
        }
        else
        {
            addEx2.IsVisible = true;
        }
    }

    /// <summary>
    /// Отменить редактирование
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Cancel(object sender, RoutedEventArgs e)
    {
        AdminListWindow AdminList = new AdminListWindow();
        AdminList.Show();
        this.Close();
    }

    /// <summary>
    /// Выбор только определённых расширений
    /// </summary>
    private readonly FileDialogFilter fileFilter = new()
    {
        Extensions = new System.Collections.Generic.List<string>() { "png", "jpg", "jpeg" }
    };

    /// <summary>
    /// Выбор картинки из проводника
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SelectImage(object sender, RoutedEventArgs e)
    {
        //лишние картинки

        try
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(fileFilter);
            var result = await dialog.ShowAsync(this);
            string file = String.Join("", result);
            Random random = new Random();
            string photo = "Asset/photo" + random.Next(1, 10000) + ".jpg";
            File.Copy(file, photo);
            addSource.Text = photo;
            addImage.Source = new Bitmap(file);
        }
        catch { }
    }
}