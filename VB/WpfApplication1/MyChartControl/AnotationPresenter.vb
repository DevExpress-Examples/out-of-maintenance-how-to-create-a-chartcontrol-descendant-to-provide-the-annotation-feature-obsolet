Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Collections.Generic

Namespace MyChartControl
	Public Class AnotationPresenter
		Inherits Control
		Shared Sub New()
			DefaultStyleKeyProperty.OverrideMetadata(GetType(AnotationPresenter), New FrameworkPropertyMetadata(GetType(AnotationPresenter)))
		End Sub

		Public Sub New()

		End Sub
	End Class
End Namespace
