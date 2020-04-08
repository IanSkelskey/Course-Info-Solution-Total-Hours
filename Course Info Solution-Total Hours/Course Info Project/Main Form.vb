' Name:     Course Info Project
' Purpose:  Add, edit, delete, display records and display total number of credit hours completed.
' Name:     <your name> on <current date>

Option Explicit On
Option Strict On
Option Infer Off

Public Class frmMain
    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        ' Display the total number of credit hours completed.
        Dim intTotal As Integer
        For Each row As MyCoursesDataSet.CoursesRow In MyCoursesDataSet.Courses.Rows
            If row.IsGradeNull = False AndAlso row.Grade <> "W" Then
                intTotal += row.Hours
                lblTotal.Text = intTotal.ToString
            End If
        Next row

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub CoursesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CoursesBindingNavigatorSaveItem.Click
        Try
            Me.Validate()
            Me.CoursesBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.MyCoursesDataSet)
            MessageBox.Show("Changes saved.", "Course Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Course Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MyCoursesDataSet.Courses' table. You can move, or remove it, as needed.
        Me.CoursesTableAdapter.Fill(Me.MyCoursesDataSet.Courses)

    End Sub
End Class
