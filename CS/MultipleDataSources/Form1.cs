using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.DataAccess.Excel;

namespace MultipleDataSources {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            // Create XPO data sources with one-to-many relationship.
            Session session = new Session();

            var categories = new CustomXPCollection<Category>(session);
            new Category(session) { CategoryName = "Beverages" }.Save();
            new Category(session) { CategoryName = "Condiments" }.Save();
            new Category(session) { CategoryName = "Seafood" }.Save();

            var products = new CustomXPCollection<Product>(session);
            new Product(session) { ProductName = "Ikura", Category = categories.First(x => x.CategoryName == "Seafood") }.Save();
            new Product(session) { ProductName = "Ipoh Coffee", Category = categories.First(x => x.CategoryName == "Beverages") }.Save();
            new Product(session) { ProductName = "Aniseed Syrup", Category = categories.First(x => x.CategoryName == "Condiments") }.Save();

            //Create a data set and load a data table from an XML file.
            DataSet dsContacts = new DataSet();
            dsContacts.ReadXml("Contacts.xml");

            // Create an Excel data source.
            ExcelDataSource myExcelSource = new ExcelDataSource();
            myExcelSource.FileName = "OrderDetails.xlsx";
            ExcelWorksheetSettings worksheetSettings = new ExcelWorksheetSettings("Sales report", "B2:H18");
            myExcelSource.SourceOptions = new ExcelSourceOptions(worksheetSettings);
            myExcelSource.SourceOptions.UseFirstRowAsHeader = true;
            myExcelSource.Fill();

            #region #SetUseForMailMerge
            // Set the Application data source which cannot be edited or removed by the end-user.
            this.snapControl1.DataSource = dsContacts.Tables[0];
            // Add Document data sources which persist for the currently loaded document only.
            this.snapControl1.Document.BeginUpdateDataSource();
            this.snapControl1.Document.DataSources.Add("Products", products);
            this.snapControl1.Document.DataSources.Add("Categories", categories);
            this.snapControl1.Document.DataSources.Add("Sales", myExcelSource);
            this.snapControl1.Document.EndUpdateDataSource();

            // Set the default (Application) data source as the mail merge source ("Use for Mail Merge" option).
            this.snapControl1.Options.SnapMailMergeVisualOptions.DataSourceName = "";
            // Uncomment the following line to set the Sales data source as the mail merge source.
            // this.snapControl1.Options.SnapMailMergeVisualOptions.DataSourceName = "Sales";
            #endregion #SetUseForMailMerge
        }
    }
}
