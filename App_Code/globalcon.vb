Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Net.Mime
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization

Public Class globalcon
    Public con As OdbcConnection = New OdbcConnection("Dsn=PostgreSQL35W;database=idb;server=127.0.0.1;port=5432;uid=postgres;pwd=admin")

    Public Sub primarypopulate(ByVal ledtype As DropDownList, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT primary_name FROM primary_details where company_id='" & sessioncid & "' order by primary_type,primary_name asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ledtype.DataSource = dt
            ledtype.DataTextField = "primary_name"
            ledtype.DataValueField = "primary_name"
            ledtype.DataBind()
        End If

    End Sub
    Public Sub roomtypepopulate(ByVal roomtype As DropDownList, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT param_val FROM webparams where param='room_type' and company_id='" & sessioncid & "' order by param_val asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            roomtype.DataSource = dt
            roomtype.DataTextField = "param_val"
            roomtype.DataValueField = "param_val"
            roomtype.DataBind()
        End If
    End Sub

    Public Sub tabletypepopulate(ByVal tabletype As DropDownList, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT param_val FROM webparams where param='table_type' and company_id='" & sessioncid & "' order by param_val asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            tabletype.DataSource = dt
            tabletype.DataTextField = "param_val"
            tabletype.DataValueField = "param_val"
            tabletype.DataBind()
        End If
    End Sub

    Public Sub employeedesignation(ByVal emdesig As DropDownList, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT param_val FROM webparams where param='emp_designation' and company_id='" & sessioncid & "' order by param_val asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            emdesig.DataSource = dt
            emdesig.DataTextField = "param_val"
            emdesig.DataValueField = "param_val"
            emdesig.DataBind()
            emdesig.Items.Insert(0, New ListItem("--Select--", "0"))
        End If
    End Sub

    Public Sub productcategory(ByVal ddl As DropDownList, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT cat_name FROM product_category where company_id='" & sessioncid & "' order by cat_name asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddl.DataSource = dt
            ddl.DataTextField = "cat_name"
            ddl.DataValueField = "cat_name"
            ddl.DataBind()
        End If
    End Sub

    Public Sub productname(ByVal ddl As DropDownList, ByVal cat As String, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT pdct_name FROM product where cat_name='" & cat & "' and company_id='" & sessioncid & "' and status='Active' order by pdct_name asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddl.DataSource = dt
            ddl.DataTextField = "pdct_name"
            ddl.DataValueField = "pdct_name"
            ddl.DataBind()
        Else
            ddl.DataSource = ""
            ddl.DataBind()
        End If
    End Sub

    Public Sub booktypepopulate(ByVal ddl As DropDownList, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT param_val FROM webparams where company_id='" & sessioncid & "' and param='book_category' order by param_val asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddl.DataSource = dt
            ddl.DataTextField = "param_val"
            ddl.DataValueField = "param_val"
            ddl.DataBind()
        End If
    End Sub

    Public Sub booklangpopulate(ByVal ddl As DropDownList, ByVal sessioncid As Integer)
        Dim da As New OdbcDataAdapter("SELECT param_val FROM webparams where company_id='" & sessioncid & "' and param='book_language' order by param_val asc", con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddl.DataSource = dt
            ddl.DataTextField = "param_val"
            ddl.DataValueField = "param_val"
            ddl.DataBind()
        End If
    End Sub


    Public Sub TableReturn(ByVal quary As String, ByRef msg As String, ByRef tbl As DataTable)
        Dim da As New OdbcDataAdapter(quary, con)
        Dim ds As New DataTable
        da.Fill(ds)
        If ds(0).Table.Rows.Count > 0 Then
            tbl = ds(0).Table
            msg = "ok"
        Else
            msg = "error"
        End If

    End Sub
End Class
