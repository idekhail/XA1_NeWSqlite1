using SQLite;

using System.Collections.Generic;
using System.IO;

namespace XA1_NeWSqlite1
{
    public class UserOperations
    {
        //database path
        private readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(
            System.Environment.SpecialFolder.Personal), "XA1DB1.db3");
        private SQLiteConnection db;
        //Constructor     
        public UserOperations()
        {
            db = new SQLiteConnection(dbPath);
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
               // var  db = new SQLiteConnection(dbPath);
                db.CreateTable<Users>();
            }
        }
        // Table Operations [CRUD]
        public Users GetUser(string username, string password)
        {
            return db.Table<Users>().Where(i => i.Username == username && i.Password == password).FirstOrDefault();
        }
        public Users GetUser(int id)
        {
            return db.Table<Users>().Where(i => i.Id== id).FirstOrDefault();
        }
        public Users GetUser(string mobile)
        {
            return db.Table<Users>().Where(i => i.Mobile == mobile).FirstOrDefault();
        }
        // User Insert
        public void InsertUser(Users user)
        {
            //var db = new SQLiteConnection(dbPath);
            db.Insert(user);
        }

        // User Upbdate
        public void UpdateUser(Users user)
        {
            db.Update(user);
        }

        // User Delete
        public void DeleteUser(Users user)
        {
            db.Delete(user);
        }

        // List of User ارجاع بيانات جميع المقرارات مع جميع سجلات الشعب على شكل   

      //  public List<Users> GetAllUsers(string name)
        public List<Users> GetAllUsers()
        {
            return db.Table<Users>().ToList();

            //return db.Table<Users>().Where(i => i.Name == name).ToList();
        }



        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
       //    public string Name { get; set; }
            public string Mobile { get; set; }
        }
        
    }
}