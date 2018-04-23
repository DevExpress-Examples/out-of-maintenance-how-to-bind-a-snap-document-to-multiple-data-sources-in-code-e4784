Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
' ...

Namespace Multiple_XPCollection_Datasources
	Public Class Category
		Inherits XPObject
		Private fCategoryName As String
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public Property CategoryName() As String
			Get
				Return fCategoryName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CategoryName", fCategoryName, value)
			End Set
		End Property
	End Class

	Public Class Product
		Inherits XPObject
		Private fProductName As String
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public Property ProductName() As String
			Get
				Return fProductName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("ProductName", fProductName, value)
			End Set
		End Property
	End Class


End Namespace
