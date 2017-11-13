namespace RPGManager.Domain.Models
{
    public class User
    {
        private int _id;
        private string _username;
        private string _password;
        private string _email;
        private int _refId;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int RefId
        {
            get { return _refId; }
            set { _refId = value; }
        }
        public User(int id, string username, string password, string email)
        {
            _id = id;
            _username = username;
            _password = password;
            _email = email;
            _refId = 0;
        }
        public User(int id, string username, string password, string email, int refId)
        {
            _id = id;
            _username = username;
            _password = password;
            _email = email;
            _refId = refId;
        }
    }
}