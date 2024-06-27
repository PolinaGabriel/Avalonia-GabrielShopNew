using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GabrielShop;

public partial class UserListWindow : Window
{ 
    public List<Product> searchProducts = new List<Product>(); //для поиска
    public List<Product> selectProducts = new List<Product>(); //для сортировки
    public int roleChosen; //роль (покупатель или гость)

    public UserListWindow()
    {
        InitializeComponent();
        sortPrice.ItemsSource = new List<string>() { "Цена", "По возрастанию", "По убыванию" };
        sortPrice.SelectedIndex = 0;
        sortCat.ItemsSource = new List<string>() { "Категории", "Коты", "Не коты" };
        sortCat.SelectedIndex = 0;
        sortMan.ItemsSource = new List<string>() { "Производители", "OOO 'Поставщик котов'", "OOO 'ААА'", "Неизвестен" };
        sortMan.SelectedIndex = 0;
        shopList.ItemsSource = Assortiment.products.ToList();
        number.Text = "Показано товаров: " + shopList.Items.Count() + " из " + Assortiment.products.Count();
        this.Show();
    }

    /// <summary>
    /// Отметка: пользователь или гость
    /// </summary>
    /// <param name="role">роль</param>
    public void ChoseRole(int role)
    {
        roleChosen = role;
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
        
        if (request.Text != "" && request.Text != null)
        {
            string[] requests = request.Text.Split(' ');
            searchProducts.Clear();
            foreach (Product product in shopList.Items)
            {
                foreach (string r in requests)
                {
                    if (product.name.ToLower().Contains(r.ToLower()) == true ||
                        product.descr.ToLower().Contains(r.ToLower()) == true ||
                        product.man.ToLower().Contains(r.ToLower()) == true ||
                        Convert.ToString(product.price).ToLower().Contains(r.ToLower()) == true ||
                        Convert.ToString(product.enable).ToLower().Contains(r.ToLower()) == true)
                    {
                        searchProducts.Add(product);
                    }
                }

            }
            shopList.ItemsSource = searchProducts.ToList();
        }
        else
        {
            shopList.ItemsSource = selectProducts.ToList();
        }
        number.Text = "Показано товаров: " + shopList.Items.Count() + " из " + Assortiment.products.Count();
    }

    /// <summary>
    /// Фильтры и сортировка по цене
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Selection(object sender, SelectionChangedEventArgs e)
    {
        selectProducts.Clear();
        //Категории и производители:
        if (sortCat.SelectedIndex != 0 && sortMan.SelectedIndex == 0)
        {
            foreach (Product product in Assortiment.products)
            {
                if (product.cat == sortCat.SelectedIndex)
                {
                    selectProducts.Add(product);
                }
            }
        }
        else if (sortCat.SelectedIndex == 0 && sortMan.SelectedIndex != 0)
        {
            foreach (Product product in Assortiment.products)
            {
                if (product.manId == sortMan.SelectedIndex)
                {
                    selectProducts.Add(product);
                }
            }
        }
        else if (sortCat.SelectedIndex != 0 && sortMan.SelectedIndex != 0)
        {
            foreach (Product product in Assortiment.products)
            {
                if (product.cat == sortCat.SelectedIndex && product.manId == sortMan.SelectedIndex)
                {
                    selectProducts.Add(product);
                }
            }
        }
        else
        {
            selectProducts = Assortiment.products.ToList();
        }
        shopList.ItemsSource = selectProducts.ToList();
        //Сортировка по цене:
        if (sortPrice.SelectedIndex == 1) //возрастание
        {
            selectProducts.Clear();
            foreach (Product product in shopList.Items)
            {
                selectProducts.Add(product);
            }
            for (int i = 0; i < selectProducts.Count; i++)
            {
                for (int j = 0; j < selectProducts.Count - 1 - i; j++)
                {
                    if (selectProducts[j].price > selectProducts[j + 1].price)
                    {
                        Product swap = selectProducts[j];
                        selectProducts[j] = selectProducts[j + 1];
                        selectProducts[j + 1] = swap;
                    }
                }
            }
        }
        else if (sortPrice.SelectedIndex == 2) //убывание
        {
            selectProducts.Clear();
            foreach (Product product in shopList.Items)
            {
                selectProducts.Add(product);
            }
            for (int i = 0; i < selectProducts.Count; i++)
            {
                for (int j = 0; j < selectProducts.Count - 1 - i; j++)
                {
                    if (selectProducts[j].price < selectProducts[j + 1].price)
                    {
                        Product swap = selectProducts[j];
                        selectProducts[j] = selectProducts[j + 1];
                        selectProducts[j + 1] = swap;
                    }
                }
            } 
        }
        shopList.ItemsSource = selectProducts.ToList();
        Searching();
    }

    /// <summary>
    /// Оформить заказ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void MakeOrder(object sender, RoutedEventArgs e)
    {
        if (roleChosen == 2)
        {
            for (int i = 0; i < Assortiment.products.Count(); i++)
            {
                foreach (Product item in shopList.SelectedItems)
                {
                    if (Assortiment.products[i].name == item.name && Assortiment.products[i].enable > 0)
                    {
                        Assortiment.order.Add(Assortiment.products[i]);
                        Assortiment.products.Remove(Assortiment.products[i]);
                    }
                }
            }
            if (Assortiment.order.Count != 0)
            {
                UserCartWindow UserCart = new UserCartWindow();
                UserCart.OrderList();
                this.Close();
            }
        }
        else
        {
            errorText.IsVisible = true;
        }
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