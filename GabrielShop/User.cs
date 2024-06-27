namespace GabrielShop
{
    public class User
    {
        private string _log;
        private string _pass;
        private int _role;

        public string log
        {
            get
            {
                return _log;
            }
            set
            {
                _log = value;
            }
        }

        public string pass
        {
            get
            {
                return _pass;
            }
            set
            {
                _pass = value;
            }
        }

        public int role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
    }
}
