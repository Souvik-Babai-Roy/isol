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


    Private Sub InitialLoadData()
        Dim da As New OdbcDataAdapter("select distinct genere from epglist order by genere asc", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ddlgenere.DataSource = ds.Tables(0)
            ddlgenere.DataTextField = "genere"
            ddlgenere.DataValueField = "genere"
            ddlgenere.DataBind()

        End If
    End Sub

    Public Sub channelload()
        Dim da As New OdbcDataAdapter("select channel,id from epglist where genere='" & ddlgenere.SelectedItem.Text.ToString & "' and id in (select distinct serviceid from epg_schedule_library) order by channel asc", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddlchname.DataSource = dt
            ddlchname.DataTextField = "channel"
            ddlchname.DataValueField = "id"
            ddlchname.DataBind()
        End If
    End Sub



    Protected Sub ddlgenere_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlgenere.TextChanged
        Dim da As New OdbcDataAdapter("select channel,id from epglist where genere='" & ddlgenere.SelectedItem.Text.ToString & "' and id in (select distinct serviceid from epg_schedule_library) order by channel asc", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddlchname.DataSource = dt
            ddlchname.DataTextField = "channel"
            ddlchname.DataValueField = "id"
            ddlchname.DataBind()
        End If
    End Sub


    Protected Sub txtstartdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstartdate.TextChanged
        Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60 as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid=" & ddlchname.SelectedValue & " and start_time::date='" & txtstartdate.Text & "' order by start_time asc", dbcon.con)
        Dim dt As New DataSet
        da.Fill(dt)
        If dt.Tables(0).Rows.Count > 0 Then
            tblepg.DataSource = dt
            tblepg.DataBind()
        Else
            tblepg.DataSource = ""
            tblepg.DataBind()
        End If
    End Sub

    Protected Sub txtepgdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtepgdate.TextChanged
        Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60  as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid=" & ddlchname.SelectedValue & " and epgdate::date='" & txtepgdate.Text & "' order by start_time asc", dbcon.con)
        Dim dt As New DataSet
        da.Fill(dt)
        If dt.Tables(0).Rows.Count > 0 Then
            tblepg.DataSource = dt
            tblepg.DataBind()
        Else
            tblepg.DataSource = ""
            tblepg.DataBind()
        End If
    End Sub



    Protected Sub ddlchname_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlchname.Load
        If txtepgdate.Text <> "" And txtstartdate.Text <> "" Then
            Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60  as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid='" & ddlchname.SelectedValue & "' and epgdate::date='" & txtepgdate.Text & "' and start_time::date='" & txtstartdate.Text & "' order by start_time asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        ElseIf txtepgdate.Text = "" And txtstartdate.Text <> "" Then
            Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60  as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid='" & ddlchname.SelectedValue & "' and start_time::date='" & txtstartdate.Text & "' order by start_time asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        ElseIf txtepgdate.Text <> "" And txtstartdate.Text = "" Then
            Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60  as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid='" & ddlchname.SelectedValue & "' and epgdate::date='" & txtepgdate.Text & "' order by start_time asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        Else

        End If
    End Sub

    Private Sub migrate()
        Try
            Dim nxt As Double = 0
            nxt = DateDiff(DateInterval.Day, CDate(txtstartdate.Text.ToString), CDate(txtmigdate.Text))


            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con

            Dim qry As String = ""

            If ddlmigoption.SelectedValue = 0 Then
                qry = "INSERT INTO epg_schedule(action_time,cid,channelname,start_time,end_time,eventid,eventname,event_description,event_short_desc,duration) " & _
" SELECT '" & Now.ToString("yyyy-MM-dd HH':'mm':'ss") & "',serviceid, (SELECT channel FROM epglist WHERE ID=serviceid) ,start_time+ INTERVAL '" & nxt & " day',end_time+ INTERVAL '" & nxt & " day',eventid,eventname,ext_desc,short_desc, " & _
" extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60 from epg_schedule_library " & _
" where serviceid=" & ddlchname.SelectedValue & " and start_time::date='" & CDate(txtstartdate.Text.ToString).ToString("yyyy-MM-dd HH':'mm':'ss") & "' and epgdate::date='" & CDate(txtepgdate.Text.ToString).ToString("yyyy-MM-dd HH':'mm':'ss") & "'"


                cmd.CommandText = "Delete from epg_schedule where cid=" & ddlchname.SelectedValue & " and start_time::date='" & CDate(txtmigdate.Text.ToString).ToString("yyyy-MM-dd HH':'mm':'ss") & "'"
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()

                cmd.CommandText = qry
                cmd.ExecuteNonQuery()



                cmd.Parameters.Clear()
                msgct2.InnerHtml = gcdsgn.alertmsg("Referrence Schedule migrated to Selected date successfully", "success")


            ElseIf ddlmigoption.SelectedValue = 1 Then


                qry = "INSERT INTO epg_schedule(action_time,cid,channelname,start_time,end_time,eventid,eventname,event_description,event_short_desc,duration) " & _
" SELECT '" & Now.ToString("yyyy-MM-dd HH':'mm':'ss") & "',serviceid, (SELECT channel FROM epglist WHERE ID=serviceid) ,start_time+ INTERVAL '" & nxt & " day',end_time+ INTERVAL '" & nxt & " day',eventid,eventname,ext_desc,short_desc, " & _
" extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60 from epg_schedule_library " & _
" where serviceid in (select id from epglist where genere='" & ddlgenere.SelectedValue.ToString & "') and start_time::date='" & CDate(txtstartdate.Text.ToString).ToString("yyyy-MM-dd HH':'mm':'ss") & "' and epgdate::date='" & CDate(txtepgdate.Text.ToString).ToString("yyyy-MM-dd HH':'mm':'ss") & "'"


                cmd.CommandText = "Delete from epg_schedule where cid in (select id from epglist where genere='" & ddlgenere.SelectedValue.ToString & "') and start_time::date='" & CDate(txtmigdate.Text.ToString).ToString("yyyy-MM-dd HH':'mm':'ss") & "'"
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()

                cmd.CommandText = qry
                cmd.ExecuteNonQuery()



                cmd.Parameters.Clear()
                msgct2.InnerHtml = gcdsgn.alertmsg("Referrence Schedule migrated to Selected date successfully", "success")


            End If

          

        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally

            dbcon.con.Close()

        End Try
    End Sub

    Protected Sub ddlchname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlchname.TextChanged
        If txtepgdate.Text <> "" And txtstartdate.Text <> "" Then
            Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60  as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid='" & ddlchname.SelectedValue & "' and epgdate::date='" & txtepgdate.Text & "' and start_time::date='" & txtstartdate.Text & "' order by start_time asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        ElseIf txtepgdate.Text = "" And txtstartdate.Text <> "" Then
            Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60  as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid='" & ddlchname.SelectedValue & "' and start_time::date='" & txtstartdate.Text & "' order by start_time asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        ElseIf txtepgdate.Text <> "" And txtstartdate.Text = "" Then
            Dim da As New OdbcDataAdapter("select start_time,extract(epoch from (END_TIME::timestamp - START_TIME::timestamp)) / 60  as duration,eventname,short_desc,ext_desc,end_time,id from epg_schedule_library where serviceid='" & ddlchname.SelectedValue & "' and epgdate::date='" & txtepgdate.Text & "' order by start_time asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        Else

        End If
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        migrate()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
        End If

        If Not IsPostBack Then
            InitialLoadData()
            channelload()
        End If
    End Sub


 
  

   
    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    For Each row As GridViewRow In tblepg.Rows
    '        Dim cb As CheckBox = CType(row.FindControl("chkselect"), CheckBox)

    '        If cb.Checked Then
    '            Dim id As Integer = Convert.ToInt32(tblepg.DataKeys(row.RowIndex).Value)
    '            MsgBox(String.Format("This would have deleted id", id))
    '        End If
    '    Next

    'End Sub
End Class
