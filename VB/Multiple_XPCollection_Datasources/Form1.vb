Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports DevExpress.Xpo
' ...

Namespace Multiple_XPCollection_Datasources
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Dim session As New Session()

			Dim products = New XPCollection(Of Product)(session)
			Dim TempProduct As Product = New Product(session)
            TempProduct.ProductName = "Chai"
            TempProduct.Save()
            TempProduct = New Product(session)
            TempProduct.ProductName = "Ipoh Coffee"
            TempProduct.Save()
            TempProduct = New Product(session)
            TempProduct.ProductName = "Aniseed Syrup"
            TempProduct.Save()

			Dim categories = New XPCollection(Of Category)(session)
			Dim TempCategory As Category = New Category(session)
            TempCategory.CategoryName = "Beverages"
            TempCategory.Save()
            TempCategory = New Category(session)
            TempCategory.CategoryName = "Condiments"
            TempCategory.Save()
            TempCategory = New Category(session)
            TempCategory.CategoryName = "Seafood"
            TempCategory.Save()

			Me.snapControl1.Document.BeginUpdateDataSource()
			Me.snapControl1.Document.DataSources.Add("Products", products)
			Me.snapControl1.Document.DataSources.Add("Categories", categories)
			Me.snapControl1.Document.EndUpdateDataSource()
		End Sub
	End Class
End Namespace
