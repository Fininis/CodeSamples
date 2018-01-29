using Domain.Entities.Cms;
using Domain.Entities.Customers;
using Gui.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gui {

    /// <summary>
    /// Interaction logic for WndCustomers.xaml
    /// </summary>
    public partial class WndCustomer : Window {
        private IEnumerable<Customer> lstCustomers;
        private IEnumerable<City> lstCities;

        public WndCustomer() {
            InitializeComponent();
            MouseLeftButtonDown += (sender, e) => DragMove();
            registerEvents();
        }

        private void registerEvents() {
            this.Loaded += load;
            lsbEntities.SelectionChanged += getEntityData;
            txtbEdit.PreviewMouseDown += editEntity;
            txtSearch.KeyUp += filterEntitiesByName;
            cmbSearch.SelectionChanged += filterEntitiesByCity;
            imgExit.PreviewMouseDown += (sender, e) => WindowsFunctions.Exit(this);
            imgAdd.PreviewMouseDown += addEntity;
            txtbShowData.PreviewMouseDown += (sender, e) => showStackPanel(stkData);
            txtbShowNotes.PreviewMouseDown += (sender, e) => showStackPanel(stkNotes);
            txtSearch.GotFocus += clear;
        }

        private void load(object sender, RoutedEventArgs e) {
            RefreshData();
        }

        public void RefreshData() {
            lsbEntities.SelectionChanged -= getEntityData;
            using (var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork()) {
                lstCustomers = uow.CustomerRepository.GetAllActive();
                if (lstCities == null) {
                    lstCities = uow.CityRepository.GetAll();
                    cmbSearch.ItemsSource = lstCities.OrderBy(x => x.Name);
                }
                if (cmbRegion.ItemsSource == null)
                    cmbRegion.ItemsSource = uow.RegionRepository.GetAll().ToList();
                if (cmbSalesRepAccount.ItemsSource == null)
                    cmbSalesRepAccount.ItemsSource = uow.SalesRepAccountRepository.GetAll().ToList();
            }
            lsbEntities.ItemsSource = lstCustomers.OrderBy(x => x.Name);
            lsbEntities.SelectionChanged += getEntityData;
            lsbEntities.SelectedIndex = 0;
        }

        private void getEntityData(object sender, SelectionChangedEventArgs e) {
            showStackPanel(stkData);
            elliIndicator.Visibility = Visibility.Collapsed;
            var entity = (Customer)lsbEntities.SelectedItem;

            stkDataContext.DataContext = entity;

            if (entity.Notes != null)
                if (entity.Notes.Length > 0)
                    elliIndicator.Visibility = Visibility.Visible;
        }

        private void filterEntitiesByName(object sender, KeyEventArgs e) {
            lsbEntities.SelectionChanged -= getEntityData;
            lsbEntities.ItemsSource = lstCustomers.Where(x => x.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            lsbEntities.SelectionChanged += getEntityData;
            lsbEntities.SelectedIndex = 0;
        }

        private void filterEntitiesByCity(object sender, SelectionChangedEventArgs e) {
            lsbEntities.SelectionChanged -= getEntityData;
            lsbEntities.ItemsSource = lstCustomers.Where(x => x.CityId == (int)cmbSearch.SelectedValue).ToList();
            lsbEntities.SelectionChanged += getEntityData;
            lsbEntities.SelectedIndex = 0;
        }

        private void editEntity(object sender, MouseButtonEventArgs e) {
            try {
                if (lsbEntities.SelectedItem != null) {
                    var wnd = new WndCustomerEdit((Customer)lsbEntities.SelectedItem);
                    wnd.EditFinished += (sender2, e2) => RefreshData();
                    wnd.Owner = this;
                    WindowsFunctions.Show(wnd);
                }
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }

        private void addEntity(object sender, MouseButtonEventArgs e) {
            try {
                var wnd = new WndCustomerEdit(new Customer());
                wnd.EditFinished += (sender2, e2) => RefreshData();
                wnd.Owner = this;
                WindowsFunctions.Show(wnd);
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }

        private void showStackPanel(StackPanel stk) {
            hideAll();
            stk.Visibility = Visibility.Visible;
        }

        private void clear(object sender, RoutedEventArgs e) {
            txtSearch.Text = "";
        }

        private void hideAll() {
            stkData.Visibility = Visibility.Collapsed;
            stkNotes.Visibility = Visibility.Collapsed;
        }
    }
}