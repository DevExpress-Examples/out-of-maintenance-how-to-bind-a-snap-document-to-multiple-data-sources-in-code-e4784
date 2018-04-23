Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Xpo
Imports DevExpress.Data

Namespace MultipleDataSources
    Public Class Category
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public CategoryName As String

        <Association("Category-Products")> _
        Public ReadOnly Property Products() As XPCollection(Of Product)
            Get
                Return GetCollection(Of Product)("Products")
            End Get
        End Property
    End Class

    Public Class Product
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public ProductName As String

        <Association("Category-Products")> _
        Public Category As Category
    End Class
    #Region "#CustomXpCollection"
    ' Implement the IDisplayNameProvider interface to prevent recurring display of the parent object properties.
    Public Class CustomXPCollection(Of T)
        Inherits XPCollection(Of T)
        Implements IDisplayNameProvider

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Function GetDataSourceDisplayName() As String Implements IDisplayNameProvider.GetDataSourceDisplayName
            Return GetType(T).Name
        End Function
        ' Do not create a child node with the name of the property 
        ' that is responsible for the "Many" part of the Category-Products relationship.  
        Public Function GetFieldDisplayName(ByVal fieldAccessors() As String) As String Implements IDisplayNameProvider.GetFieldDisplayName
            Dim fieldName As String = fieldAccessors(fieldAccessors.Length - 1)
            If fieldName = "Products" Then
                Return Nothing
            End If
            Return fieldName
        End Function
    End Class
    #End Region ' #CustomXpCollection
End Namespace
