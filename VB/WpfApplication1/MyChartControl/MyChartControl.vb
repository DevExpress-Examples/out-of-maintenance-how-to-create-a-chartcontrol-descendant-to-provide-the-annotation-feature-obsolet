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
	Public Class MyChartControl
		Inherits ChartControl
		Private privateOldXVisualRangeMax As Object
		Public Property OldXVisualRangeMax() As Object
			Get
				Return privateOldXVisualRangeMax
			End Get
			Set(ByVal value As Object)
				privateOldXVisualRangeMax = value
			End Set
		End Property
		Private privateOldXVisualRangeMin As Object
		Public Property OldXVisualRangeMin() As Object
			Get
				Return privateOldXVisualRangeMin
			End Get
			Set(ByVal value As Object)
				privateOldXVisualRangeMin = value
			End Set
		End Property
		Private privateOldYVisualRangeMax As Object
		Public Property OldYVisualRangeMax() As Object
			Get
				Return privateOldYVisualRangeMax
			End Get
			Set(ByVal value As Object)
				privateOldYVisualRangeMax = value
			End Set
		End Property
		Private privateOldYVisualRangeMin As Object
		Public Property OldYVisualRangeMin() As Object
			Get
				Return privateOldYVisualRangeMin
			End Get
			Set(ByVal value As Object)
				privateOldYVisualRangeMin = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Annotations = New AnotationCollection(Me)
			AddHandler Loaded, AddressOf MyChartControl_Loaded
		End Sub

		Private Sub MyChartControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If AnotationLayer Is Nothing Then
				Dim root As Grid = CType(VisualTreeHelper.GetChild(Me, 0), Grid)
				SetUpCursorLayer()
				SetUpAnotations(root)
				SetUpUpdates()
			End If
		End Sub

		Private Sub MyChartControl_Zoom(ByVal sender As Object, ByVal e As XYDiagram2DZoomEventArgs)
			AnotationLayer.InvalidateArrange()
		End Sub

		Private Sub MyChartControl_Scroll(ByVal sender As Object, ByVal e As XYDiagram2DScrollEventArgs)
			AnotationLayer.InvalidateArrange()
		End Sub

		Private Sub MyChartControl_SizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
			AnotationLayer.UpdateClipping()
			AnotationLayer.InvalidateArrange()
		End Sub

		Private Sub SetUpUpdates()
			Dim diagram As XYDiagram2D = CType(Me.Diagram, XYDiagram2D)
			AddHandler diagram.Scroll, AddressOf MyChartControl_Scroll
			AddHandler diagram.Zoom, AddressOf MyChartControl_Zoom
			AddHandler SizeChanged, AddressOf MyChartControl_SizeChanged
			AddHandler diagram.LayoutUpdated, AddressOf diagram_LayoutUpdated
		End Sub

		Private Sub diagram_LayoutUpdated(ByVal sender As Object, ByVal e As EventArgs)
			AnotationLayer.UpdateClipping()

			Dim diagram As XYDiagram2D = CType(Me.Diagram, XYDiagram2D)
			If IsRangeUpdated() Then
				AnotationLayer.InvalidateArrange()
				OldXVisualRangeMax = diagram.ActualAxisX.ActualVisualRange.ActualMaxValue
				OldXVisualRangeMin = diagram.ActualAxisX.ActualVisualRange.ActualMinValue
				OldYVisualRangeMax = diagram.ActualAxisY.ActualVisualRange.ActualMaxValue
				OldYVisualRangeMin = diagram.ActualAxisY.ActualVisualRange.ActualMinValue
			End If
		End Sub

		Private Function IsRangeUpdated() As Boolean
			Dim diagram As XYDiagram2D = CType(Me.Diagram, XYDiagram2D)
			Return diagram.ActualAxisX.ActualVisualRange Is Nothing OrElse diagram.ActualAxisY.ActualVisualRange Is Nothing OrElse (OldXVisualRangeMax <> diagram.ActualAxisX.ActualVisualRange.ActualMaxValue OrElse OldXVisualRangeMin <> diagram.ActualAxisX.ActualVisualRange.ActualMinValue) OrElse (OldYVisualRangeMax <> diagram.ActualAxisY.ActualVisualRange.ActualMaxValue OrElse OldYVisualRangeMin <> diagram.ActualAxisY.ActualVisualRange.ActualMinValue)
		End Function

		Private Sub SetUpCursorLayer()
			Dim navigationLayer As FrameworkElement = LayoutHelper.FindElementByName(Me, "PART_NavigationLayer")
			Canvas.SetZIndex(navigationLayer, 99)
		End Sub
		Private Sub SetUpAnotations(ByVal root As Grid)
			AnotationLayer = New AnnotationPanel(Me)
			root.Children.Add(AnotationLayer)
			Annotations.CreateAnotationPresenters()
		End Sub

		Private privateAnnotations As AnotationCollection
		Public Property Annotations() As AnotationCollection
			Get
				Return privateAnnotations
			End Get
			Set(ByVal value As AnotationCollection)
				privateAnnotations = value
			End Set
		End Property
		Private privateAnotationLayer As AnnotationPanel
		Protected Friend Property AnotationLayer() As AnnotationPanel
			Get
				Return privateAnotationLayer
			End Get
			Set(ByVal value As AnnotationPanel)
				privateAnotationLayer = value
			End Set
		End Property
	End Class
End Namespace