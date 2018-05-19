Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.ComponentModel
Imports System.Collections.Generic

Namespace MyChartControl
	Public Class AnotationCollection
		Inherits BindingList(Of Annotation)

		Public Sub New(ByVal chart As MyChartControl)
			Owner = chart
		End Sub

		Protected Overrides Sub OnListChanged(ByVal e As ListChangedEventArgs)
			If Owner.AnotationLayer IsNot Nothing Then
				CreateAnotationPresenters()
			End If
			MyBase.OnListChanged(e)
		End Sub

		Protected Friend Sub CreateAnotationPresenters()
			For Each anotation As Annotation In Me
				Dim anotationPresenter As New AnotationPresenter() With {.DataContext = anotation}
				Owner.AnotationLayer.Children.Add(anotationPresenter)
			Next anotation
		End Sub
		Private privateOwner As MyChartControl
		Public Property Owner() As MyChartControl
			Get
				Return privateOwner
			End Get
			Private Set(ByVal value As MyChartControl)
				privateOwner = value
			End Set
		End Property
	End Class
End Namespace