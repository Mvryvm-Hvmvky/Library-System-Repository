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
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        LibraryDBEntities libraryDBEntities = new LibraryDBEntities();
        public int categoryID;
        public CategoriesPage()
        {
            InitializeComponent();
        }

        private void booksPageNavBtn_Click(object sender, RoutedEventArgs e)
        {
            if (categoriesListBox.SelectedItem is ListBoxItem selectedItem)
            {
                string selectedCategory = selectedItem.Content.ToString();
                int? categoryID = libraryDBEntities.Categories
                    .Where(c => c.categoryName == selectedCategory)
                    .Select(c => c.categoryID)
                    .FirstOrDefault();
                
                BooksBrowserPage booksBrowserPage = new BooksBrowserPage(categoryID);
                this.NavigationService.Navigate(booksBrowserPage);
            }
            else
            {
                MessageBox.Show("Please select a category to view the books.");
            }
        }
    }
}
