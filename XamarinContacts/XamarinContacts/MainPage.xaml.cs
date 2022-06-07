using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinContacts
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Xamarin.Essentials.Contact> MyContacts { get; set; }
        public MainPage()
        {
            InitializeComponent();
            var contact1 = new List<ContactPhone>() { new ContactPhone("352-630-4384"), new ContactPhone("352-901-2058") };

        MyContacts = new ObservableCollection<Xamarin.Essentials.Contact>
            {
                new Xamarin.Essentials.Contact() { GivenName = "David", FamilyName = "Morrow", Phones = contact1 },
                new Xamarin.Essentials.Contact() { GivenName = "Micheal", FamilyName = "Morrow", Phones = contact1 },
                new Xamarin.Essentials.Contact() { GivenName = "Nacy", FamilyName = "Morrow", Phones = contact1 }
            };
            MyListView.ItemsSource = MyContacts;
            MyListView.IsPullToRefreshEnabled = true;
        }
            
        private async void PopulateContacts_Clicked(object sender, EventArgs e)
        {
            var contacts = await Xamarin.Essentials.Contacts.GetAllAsync();
            var contacts1 = contacts.ToList();
            MyContacts = new ObservableCollection<Xamarin.Essentials.Contact>(contacts1);
           
        }
    }
}
