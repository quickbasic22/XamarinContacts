using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinContacts
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Xamarin.Essentials.Contact> MyContacts { get; set; }
        //private List<ContactPhone> contact1;
        public MainPage()
        {
            InitializeComponent();  
            
           // BindingContext = this;
        //  contact1 = new List<ContactPhone>() { new ContactPhone("352-630-4384"), new ContactPhone("352-901-2058") };
        }

        private async void PopulateContacts_Clicked(object sender, EventArgs e)
        {
            // IEnumerable<Contact> contactslist = null;
            MyContacts = new ObservableCollection<Contact>();
            try
            {
                // var cancellationToken = default(CancellationToken);
                var contactslist = await Contacts.GetAllAsync();
                foreach (var contact in contactslist)
                {
                    MyContacts.Add(contact);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert(Title, ex.ToString(), "Cancel");
            }

            
            MyListView.ItemsSource = MyContacts;
            MyListView.IsPullToRefreshEnabled = true;
        }

        //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);
        //}

        protected override void OnAppearing()
        {
            //var here = Task.Run(async () => await Task.Delay(2000));
            //here.Wait();
            //IEnumerable<Contact> contactslist = null;

            //try
            //{
            //    var cancellationToken = default(CancellationToken);
            //    contactslist = await Contacts.GetAllAsync(cancellationToken);
            //}
            //catch (Exception ex)
            //{
            //   await DisplayAlert(Title, ex.ToString(), "Cancel");
            //}

            //MyContacts = new ObservableCollection<Xamarin.Essentials.Contact>(contactslist);
            //MyListView.ItemsSource = MyContacts;
            //MyListView.IsPullToRefreshEnabled = true;
        }
    }
}
