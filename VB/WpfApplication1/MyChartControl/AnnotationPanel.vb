Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Media
Imports DevExpress.Xpf.Charts
Imports System.Windows.Controls
Imports System.Collections.Generic
Imports DevExpress.Xpf.Core.Native

Namespace MyChartControl
	Public Class AnnotationPanel
		Inherits Panel

		Public Sub New(ByVal owner As MyChartControl)
			Me.Owner = owner
			Diagram = CType(Owner.Diagram, XYDiagram2D)
			UpdateClipping()
		End Sub

		Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
			For i As Integer = 0 To InternalChildren.Count - 1
				InternalChildren(i).Measure(availableSize)
			Next i
			Return availableSize
		End Function

		Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
			For i As Integer = 0 To InternalChildren.Count - 1
				Dim anotationPresenter As AnotationPresenter = CType(InternalChildren(i), AnotationPresenter)
				Dim anotationRec As Rect = CalcAnotationRec(anotationPresenter)
				If (Not anotationRec.IsEmpty) Then
					anotationPresenter.Arrange(anotationRec)
				End If
			Next i
			Return finalSize
		End Function

		Private Function CalcAnotationRec(ByVal anotationPresenter As AnotationPresenter) As Rect
			Dim annotation As Annotation = CType(anotationPresenter.DataContext, Annotation)
			Dim argumnt As Double = annotation.Argument
			Dim value As Double = annotation.Value

			Dim coordInfo As ControlCoordinates = Diagram.DiagramToPoint(argumnt, value)
			Dim x As Double = coordInfo.Point.X
			Dim y As Double = coordInfo.Point.Y
			Dim anotationRec As New Rect(New Point(x, y), anotationPresenter.DesiredSize)
			Return anotationRec
		End Function
		Public Sub UpdateClipping()
			Dim panel As DomainPanel = LayoutHelper.FindElementByType(Of DevExpress.Xpf.Charts.DomainPanel)(Diagram)
			Dim diagramRec As Rect = SizeHelper.BoundsRelativeTo(panel, Owner)
			If Clip Is Nothing Then
				Clip = New RectangleGeometry(diagramRec)
			End If
			If Clip.Bounds <> diagramRec Then
				Clip = New RectangleGeometry(diagramRec)
			End If
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
		Private privateDiagram As XYDiagram2D
		Public Property Diagram() As XYDiagram2D
			Get
				Return privateDiagram
			End Get
			Private Set(ByVal value As XYDiagram2D)
				privateDiagram = value
			End Set
		End Property

	End Class
End Namespace