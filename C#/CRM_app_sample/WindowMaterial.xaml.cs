using Domain.Entities.Cms;
using Gui.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Gui {

    /// <summary>
    /// Interaction logic for WndMaterial.xaml
    /// </summary>
    public partial class WndMaterial : Window {
        private IEnumerable<Material> lstEntities;

        public WndMaterial() {
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
                lstEntities = uow.MaterialRepository.GetAllActive();
            lsbEntities.ItemsSource = lstEntities.OrderBy(x => x.Name);
            lsbEntities.SelectedIndex = 0;
        }

        private void addEntity(object sender, MouseButtonEventArgs e) {
            try {
                var wnd = new WndMaterialEdit(new Material());
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
                    var wnd = new WndMaterialEdit((Material)lsbEntities.SelectedItem);
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