Imports System.Web
Imports System.IO
Imports globalcon
Imports globaldesign
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data.Odbc
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim dbcon As New globalcon
    Dim gcdsgn As New globaldesign



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim da As New OdbcDataAdapter("select count(channel),count(distinct(genere)) from epglist", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            lbltotalchannel.Text = ds.Tables(0).Rows(0).Item(0)
            lblgenere.Text = ds.Tables(0).Rows(0).Item(1)

            Dim da1 As New OdbcDataAdapter("select count(*) from epg_schedule where action_time::date='" & Today.Date & "' and userid is not NULL", dbcon.con)
            Dim ds1 As New DataSet
            da1.Fill(ds1)
            lblentry.Text = ds1.Tables(0).Rows(0).Item(0)

            Dim da2 As New OdbcDataAdapter("select count(*) from epg_schedule where action_time::date='" & Today.Date & "' and userid is NULL", dbcon.con)
            Dim ds2 As New DataSet
            da2.Fill(ds2)
            lblslotleft.Text = ds2.Tables(0).Rows(0).Item(0)


        Catch ex As Exception

        End Try
    End Sub
End Class
