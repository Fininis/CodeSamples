using Domain.Entities.Cms;
using Gui.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

//using System.Windows.Data;
using System.Windows.Input;

namespace Gui {

    /// <summary>
    /// Interaction logic for WndBinding.xaml
    /// </summary>
    public partial class WndBinding : Window {
        private IEnumerable<Binding> lstEntities;

        public WndBinding() {
            InitializeComponent();
            MouseLeftButtonDown += (sender, e) => DragMove();
            registerEvents();
        }

        private void registerEvents() {
            this.Loaded += load;
            imgAdd.PreviewMouseDown += addEntity;
            imgExit.PreviewMouseDown += (sender, e) => WindowsFunctions.Exit(this);
        }

        private void load(object sender, RoutedEventArgs e) {
            RefreshData();
        }

        private void RefreshData() {
            using (var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork())
                lstEntities = uow.BindingRepository.GetAllActive().ToList();
            lsbEntities.ItemsSource = lstEntities.OrderBy(x => x.Name);
            lsbEntities.SelectedIndex = 0;
        }

        private void addEntity(object sender, MouseButtonEventArgs e) {
            try {
                var wnd = new WndBindingEdit(new Binding());
                wnd.EditFinished += (sender2, e2) => RefreshData();
                wnd.Owner = this;
                WindowsFunctions.ShowSecondary(wnd);
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }

        private void editEntity(object sender, MouseButtonEventArgs e) {
            try {
                if (lsbEntities.SelectedItem != null) {
                    var wnd = new WndBindingEdit((Binding)lsbEntities.SelectedItem);
                    wnd.EditFinished += (sender2, e2) => RefreshData();
                    wnd.Owner = this;
                    WindowsFunctions.ShowSecondary(wnd);
                }
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}