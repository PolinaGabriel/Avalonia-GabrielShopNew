using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GabrielShop;

public partial class AdminListWindow : Window
{
    public List<Product> searchProductsA = new List<Product>(); //для поиска
    public List<Product> selectProductsA = new List<Product>(); //для сортировки

    public AdminListWindow()
    {
        InitializeComponent();
        sortPriceA.ItemsSource = new List<string>() { "Цена", "По возрастанию", "По убыванию" };
        sortPriceA.SelectedIndex = 0;
        sortCatA.ItemsSource = new List<string>() { "Категории", "Коты", "Не коты" };
        sortCatA.SelectedIndex = 0;
        sortManA.ItemsSource = new List<string>() { "Производители", "OOO 'Поставщик котов'", "OOO 'ААА'", "Неизвестен" };
        sortManA.SelectedIndex = 0;
        selectProductsA = Assortiment.products.ToList();
        admShopList.ItemsSource = selectProductsA.ToList();
        numberA.Text = "Показано товаров: " + admShopList.Items.Count() + " из " + Assortiment.products.Count();
        this.Show();
    }

    /// <summary>
    /// Измененить товар
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ModifyProduct(object sender, SelectionChangedEventArgs e)
    {
        RedactWindow Redact = new RedactWindow();
        foreach (Product product in admShopList.ItemsSource)
        {
            if (product == admShopList.SelectedItem)
            {
                Redact.Redacting(Assortiment.products[product.id]);
                this.Close();
            }
        } 
    }

    /// <summary>
    /// Удалить товар
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DeleteProduct(object sender, RoutedEventArgs e)
    {
        Assortiment.products.Remove(Assortiment.products[selectProductsA[(int)(sender as Button).Tag].id]);
        selectProductsA.Remove(selectProductsA[(int)(sender as Button).Tag]);
        admShopList.ItemsSource = selectProductsA.ToList();
        numberA.Text = "Показано товаров: " + admShopList.Items.Count() + " из " + Assortiment.products.Count();
    }

    /// <summary>
    /// Поиск по товарам
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Search(object sender, KeyEventArgs e)
    {
        Searching();
    }

    public void Searching()
    {
        //после удаления проблемы

        if (requestA.Text != "" && requestA.Text != null)
        {
            string[] requests = requestA.Text.Split(' ');
            searchProductsA.Clear();
            foreach (Product product in admShopList.Items)
            {
                foreach (string r in requests)
                {
                    if (product.name.ToLower().Contains(r.ToLower()) == true ||
                        product.descr.ToLower().Contains(r.ToLower()) == true ||
                        product.man.ToLower().Contains(r.ToLower()) == true ||
                        Convert.ToString(product.price).ToLower().Contains(r.ToLower()) == true ||
                        Convert.ToString(product.enable).ToLower().Contains(r.ToLower()) == true)
                    {
                        searchProductsA.Add(product);
                    }
                }
            }
            admShopList.ItemsSource = searchProductsA.ToList();
        }
        else
        {
            admShopList.ItemsSource = selectProductsA.ToList();
        }
        numberA.Text = "Показано товаров: " + admShopList.Items.Count() + " из " + Assortiment.products.Count();
    }

    /// <summary>
    /// Фильтры и сортировка по цене
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Selection(object sender, SelectionChangedEventArgs e)
    {
        selectProductsA.Clear();
        //Категории и производители:
        if (sortCatA.SelectedIndex != 0 && sortManA.SelectedIndex == 0)
        {
            foreach (Product product in Assortiment.products)
            {
                if (product.cat == sortCatA.SelectedIndex)
                {
                    selectProductsA.Add(product);
                }
            }
        }
        else if (sortCatA.SelectedIndex == 0 && sortManA.SelectedIndex != 0)
        {
            foreach (Product product in Assortiment.products)
            {
                if (product.manId == sortManA.SelectedIndex)
                {
                    selectProductsA.Add(product);
                }
            }
        }
        else if (sortCatA.SelectedIndex != 0 && sortManA.SelectedIndex != 0)
        {
            foreach (Product product in Assortiment.products)
            {
                if (product.cat == sortCatA.SelectedIndex && product.manId == sortManA.SelectedIndex)
                {
                    selectProductsA.Add(product);
                }
            }
        }
        else
        {
            selectProductsA = Assortiment.products.ToList();
        }
        admShopList.ItemsSource = selectProductsA.ToList();
        //Сортировка по цене:
        if (sortPriceA.SelectedIndex == 1) //возрастание
        {
            selectProductsA.Clear();
            foreach (Product product in admShopList.Items)
            {
                selectProductsA.Add(product);
            }
            for (int i = 0; i < selectProductsA.Count; i++)
            {
                for (int j = 0; j < selectProductsA.Count - 1 - i; j++)
                {
                    if (selectProductsA[j].price > selectProductsA[j + 1].price)
                    {
                        Product swap = selectProductsA[j];
                        selectProductsA[j] = selectProductsA[j + 1];
                        selectProductsA[j + 1] = swap;
                    }
                }
            }
        }
        else if (sortPriceA.SelectedIndex == 2) //убывание
        {
            selectProductsA.Clear();
            foreach (Product product in admShopList.Items)
            {
                selectProductsA.Add(product);
            }
            for (int i = 0; i < selectProductsA.Count; i++)
            {
                for (int j = 0; j < selectProductsA.Count - 1 - i; j++)
                {
                    if (selectProductsA[j].price < selectProductsA[j + 1].price)
                    {
                        Product swap = selectProductsA[j];
                        selectProductsA[j] = selectProductsA[j + 1];
                        selectProductsA[j + 1] = swap;
                    }
                }
            }
        }
        admShopList.ItemsSource = selectProductsA.ToList();
        Searching();
    }

    /// <summary>
    /// Добавить товар
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AddProduct(object sender, RoutedEventArgs e)
    {
        Adding Adding = new Adding();
        this.Close();
    }

    /// <summary>
    /// Сменить пользователя
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ChangeUser(object sender, RoutedEventArgs e)
    {
        MainWindow MainWindow = new MainWindow();
        MainWindow.Show();
        this.Close();
    }
}