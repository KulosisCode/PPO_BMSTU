namespace Models
{
    public class Person
    {
        private int id;
        private int id_login;
        private string name;
        private int age;
        private string email;
        private string address;
        public int Id { get { return id; } set { id = value; } }
        public int Id_login { get { return id_login; } set { id_login = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Address { get { return address; } set { address = value; } }

        public Person ()
        {
            this.id = -1;
            this.id_login = -1;
            this.name = string.Empty;
            this.age = -1;
            this.email = string.Empty;
            this.address = string.Empty;
        }
        public Person(int id, int id_login, string name, int age, string email, string address)
        {
            this.id = id;
            this.id_login = id_login;
            this.name = name;
            this.age = age;
            this.email = email;
            this.address = address;
        }
        public Person(int id_login, string name, int age, string email, string address)
        {
            this.id = -1;
            this.id_login = id_login;
            this.name = name;
            this.age = age;
            this.email = email;
            this.address = address;
        }


    }
}
