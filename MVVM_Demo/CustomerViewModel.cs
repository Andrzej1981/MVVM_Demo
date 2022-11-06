using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace MVVM_Demo
{
    public class CustomerViewModel: IDisposable
    {
        private NorthwindStoreEntities _entities;
        public CustomerViewModel() => _entities = new NorthwindStoreEntities();
        public BindingSource CustomerBindingSource { get; set; }

        public void Load()
        {
            _entities.Customer.Load();
            CustomerBindingSource.DataSource = _entities.Customer.Local.ToBindingList();
        }

        public void Delete() => CustomerBindingSource.RemoveCurrent();
        public void New() => CustomerBindingSource.AddNew();
        public void Save()
        {
            CustomerBindingSource.EndEdit();
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }

    }
}
