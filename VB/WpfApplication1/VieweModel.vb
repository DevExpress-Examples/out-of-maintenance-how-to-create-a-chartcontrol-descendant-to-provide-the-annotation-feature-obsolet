Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq

Namespace WpfApplication1
	Public Class ViewModel
		Implements IDisposable
		Public Sub Dispose() Implements IDisposable.Dispose
			If _Data IsNot Nothing Then
				_Data.Dispose()
				_Data = Nothing
			End If
		End Sub
		Public Sub New()

		End Sub

		' Fields...
		Private _Data As DataTable

		Public Property Data() As DataTable
			Get
				If _Data Is Nothing Then
					_Data = CreateData(10)
				End If
				Return _Data
			End Get
			Set(ByVal value As DataTable)
				_Data = value
			End Set
		End Property

		Private Function CreateData(ByVal rows As Integer) As DataTable
			Dim _r As New Random()

			Dim dt As New DataTable()
			dt.Columns.Add("Ser", GetType(Integer))
			dt.Columns.Add("Arg", GetType(Integer))
			dt.Columns.Add("Value", GetType(Integer))
			For i As Integer = 0 To rows - 1
				dt.Rows.Add(0, i, _r.Next(100))
				dt.Rows.Add(1, i, _r.Next(100))
			Next i
			Return dt
		End Function

	End Class
End Namespace
