﻿Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.Mvvm
' ...

Namespace SilverlightApplication_ReportDesigner_CustomButton
	Public Class MainPageViewModel
		Implements INotifyPropertyChanged
		Private buttonContent_Renamed As String = "Press me!"
		Public Property ButtonContent() As String
			Get
				Return buttonContent_Renamed
			End Get
			Set(ByVal value As String)
				buttonContent_Renamed = value
				RaisePropertyChanged("ButtonContent")
			End Set
		End Property

		Private privateDoWork As ICommand
		Public Property DoWork() As ICommand
			Get
				Return privateDoWork
			End Get
			Private Set(ByVal value As ICommand)
				privateDoWork = value
			End Set
		End Property

		Public Sub New()
            DoWork = New DelegateCommand(Function() MessageBox.Show("The custom button has been clicked."))
		End Sub

		#Region "INotifyPropertyChanged"
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Private Sub RaisePropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub
		#End Region
	End Class
End Namespace
