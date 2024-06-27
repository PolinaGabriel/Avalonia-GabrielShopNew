using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.IO;

namespace GabrielShop;

public partial class RedactWindow : Window
{
    Product redProduct;
    
    public RedactWindow()
    {
        InitializeComponent();
        this.Show();
    }

    /// <summary>
    /// ���� ��������������
    /// </summary>
    /// <param name="product">�����</param>
    /// <param name="i">������ ������</param>
    public void Redacting(Product product)
    {
        redImage.Source = product.image;
        redSource.Text = product.source;
        redName.Watermark = product.name;
        redCat.SelectedIndex = product.cat;
        redDescr.Watermark = product.descr;
        redMan.SelectedIndex = product.manId;
        redEnable.Watermark = Convert.ToString(product.enable);
        redPrice.Watermark = Convert.ToString(product.price);
        redProduct = product;
    }

    /// <summary>
    /// ����� ������ ����������� ����������
    /// </summary>
    private readonly FileDialogFilter fileFilter = new()
    {
        Extensions = new System.Collections.Generic.List<string>() { "png", "jpg", "jpeg" }
    };

    /// <summary>
    /// ����� �������� �� ����������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SelectImage(object sender, RoutedEventArgs e)
    {
        //������ ��������

        try
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(fileFilter);
            var result = await dialog.ShowAsync(this);
            string file = String.Join("", result);
            Random random = new Random();
            string photo = "Asset/photo" + random.Next(1, 10000) + ".jpg";
            File.Copy(file, photo);
            redSource.Text = photo;
            redImage.Source = new Bitmap(file);
        }
        catch { }
    }

    /// <summary>
    /// ����������� �� ���� � ���� "�� ������"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void EnableRestr(object sender, KeyEventArgs e)
    {
        if (redEnable.Text != "" &&
                (redEnable.Text.Contains("0") == false &&
                redEnable.Text.Contains("1") == false &&
                redEnable.Text.Contains("2") == false &&
                redEnable.Text.Contains("3") == false &&
                redEnable.Text.Contains("4") == false &&
                redEnable.Text.Contains("5") == false &&
                redEnable.Text.Contains("6") == false &&
                redEnable.Text.Contains("7") == false &&
                redEnable.Text.Contains("8") == false &&
                redEnable.Text.Contains("9") == false)
            )
        {
            redEnable.Text = "";
        }
    }

    /// <summary>
    /// ����������� �� ���� � ���� "����"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void PriceRestr(object sender, KeyEventArgs e)
    {
        if (redPrice.Text != "" &&
                (redPrice.Text.Contains(",") == false &&
                redPrice.Text.Contains("0") == false &&
                redPrice.Text.Contains("1") == false &&
                redPrice.Text.Contains("2") == false &&
                redPrice.Text.Contains("3") == false &&
                redPrice.Text.Contains("4") == false &&
                redPrice.Text.Contains("5") == false &&
                redPrice.Text.Contains("6") == false &&
                redPrice.Text.Contains("7") == false &&
                redPrice.Text.Contains("8") == false &&
                redPrice.Text.Contains("9") == false)
            )
        {
            redPrice.Text = "";
        }
    }

    /// <summary>
    /// ��������� ��������� 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Save(object sender, RoutedEventArgs e)
    {
        int i = 0;
        foreach (Product product in Assortiment.products)
        {
            if (product.id != redProduct.id && product.name == redName.Text)
            {
                i++;
            }
        }
        if (i == 0)
        {
            if (redSource.Text != null)
            {
                redProduct.source = redSource.Text;
                redProduct.image = new Bitmap(redSource.Text);
            } 
            if (redName.Text != null) redProduct.name = redName.Text;
            if (redCat.SelectedIndex != 0) redProduct.cat = redCat.SelectedIndex;
            if (redDescr.Text != null) redProduct.descr = redDescr.Text;
            if (redMan.SelectedIndex != 0) redProduct.manId = redMan.SelectedIndex;
            switch (redProduct.manId)
            {
                case 1:
                    redProduct.man = "OOO '��������� �����'";
                    break;

                case 2:
                    redProduct.man = "OOO '���'";
                    break;

                case 3:
                    redProduct.man = "����������";
                    break;
            }
            if (redEnable.Text != null) redProduct.enable = Convert.ToInt32(redEnable.Text);
            if (redPrice.Text != null) redProduct.price = Convert.ToDouble(redPrice.Text);
            AdminListWindow AdminList = new AdminListWindow();
            AdminList.Show();
            this.Close();
        }
        else
        {
            redEx.IsVisible = true;
        }
    }

    /// <summary>
    /// �������� ��������������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void Cancel(object sender, RoutedEventArgs e)
    {
        AdminListWindow AdminList = new AdminListWindow();
        AdminList.Show();
        this.Close();
    }
}