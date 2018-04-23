using System.Windows.Forms;
using DevExpress.Xpo;
// ...

namespace Multiple_XPCollection_Datasources {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Session session = new Session();   
            
            var products = new XPCollection<Product>(session);
            new Product(session) { ProductName="Chai" }.Save();
            new Product(session) { ProductName="Ipoh Coffee" }.Save();
            new Product(session) { ProductName="Aniseed Syrup" }.Save();

            var categories = new XPCollection<Category>(session);
            new Category(session) { CategoryName = "Beverages" }.Save();
            new Category(session) { CategoryName = "Condiments" }.Save();
            new Category(session) { CategoryName = "Seafood" }.Save();

            this.snapControl1.Document.BeginUpdateDataSource();
            this.snapControl1.Document.DataSources.Add("Products", products);
            this.snapControl1.Document.DataSources.Add("Categories", categories);
            this.snapControl1.Document.EndUpdateDataSource();
        }
    }
}
