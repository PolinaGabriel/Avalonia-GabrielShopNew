using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace GabrielShop;

public partial class UserCartWindow : Window
{    
    public UserCartWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Заполнение списка покупок
    /// </summary>
    /// <param name="productsChosen">выбранные для покупки товары</param>
    public void OrderList()
    {
        foreach (Product product in Assortiment.order)
        {
            product.id = Assortiment.order.IndexOf(product);
        }
        orderListBox.ItemsSource = Assortiment.order.ToList();
        this.Show();
    }

    /// <summary>
    /// Добавить в корзину
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void AddToCart(object sender, RoutedEventArgs e)
    {
        if (Assortiment.order[(int)(sender as Button).Tag].quantity < Assortiment.order[(int)(sender as Button).Tag].enable)
        {
            Assortiment.order[(int)(sender as Button).Tag].quantity++;
            Assortiment.order[(int)(sender as Button).Tag].cost = Assortiment.order[(int)(sender as Button).Tag].price * Assortiment.order[(int)(sender as Button).Tag].quantity;
           orderListBox.ItemsSource = Assortiment.order.ToList();
        }
    }

    /// <summary>
    /// Удалить из корзины
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DeleteFromCart(object sender, RoutedEventArgs e)
    {
        if (Assortiment.order[(int)(sender as Button).Tag].quantity != 0)
        {
            Assortiment.order[(int)(sender as Button).Tag].quantity--;
            Assortiment.order[(int)(sender as Button).Tag].cost = Assortiment.order[(int)(sender as Button).Tag].price * Assortiment.order[(int)(sender as Button).Tag].quantity;
            orderListBox.ItemsSource = Assortiment.order.ToList();
        }
    }

    /// <summary>
    /// Вернуться к списку покупок
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void GoToList(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < Assortiment.order.Count(); i++)
        {
            if (Assortiment.order[i].quantity == 0)
            {
                Assortiment.products.Add(Assortiment.order[i]);
                Assortiment.order.Remove(Assortiment.order[i]);
            }
        }
        UserListWindow UserList = new UserListWindow();
        UserList.ChoseRole(2);
        UserList.Show();
        this.Close();
    }

    /// <summary>
    /// Сменить пользователя
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ChangeUser(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < Assortiment.order.Count(); i++)
        {
            Assortiment.order[i].enable -= Assortiment.order[i].quantity;
            Assortiment.products.Add(Assortiment.order[i]);
            Assortiment.order.Remove(Assortiment.order[i]);
        }
        MainWindow MainWindow = new MainWindow();
        MainWindow.Show();
        this.Close();
    }
}