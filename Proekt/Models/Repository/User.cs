using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt.Models.Repository
{
    public class User(int id, string username, string phone, string information, int rating)
     : PropertyChangedBase
    {
        private string _username = username;
        private string _phone = phone;
        private string _information = information;
        private int _rating = rating;
        public int Id
        {
            get;
            init;
        } = id;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }
        public string Information
        {
            get { return _information; }
            set { _information = value; OnPropertyChanged(); }
        }
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; OnPropertyChanged(); }
        }
        [NotMapped]
        public int ABC { get; set; } = 123456;
    }
}
