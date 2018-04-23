Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.DataAccess.Excel

Namespace MultipleDataSources
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            ' Create XPO data sources with one-to-many relationship.
            Dim session As New Session()

            Dim categories = New CustomXPCollection(Of Category)(session)
            CType(New Category(session) With {.CategoryName = "Beverages"}, Category).Save()
            CType(New Category(session) With {.CategoryName = "Condiments"}, Category).Save()
            CType(New Category(session) With {.CategoryName = "Seafood"}, Category).Save()

            Dim products = New CustomXPCollection(Of Product)(session)
            CType(New Product(session) With {.ProductName = "Ikura", .Category = categories.First(Function(x) x.CategoryName = "Seafood")}, Product).Save()
            CType(New Product(session) With {.ProductName = "Ipoh Coffee", .Category = categories.First(Function(x) x.CategoryName = "Beverages")}, Product).Save()
            CType(New Product(session) With {.ProductName = "Aniseed Syrup", .Category = categories.First(Function(x) x.CategoryName = "Condiments")}, Product).Save()

            'Create a data set and load a data table from an XML file.
            Dim dsContacts As New DataSet()
            dsContacts.ReadXml("Contacts.xml")

            ' Create an Excel data source.
            Dim myExcelSource As New ExcelDataSource()
            myExcelSource.FileName = "OrderDetails.xlsx"
            Dim worksheetSettings As New ExcelWorksheetSettings("Sales report", "B2:H18")
            myExcelSource.SourceOptions = New ExcelSourceOptions(worksheetSettings)
            myExcelSource.SourceOptions.UseFirstRowAsHeader = True
            myExcelSource.Fill()

'            #Region "#SetUseForMailMerge"
            ' Set the Application data source which cannot be edited or removed by the end-user.
            Me.snapControl1.DataSource = dsContacts.Tables(0)
            ' Add Document data sources which persist for the currently loaded document only.
            Me.snapControl1.Document.BeginUpdateDataSource()
            Me.snapControl1.Document.DataSources.Add("Products", products)
            Me.snapControl1.Document.DataSources.Add("Categories", categories)
            Me.snapControl1.Document.DataSources.Add("Sales", myExcelSource)
            Me.snapControl1.Document.EndUpdateDataSource()

            ' Set the default (Application) data source as the mail merge source ("Use for Mail Merge" option).
            Me.snapControl1.Options.SnapMailMergeVisualOptions.DataSourceName = ""
            ' Uncomment the following line to set the Sales data source as the mail merge source.
            ' this.snapControl1.Options.SnapMailMergeVisualOptions.DataSourceName = "Sales";
'            #End Region ' #SetUseForMailMerge
        End Sub
    End Class
End Namespace
