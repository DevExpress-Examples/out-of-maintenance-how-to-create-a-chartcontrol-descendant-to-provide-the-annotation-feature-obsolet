Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Media
Imports System.Collections.Generic

Namespace MyChartControl
	Public Module SizeHelper
		Sub New()
		End Sub
		<System.Runtime.CompilerServices.Extension> _
		Public Function BoundsRelativeTo(ByVal element As FrameworkElement, ByVal relativeTo As Visual) As Rect
			Return element.TransformToVisual(relativeTo).TransformBounds(New Rect(0, 0, element.ActualWidth, element.ActualHeight))
		End Function
	End Module
End Namespace
