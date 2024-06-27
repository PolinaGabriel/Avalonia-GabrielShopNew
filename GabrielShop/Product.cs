using Avalonia.Media.Imaging; 

namespace GabrielShop
{
    public class Product
    {
        private int _id; //id
        private string _source; //путь к картинке
        private Bitmap _image; //картинка
        private string _name; //имя
        private int _cat; //категория
        private string _descr; //описание
        private string _man; //производитель
        private int _manId; //id производителя
        private int _enable; //количество на складе
        private string _color; //цвет элемента
        private double _price; //цена
        private int _quantity; //количество в корзине
        private double _cost; //стоимость

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        
        public string source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
            }
        }

        public Bitmap image
        {
            get
            {
                if (_source == null)
                {
                    return new Bitmap("Asset/Placeholder.png");
                }
                else
                {
                    return new Bitmap(source);
                }
            }
            set
            {
                if (_source == null)
                {
                    _image = new Bitmap("Asset/Placeholder.png");
                }
                else
                {
                    _image = new Bitmap(source);
                } 
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int cat
        {
            get
            {
                return _cat;
            }
            set
            {
                _cat = value;
            }
        }

        public string descr
        {
            get
            {
                return _descr;
            }
            set
            {
                _descr = value;
            }
        }

        public string man
        {
            get
            {
                return _man;
            }
            set
            {
                _man = value;
            }
        }

        public int manId
        {
            get
            {
                return _manId;
            }
            set
            {
                _manId = value;
            }
        }

        public int enable
        {
            get
            {
                return _enable;
            }
            set
            {
                _enable = value;
            }
        }

        public string color
        {
            get
            {
                if (enable == 0)
                {
                    return "Grey";
                }
                else
                {
                    return "White";
                }
                
            }
            set
            {
                if (enable == 0)
                {
                    _color = "Grey";
                }
                else
                {
                    _color = "White";
                }
            }
        }

        public double price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public int quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        public double cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }
    }
}