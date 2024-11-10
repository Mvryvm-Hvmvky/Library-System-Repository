using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryWPFApp
{
    /// <summary>
    /// Interaction logic for BooksBrowserPage.xaml
    /// </summary>
    public partial class BooksBrowserPage : Page
    {
        public int? categoryID;
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        // private void LoadBooks()
        // {
        //     var booksList = libraryDBEntities.Books
        //         .Where(b => b.categoryID == this.categoryID)
        //         .Select(b => new { ID = b.bookID, Name = b.bookName, Author = b.authorName, Category_ID = b.categoryID })
        //         .ToList();
        //     
        //     if (booksList.Any())
        //     {
        //         booksDataGrid.ItemsSource = booksList;
        //     }
        //     else
        //     {
        //         MessageBox.Show("No books found for the selected category.");
        //     }
        // }
        public BooksBrowserPage()
        {
            InitializeComponent();
            var booksList = libraryDBEntities.Books
                                .Select(b => new { ID = b.bookID, Name = b.bookName, Author = b.authorName, Category_ID = b.categoryID })
                                .ToList();

            if (booksList.Any())
            {
                booksDataGrid.ItemsSource = booksList;
            }
            else
            {
                MessageBox.Show("No books found to display.");
            }
        }
            public BooksBrowserPage(int? categoryID)
        {
            InitializeComponent();
            this.categoryID = categoryID;

            var booksList = libraryDBEntities.Books
                .Where(b => b.categoryID == this.categoryID)
                .Select(b => new { ID = b.bookID, Name = b.bookName, Author = b.authorName, Category_ID = b.categoryID })
                .ToList();

            if (booksList.Any())
            {
                booksDataGrid.ItemsSource = booksList;
            }
            else
            {
                MessageBox.Show("No books found for the selected category.");
            }
        }

        private void adminPageNavBtn_Click(object sender, RoutedEventArgs e)
        {
                AdminPage adminPage = new AdminPage();
                this.NavigationService.Navigate(adminPage);
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            string bookName = BrowsingTextBox.Text;
            var booksList = libraryDBEntities.Books
                .Where(b => b.categoryID == this.categoryID)
                .Select(b => new { ID = b.bookID, Name = b.bookName, Author = b.authorName, Category_ID = b.categoryID })
                .ToList();
            var bookRecord = libraryDBEntities.Books.Where(b => b.bookName == bookName)
                                                    .Select(b => new { ID = b.bookID, Name = b.bookName, Author = b.authorName, Category_ID = b.categoryID })
                                                    .ToList();
            if (bookRecord.Any())
            {
                booksDataGrid.ItemsSource = bookRecord;
                BrowsingTextBox.Text = string.Empty;
            }
            else
            {
                booksDataGrid.ItemsSource = booksList;
                MessageBox.Show("This book name doesn't exist");
            }
        }
    }
}
