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

    'Private Sub epgentry()
    '    Try


    '        Dim strtdt As DateTime
    '        strtdt = txtstarttime.Text.ToString("HH:mm")
    '        Dim endtime As DateTime
    '        endtime = DateAdd(DateInterval.Minute, Val(txtduration.Text), strtdt)

    '        Dim da As New OdbcDataAdapter("select * from epg_schedule where to_char(start_time::time,'HH24:MI')='" & strtdt.ToString & "' and channelname='" & ddlchname.SelectedItem.Text.ToString & "' and action_time::date='" & txtstartdate.Text & "'", dbcon.con)
    '        Dim ds As New DataSet
    '        da.Fill(ds)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            msgct2.InnerHtml = gcdsgn.alertmsg("Program Already Entered", "error")
    '        Else
    '            Dim cmd As New OdbcCommand
    '            dbcon.con.Open()
    '            cmd.Connection = dbcon.con
    '            cmd.CommandText = "INSERT INTO epg_schedule(action_time,cid,channelname,start_time,end_time,eventid,eventname,event_description,event_short_desc,userid,duration) values(?,?,?,?,?,?,?,?,?,?,?)"
    '            cmd.Parameters.AddWithValue("@action_time", txtstartdate.Text)
    '            cmd.Parameters.AddWithValue("@cid", ddlchname.SelectedValue.ToString)
    '            cmd.Parameters.AddWithValue("@channelname", ddlchname.SelectedItem.ToString)
    '            cmd.Parameters.AddWithValue("@start_time", txtstartdate.Text + " " + strtdt.ToString)
    '            cmd.Parameters.AddWithValue("@end_time", txtstartdate.Text + " " + endtime.ToString)
    '            cmd.Parameters.AddWithValue("@eventid", "0")
    '            cmd.Parameters.AddWithValue("@eventname", txtprgname.Text)
    '            cmd.Parameters.AddWithValue("@event_description", txtdesc.Text)
    '            cmd.Parameters.AddWithValue("@event_short_desc", txtshtdesc.Text)
    '            cmd.Parameters.AddWithValue("@userid", Session("uid"))
    '            cmd.Parameters.AddWithValue("@duration", Val(txtduration.Text))
    '            cmd.ExecuteNonQuery()
    '            cmd.Parameters.Clear()


    '            msgct2.InnerHtml = gcdsgn.alertmsg("Program Entry Successfull", "success")
    '            txtstarttime.Text = ""
    '            txtduration.Text = ""
    '            txtprgname.Text = ""
    '            txtshtdesc.Text = ""
    '            txtdesc.Text = ""
    '        End If
    '    Catch ex As Exception
    '        msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
    '    Finally

    '        dbcon.con.Close()

    '    End Try
    '    showdata()

    'End Sub

    Public Sub showdata()
        If txtstartdate.Text = "" Then
            Dim da As New OdbcDataAdapter("select start_time,duration,eventname,event_short_desc,event_description,end_time,id from epg_schedule where channelname='" & ddlchname.SelectedItem.Text.ToString & "' order by id asc", dbcon.con)
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
            Dim da As New OdbcDataAdapter("select start_time,duration,eventname,event_short_desc,event_description,end_time,id from epg_schedule where channelname='" & ddlchname.SelectedItem.Text.ToString & "' and start_time::date='" & txtstartdate.Text & "' order by id asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        End If

    End Sub

    Private Function GetStartTime(ByVal channelname As String) As DateTime
        Dim dt As DateTime = Now

        Dim da As New OdbcDataAdapter("select end_time from epg_schedule where start_time=(select max(start_time) from epg_schedule where channelname='" & channelname & "')", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            dt = CDate(ds.Tables(0).Rows(0).Item("end_time"))

        Else

            dt = Now

        End If
        If dt.Year = Now.Year And dt.Month = Now.Month And dt.Day = Now.Day Then
            Dim curminute As Integer = Now.Minute
            If Now.Minute > 30 Then curminute = 30
            If Now.Minute <= 30 Then curminute = 30
            dt = New DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, curminute, 0)
        Else
            dt = dt

        End If

        Return dt

    End Function


    Private Sub BlankSlotentry(ByVal tdays As Integer, ByVal slots As Integer)
        Try

            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            Dim curminute As Integer = Now.Minute
            If Now.Minute > 30 Then curminute = 30
            If Now.Minute <= 30 Then curminute = 30

            Dim starttime As DateTime = CDate(GetStartTime(ddlchname.SelectedItem.Text.ToString)) ' DateAdd(DateInterval.Day, Val(txtafterday.Text.ToString), Now) ' New DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, curminute, 0)

            'starttime = New DateTime(starttime.Year, starttime.Month, starttime.Day, starttime.Hour, curminute, 0)
            Dim endtime As DateTime = DateAdd(DateInterval.Day, Val(tdays), CDate(starttime)) 'DateAdd(DateInterval.Day, Val(tdays), Now)
            Dim sendtime As DateTime = DateAdd(DateInterval.Minute, Val(slots), starttime)

            endtime = New DateTime(endtime.Year, endtime.Month, endtime.Day, 23, 59, 59)
            'MsgBox(endtime)
            'MsgBox(starttime)
            Do
                'For i As Integer = 0 To 100


                'starttime = DateAdd(DateInterval.Minute, Val(slots), starttime)
                'sendtime = DateAdd(DateInterval.Minute, Val(slots), starttime)

                cmd.CommandText = "select id from epg_schedule where start_time between '" & starttime & "' and '" & endtime & "' and channelname='" & ddlchname.SelectedItem.Text.ToString & "' limit 1"

                If cmd.ExecuteScalar Is Nothing Then

                    cmd.CommandText = "INSERT INTO epg_schedule(action_time,cid,channelname,start_time,end_time,eventid,eventname,event_description,event_short_desc,DURATION) values(?,?,?,?,?,?,?,?,?,?)"
                    cmd.Parameters.AddWithValue("@action_time", Now.ToString("yyyy-MM-dd HH':'mm':'ss"))
                    cmd.Parameters.AddWithValue("@cid", ddlchname.SelectedValue.ToString)
                    cmd.Parameters.AddWithValue("@channelname", ddlchname.SelectedItem.ToString)
                    cmd.Parameters.AddWithValue("@start_time", starttime.ToString("yyyy-MM-dd HH':'mm':'ss"))
                    cmd.Parameters.AddWithValue("@end_time", sendtime.ToString("yyyy-MM-dd HH':'mm':'ss"))
                    cmd.Parameters.AddWithValue("@eventid", "0")
                    cmd.Parameters.AddWithValue("@eventname", "program")
                    cmd.Parameters.AddWithValue("@event_description", "program")
                    cmd.Parameters.AddWithValue("@event_short_desc", "program")
                    cmd.Parameters.AddWithValue("@duration", slots)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()

                Else
                    msgct1.InnerHtml = gcdsgn.alertmsg("Slots already generated previous within this time range.", "info")

                    Exit Try
                    Exit Sub


                End If
                ' ''cmd.CommandText = "SELECT count(id)+1 from epg_schedule"
                ' ''Dim nxtid As Double = 0
                ' ''nxtid = cmd.ExecuteScalar

                ' ''cmd.CommandText = "SELECT setval('epg_id_seq', " & nxtid & ", true);"
                ' ''cmd.ExecuteNonQuery()
                ' ''cmd.Parameters.Clear()

                'Next

                starttime = DateAdd(DateInterval.Minute, Val(slots), starttime)
                sendtime = DateAdd(DateInterval.Minute, Val(slots), starttime)

            Loop Until starttime > endtime

            msgct1.InnerHtml = gcdsgn.alertmsg("Program Entry Successfull", "success")


        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally

            dbcon.con.Close()

        End Try
        'showdata()

    End Sub
    Private Sub InitialLoadData()
        Dim da As New OdbcDataAdapter("select distinct genere from epglist order by genere asc", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ddlgenere.DataSource = ds.Tables(0)
            ddlgenere.DataTextField = "genere"
            ddlgenere.DataBind()

        End If
    End Sub

    Public Sub chload()
        Dim da As New OdbcDataAdapter("SELECT channel,id FROM epglist where genere='" & ddlgenere.SelectedItem.Text.ToString & "' order by channel asc", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddlchname.DataSource = dt
            ddlchname.DataTextField = "channel"
            ddlchname.DataValueField = "id"
            ddlchname.DataBind()
        End If
    End Sub


    

    Protected Sub tblepg_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles tblepg.RowDeleting
        Dim row As GridViewRow = tblepg.Rows(e.RowIndex)
        Dim id As Integer = Convert.ToInt32(tblepg.DataKeys(e.RowIndex).Values(0))
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "delete from epg_schedule where id='" & id & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        tblepg.EditIndex = -1
        showdata()
        msgct2.InnerHtml = gcdsgn.alertmsg("Delete Successfull", "success")
    End Sub

    Protected Sub tblepg_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles tblepg.RowEditing
        tblepg.EditIndex = e.NewEditIndex
    

        showdata()

    End Sub

    Protected Sub tblepg_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles tblepg.RowCancelingEdit
        tblepg.EditIndex = -1
        showdata()
    End Sub

    Protected Sub tblepg_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles tblepg.RowUpdating


        Dim row As GridViewRow = tblepg.Rows(e.RowIndex)
        'Dim id As Double = Convert.ToInt32(tblepg.DataKeys(e.RowIndex).Values(0))
        'Dim PNAME As String = TryCast(row.Cells(2).FindControl("et1"), TextBox).Text
        'MsgBox(PNAME)
        'Dim shrtdesc As String = TryCast(row.Cells(4).Controls(0), TextBox).Text
        'Dim extdesc As String = TryCast(row.Cells(5).Controls(0), TextBox).Text
        'Dim strtime As DateTime = TryCast(row.Cells(1).Controls(0), TextBox).Text
        'Dim duration As Double = Val(TryCast(row.Cells(2).Controls(0), TextBox).Text)
        'Dim endtime As DateTime = DateAdd(DateInterval.Minute, duration, strtime)

        Dim id As Double = Convert.ToInt32(tblepg.DataKeys(e.RowIndex).Values(0))

        Dim progname As String = (TryCast(tblepg.Rows(e.RowIndex).FindControl("et1"), TextBox)).Text.ToString  'TryCast(row.Cells(3).Controls(0), TextBox).Text
        Dim shrtdesc As String = (TryCast(tblepg.Rows(e.RowIndex).FindControl("et2"), TextBox)).Text.ToString 'TryCast(row.Cells(4).Controls(0), TextBox).Text
        Dim extdesc As String = (TryCast(tblepg.Rows(e.RowIndex).FindControl("et3"), TextBox)).Text.ToString 'TryCast(row.Cells(5).Controls(0), TextBox).Text
        Dim strtime As DateTime = (TryCast(tblepg.Rows(e.RowIndex).FindControl("tstart"), TextBox)).Text.ToString 'TryCast(row.Cells(1).Controls(0), TextBox).Text
        Dim duration As Double = Val((TryCast(tblepg.Rows(e.RowIndex).FindControl("tduration"), TextBox)).Text.ToString) 'Val(TryCast(row.Cells(2).Controls(0), TextBox).Text)
        Dim endtime As DateTime = DateAdd(DateInterval.Minute, duration, strtime)


        If extdesc.Length >= 60 Then
            shrtdesc = extdesc.Substring(0, 60)
        Else
            shrtdesc = extdesc

        End If

        Dim cmd As New OdbcCommand
        Try


            dbcon.con.Open()
            cmd.Connection = dbcon.con


            cmd.CommandText = "SELECT concat(start_time,'|',duration,'|',end_time) from epg_schedule where id=" & id
            Dim st As String = cmd.ExecuteScalar

            Dim rstr() As String = st.Split("|")
            Dim oStart As DateTime = CDate(rstr(0).ToString)
            Dim oDuration As Double = Val(rstr(1).ToString)
            Dim oendtime As DateTime = CDate(rstr(2).ToString)

            ' '' '' ''Dim changeTime As Double = DateDiff(DateInterval.Minute, oStart, strtime, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
            ' '' '' ''Dim changeDuration As Double = duration - oDuration
            ' '' '' ''Dim TotalChange As Double = changeTime + changeDuration
            'MsgBox(changeDuration & "CTIME" & changeTime)


            ' CHECK IF UPDATE TAKE PLACE OR NOT
            cmd.CommandText = "select end_time from epg_schedule where id=( select max(id) from epg_schedule where id<" & id & " and channelname=(select channelname from epg_schedule where id=" & id & "))"
            If cmd.ExecuteScalar Is Nothing Then
            Else
                strtime = CDate(cmd.ExecuteScalar)
                endtime = DateAdd(DateInterval.Minute, duration, strtime)
            End If


            Dim changeTime As Double = DateDiff(DateInterval.Minute, oStart, strtime, Microsoft.VisualBasic.FirstDayOfWeek.Sunday)
            Dim changeDuration As Double = duration - oDuration
            Dim TotalChange As Double = changeTime + changeDuration



            ' END HERE



            cmd.CommandText = "update epg_schedule set eventname=?,event_short_desc=?,event_description=?,start_time=?,duration=?,end_time=?,userid=? where id=" & id
            cmd.Parameters.AddWithValue("@eventname", progname)
            cmd.Parameters.AddWithValue("@event_short_desc", shrtdesc)
            cmd.Parameters.AddWithValue("@event_description", extdesc)
            cmd.Parameters.AddWithValue("@start_time", strtime.ToString("yyyy-MM-dd HH':'mm':'ss"))
            cmd.Parameters.AddWithValue("@duration", duration)
            cmd.Parameters.AddWithValue("@end_time", endtime.ToString("yyyy-MM-dd HH':'mm':'ss"))
            cmd.Parameters.AddWithValue("@userid", Session("uid"))
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()


            MsgBox(progname)

            ' UPDATE next rows
            '

            'If oldstartdate <> strtime Then

            '    cmd.CommandText = "update epg_schedule set start_time=(start_time+ interval '" & starttimedif & " minute'),end_time=(end_time+ interval '" & durationdif + starttimedif & " minute') where id>" & id
            '    cmd.ExecuteNonQuery()
            'End If
            cmd.CommandText = "update epg_schedule set start_time=(start_time+ interval '" & TotalChange & " minute') where id>" & id & " and channelname='" & ddlchname.SelectedItem.Text.ToString & "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update epg_schedule set end_time=(start_time+ interval '1 minute' * duration) where id>" & id & " and channelname='" & ddlchname.SelectedItem.Text.ToString & "'"
            cmd.ExecuteNonQuery()




            'If oldstartdate = strtime Then

            '    If oldduration <> duration Then

            '        If durationdif < 0 Then
            '            cmd.CommandText = "update epg_schedule set start_time=(start_time+ interval '" & Math.Abs(durationdif) & " minute'),end_time=(end_time+ interval '" & Math.Abs(durationdif) & " minute') where id>" & id
            '            cmd.ExecuteNonQuery()
            '        Else
            '            cmd.CommandText = "update epg_schedule set start_time=(start_time+ interval '" & -durationdif & " minute'),end_time=(end_time+ interval '" & -durationdif & " minute') where id>" & id
            '            cmd.ExecuteNonQuery()
            '        End If


            '    End If
            'End If

            'If oldstartdate <> strtime And oldduration <> duration Then

            '    If durationdif < 0 Then

            '        cmd.CommandText = "update epg_schedule set start_time=(start_time+ interval '" & starttimedif & " minute'+ interval '" & Math.Abs(durationdif) & " minute'),end_time=(end_time+ interval '" & durationdif + starttimedif & " minute') where id>" & id
            '        cmd.ExecuteNonQuery()

            '    Else

            '        cmd.CommandText = "update epg_schedule set start_time=(start_time+ interval '" & starttimedif & " minute'- interval '" & -durationdif & " minute'),end_time=(end_time+ interval '" &  starttimedif -durationdif + & " minute') where id>" & id
            '        cmd.ExecuteNonQuery()

            '    End If
            'End If


            ' end here
            msgct2.InnerHtml = gcdsgn.alertmsg("Update Successfull", "success")
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try


        tblepg.EditIndex = -1
        showdata()

    End Sub

    Protected Sub btnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlock.Click
        'blockchannel()
        showdata()
        txtstartdate.Text = Now.ToString("yyyy-MM-dd")
    End Sub


    Protected Sub btnblankadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnblankadd.Click
        BlankSlotentry(Val(txtdayno.Text.ToString), Val(ddlduration.SelectedValue.ToString))
    End Sub





    Protected Sub ddlgenere_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlgenere.TextChanged
        Dim da As New OdbcDataAdapter("SELECT channel,id FROM epglist where status<>'Locked' and genere='" & ddlgenere.SelectedItem.Text.ToString & "' order by channel asc", dbcon.con)
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ddlchname.DataSource = dt
            ddlchname.DataTextField = "channel"
            ddlchname.DataValueField = "id"
            ddlchname.DataBind()
        End If
    End Sub

    Protected Sub txtstartdate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstartdate.Load
        If txtstartdate.Text <> "" Then
            Dim da As New OdbcDataAdapter("select start_time,duration,eventname,event_short_desc,event_description,end_time,id from epg_schedule where channelname='" & ddlchname.SelectedItem.Text.ToString & "' and start_time::date='" & txtstartdate.Text & "' order by id asc", dbcon.con)
            Dim dt As New DataSet
            da.Fill(dt)
            If dt.Tables(0).Rows.Count > 0 Then
                tblepg.DataSource = dt
                tblepg.DataBind()
            Else
                tblepg.DataSource = ""
                tblepg.DataBind()
            End If
        End If
    End Sub

    Protected Sub txtstartdate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstartdate.TextChanged
        Dim da As New OdbcDataAdapter("select start_time,duration,eventname,event_short_desc,event_description,end_time,id from epg_schedule where channelname='" & ddlchname.SelectedItem.Text.ToString & "' and start_time::date='" & txtstartdate.Text & "' order by id asc", dbcon.con)
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
        End If

        If Not IsPostBack Then
            InitialLoadData()
            chload()
        End If

        'tblepg.HeaderStyle.BackColor = Drawing.Color.Bisque
        'tblepg.HeaderStyle.ForeColor = Drawing.Color.White

    End Sub

End Class
