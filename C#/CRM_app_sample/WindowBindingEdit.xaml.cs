using Domain.Entities.Cms;
using Gui.Configurations;
using System;
using System.Collections.Generic;
using System.Windows;

//using System.Windows.Data;
using System.Windows.Input;

namespace Gui {

    /// <summary>
    /// Interaction logic for WndBindingEdit.xaml
    /// </summary>
    public partial class WndBindingEdit : Window {
        private Binding entity { get; set; }
        private IEnumerable<Binding> lstEntities { get; set; }

        public EventHandler EditFinished;

        public WndBindingEdit(Binding _entity) {
            InitializeComponent();
            MouseLeftButtonDown += (sender, e) => DragMove();
            registerEvents();
            this.entity = _entity;
        }

        private void registerEvents() {
            this.Loaded += loaded;
            brdDelete.PreviewMouseDown += deactivate;
            imgExit.PreviewMouseDown += (sender, e) => WindowsFunctions.Exit(this);
        }

        private void loaded(object sender, RoutedEventArgs e) {
            RefreshData();
        }

        private void RefreshData() {
            try {
                using (var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork())
                    lstEntities = uow.BindingRepository.GetAllActive();
                this.DataContext = entity;
                if (entity.Id > 0) {
                    brdSave.PreviewMouseDown += saveEntity;
                }
                else
                    brdSave.PreviewMouseDown += insertEntity;
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }

        private void saveEntity(object sender, MouseButtonEventArgs e) {
            try {
                using (var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork()) {
                    uow.BindingRepository.Save(entity);
                    uow.Complete();
                }
                EditFinished(this, EventArgs.Empty);
                MessageBox.Show(WindowsMessages.messageForSaveInsert);
                WindowsFunctions.Exit(this);
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }

        private void insertEntity(object sender, MouseButtonEventArgs e) {
            try {
                using (var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork()) {
                    uow.BindingRepository.Insert(entity);
                    uow.Complete();
                }
                if (entity.Id > 0) {
                    EditFinished(this, EventArgs.Empty);
                    MessageBox.Show(WindowsMessages.messageForSaveInsert);
                    WindowsFunctions.Exit(this);
                }
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }

        private void deactivate(object sender, MouseButtonEventArgs e) {
            try {
                entity.Active = false;
                using (var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork()) {
                    uow.BindingRepository.Save(entity);
                    uow.Complete();
                }
                EditFinished(this, EventArgs.Empty);
                MessageBox.Show(WindowsMessages.messageForDeactivate);
                WindowsFunctions.Exit(this);
            }
            catch (System.Exception ex) {
                MessageBox.Show(WindowsMessages.messageForAdmin);
                MessageBox.Show(ex.Message + "/n" + ex.StackTrace);
            }
        }
    }
}