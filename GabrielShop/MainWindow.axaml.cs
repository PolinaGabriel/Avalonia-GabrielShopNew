using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GabrielShop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// ¬ход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenShop(object sender, RoutedEventArgs e)
        {
            int i = -1;
            int j = 0;
            foreach (User u in Group.users)
            {
                i++;
                if (login.Text == u.log)
                {
                    j++;
                    break;
                }
            }
            if (j == 0)
            {
                loginError.IsVisible = true;
            }
            else
            {
                if (password.Text == Group.users[i].pass)
                {
                    switch (Group.users[i].role)
                    {
                        case 1:
                            AdminListWindow AdminList = new AdminListWindow();
                            this.Close();
                            break;

                        case 2:
                            UserListWindow UserList = new UserListWindow();
                            UserList.ChoseRole(Group.users[i].role);
                            this.Close();
                            break;
                    }    
                }
                else
                {
                    passwordError.IsVisible = true;
                }
            }    
        }

        /// <summary>
        /// ¬ход в режиме гост€
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenShopGuest(object sender, RoutedEventArgs e)
        {
            UserListWindow UserList = new UserListWindow();
            UserList.ChoseRole(0);
            this.Close();
        }
    }
}