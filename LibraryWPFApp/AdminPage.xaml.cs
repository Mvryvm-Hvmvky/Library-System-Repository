using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        public AdminPage()
        {
            InitializeComponent();
            booksDataGrid2.ItemsSource = libraryDBEntities.Books
                                         .Select(b => new { ID = b.bookID, Name = b.bookName, Author = b.authorName, Category_ID = b.categoryID })
                                         .ToList();
        }

        private void emptyTextBoxes()
        {
            IDTxt.Text = NameTxt.Text = AuthorTxt.Text = CategoryIDTxt.Text = string.Empty;
        }

        private void RefreshBooksDataGrid()
        {
            var booksList = libraryDBEntities.Books
                .Select(b => new { ID = b.bookID, Name = b.bookName, Author = b.authorName, Category_ID = b.categoryID })
                .ToList();
            booksDataGrid2.ItemsSource = booksList;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            BooksBrowserPage booksBrowserPage = new BooksBrowserPage();
            this.NavigationService.Navigate(booksBrowserPage);
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Book bookRecord = new Book();
            int? IDFromTxtBox = int.Parse(IDTxt.Text);

            libraryDBEntities.Books.Remove(libraryDBEntities.Books.First(b => b.bookID == IDFromTxtBox));
            libraryDBEntities.SaveChanges();
            emptyTextBoxes();
            RefreshBooksDataGrid();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Book bookRecord = new Book();
            bookRecord.bookID = int.Parse(IDTxt.Text);
            bookRecord.bookName = NameTxt.Text;
            bookRecord.authorName = AuthorTxt.Text;
            bookRecord.categoryID = int.Parse(CategoryIDTxt.Text);

            libraryDBEntities.Books.AddOrUpdate(bookRecord);
            libraryDBEntities.SaveChanges();
            emptyTextBoxes();
            RefreshBooksDataGrid();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Book bookRecord = new Book();
            bookRecord.bookID = int.Parse(IDTxt.Text);
            bookRecord.bookName = NameTxt.Text;
            bookRecord.authorName = AuthorTxt.Text;
            bookRecord.categoryID = int.Parse(CategoryIDTxt.Text);

            libraryDBEntities.Books.Add(bookRecord);
            libraryDBEntities.SaveChanges();
            emptyTextBoxes();
            RefreshBooksDataGrid();
        }
    }
}
