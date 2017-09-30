namespace WSSample.Models
{
    class User
    {
        private string _password;
        
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { set { _password = value; } }

        public Profile Profile { get; set; }

        public bool CheckPassword(string password)
        {
            return _password == password;
        }
    }
}
