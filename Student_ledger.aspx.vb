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

    Private Function SetMedicaConsent() As String
        Dim str As String = ""

        If chkbxmedallergy.Checked = True Then
            str += "Allergy,"
        End If

        If chkbxmedasthma.Checked = True Then
            str += "Asthma,"
        End If

        If chkbxmeddiab.Checked = True Then
            str += "Diabetes,"
        End If

        If chkbxmedseidis.Checked = True Then
            str += "Seizure disorder (e.g. epilepsy),"
        End If

        If chkbxmedhearim.Checked = True Then
            str += "Hearing impairment,"
        End If

        If chkbxmedphydis.Checked = True Then
            str += "Physical disability,"
        End If

        If chkbxmedspch.Checked = True Then
            str += "Speech impairment,"
        End If

        If chkbxmedvisual.Checked = True Then
            str += "Visual impairment,"
        End If

        If chkbxmedintel.Checked = True Then
            str += "Intellectual/learning impairment (e.g. dyslexia),"
        End If

        If chkbxmedaqbrain.Checked = True Then
            str += "Acquired brain impairment,"
        End If

        If chkbxmedbehave.Checked = True Then
            str += "Mental health or behaviour issue (e.g. depression; ADHD),"
        End If

        str = str.Substring(0, str.Length - 1)
        Return str

    End Function

    Private Function GetMedicalConsent(ByVal medicaltext As String) As String
        Dim str As String = ""

        Dim lst() As String = medicaltext.Split(",")

        For i As Integer = 0 To lst.Count - 1
            If lst(i).ToString = "Allergy" Then
                chkbxmedallergy.Checked = True
            End If
            If lst(i).ToString = "Asthma" Then
                chkbxmedasthma.Checked = True
            End If
            If lst(i).ToString = "Diabetes" Then
                chkbxmeddiab.Checked = True
            End If
            If lst(i).ToString = "Seizure disorder (e.g. epilepsy)" Then
                chkbxmedseidis.Checked = True
            End If
            If lst(i).ToString = "Hearing impairment" Then
                chkbxmedhearim.Checked = True
            End If
            If lst(i).ToString = "Physical disability" Then
                chkbxmedphydis.Checked = True
            End If
            If lst(i).ToString = "Speech impairment" Then
                chkbxmedspch.Checked = True
            End If
            If lst(i).ToString = "Visual impairment" Then
                chkbxmedvisual.Checked = True
            End If
            If lst(i).ToString = "Intellectual/learning impairment (e.g. dyslexia)" Then
                chkbxmedintel.Checked = True
            End If
            If lst(i).ToString = "Acquired brain impairment" Then
                chkbxmedaqbrain.Checked = True
            End If
            If lst(i).ToString = "Mental health or behaviour issue (e.g. depression; ADHD)" Then
                chkbxmedbehave.Checked = True
            End If
        Next

        Return str

    End Function

    Public Sub studententry()

        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If


        Dim newsletter(2) As String
        If chkbxnewsletterphoto.Checked = True Then
            newsletter(0) = "True"
        Else
            newsletter(0) = "False"
        End If
        If chkbxnewsletterwork.Checked = True Then
            newsletter(1) = "True"
        Else
            newsletter(1) = "False"
        End If
        If chkbxnewslettername.Checked = True Then
            newsletter(2) = "True"
        Else
            newsletter(2) = "False"
        End If


        Dim yearbook(2) As String
        If chkbxyearbookphoto.Checked = True Then
            yearbook(0) = "True"
        Else
            yearbook(0) = "False"
        End If
        If chkbxyearbookwork.Checked = True Then
            yearbook(1) = "True"
        Else
            yearbook(1) = "False"
        End If
        If chkbxyearbookname.Checked = True Then
            yearbook(2) = "True"
        Else
            yearbook(2) = "False"
        End If


        Dim website(2) As String
        If chkbxwebsitephoto.Checked = True Then
            website(0) = "True"
        Else
            website(0) = "False"
        End If
        If chkbxwebsitework.Checked = True Then
            website(1) = "True"
        Else
            website(1) = "False"
        End If
        If chkbxwebsitename.Checked = True Then
            website(2) = "True"
        Else
            website(2) = "False"
        End If



        Dim ID As Double = 0

        Try
            Dim cmd As New OdbcCommand
            dbcon.con.Open()
            cmd.Connection = dbcon.con
            cmd.CommandText = "INSERT INTO student_ledger(reg_no,company_id,company_type_id,branch_code,franchisee_code,student_name,nickname,father_name,mother_name,dob,class,gender,blood_grp,stu_cast,stu_img_url,stud_adrs,stud_pin,stud_area,stud_state,stud_country,stud_idprf,stud_idprfno,stud_idprf_url,stud_phn,stud_mail,car_regno,social_status,grd1_name,grd1_relation,grd1_parenting,grd1_live_w_student,grd1_rcv_report,grd1_phn,grd1_altphn,grd1_mail,grd1_res_adrs,grd1_per_adrs,grd1_sec_edu,grd1_high_qual,grd1_occu,grd1_idprf,grd1_idprfno,grd1_idprf_url,grd2_name,grd2_relation,grd2_parenting,grd2_live_w_student,grd2_rcv_report,grd2_phn,grd2_altphn,grd2_mail,grd2_res_adrs,grd2_per_adrs,grd2_sec_edu,grd2_high_qual,grd2_occu,grd2_idprf,grd2_idprfno,grd2_idprf_url,sibling1_name,sibling1_dob,sibling2_name,sibling2_dob,emergency_contact1,emergency_contact1_reln,emergency_contact1_phn,emergency_contact1__alt_phn,emergency_contact2,emergency_contact2_reln,emergency_contact2_phn,emergency_contact2__alt_phn,medical_info,medical_info_other,medical_desc,newsletter_photo_work_name,yearbook_photo_work_name,website_photo_work_name,created_date,created_by,status,religion,nationality) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) RETURNING stud_id"

            cmd.Parameters.AddWithValue("@reg_no", "0")
            cmd.Parameters.AddWithValue("@company_id", Session("comid"))
            cmd.Parameters.AddWithValue("@company_type_id", Session("comtypeid"))
            cmd.Parameters.AddWithValue("@branch_code", Session("brcode"))
            cmd.Parameters.AddWithValue("@franchisee_code", Session("frcode"))
            cmd.Parameters.AddWithValue("@student_name", txtstudentname.Text.ToUpper)
            cmd.Parameters.AddWithValue("@nickname", txtnickname.Text)
            cmd.Parameters.AddWithValue("@father_name", txtfathername.Text.ToString.ToUpper)
            cmd.Parameters.AddWithValue("@mother_name", txtmothername.Text.ToString.ToUpper)
            cmd.Parameters.AddWithValue("@dob", txtdob.Text)
            cmd.Parameters.AddWithValue("@class", ddlclass.SelectedValue)
            cmd.Parameters.AddWithValue("@gender", rdblgender.SelectedValue)
            cmd.Parameters.AddWithValue("@blood_grp", ddlbloodgrp.SelectedValue)
            cmd.Parameters.AddWithValue("@stu_cast", txtcast.Text.ToUpper)
            cmd.Parameters.AddWithValue("@stu_img_url", DBNull.Value)
            cmd.Parameters.AddWithValue("@stud_adrs", txtaddress.Text)
            cmd.Parameters.AddWithValue("@stud_pin", Val(txtpin.Text))
            cmd.Parameters.AddWithValue("@stud_area", txtlocality.Text)
            cmd.Parameters.AddWithValue("@stud_state", txtstate.Text)
            cmd.Parameters.AddWithValue("@stud_country", country)
            cmd.Parameters.AddWithValue("@stud_idprf", ddlstudentidproof.SelectedValue)
            cmd.Parameters.AddWithValue("@stud_idprfno", txtstudentidprfno.Text)
            cmd.Parameters.AddWithValue("@stud_idprf_url", DBNull.Value)
            cmd.Parameters.AddWithValue("@stud_phn", Val(txtphnno.Text))
            cmd.Parameters.AddWithValue("@stud_mail", txtmail.Text)
            cmd.Parameters.AddWithValue("@car_regno", txtcarregno.Text)
            If chksstatus.Checked = True Then
                cmd.Parameters.AddWithValue("@social_status", "Independent")
            Else
                cmd.Parameters.AddWithValue("@social_status", DBNull.Value)
            End If
            cmd.Parameters.AddWithValue("@grd1_name", txtgrd1name.Text.ToUpper)
            cmd.Parameters.AddWithValue("@grd1_relation", txtgrd1reln.Text)
            If chkbxresponsiblegrd1.Checked = True Then
                cmd.Parameters.AddWithValue("@grd1_parenting", "True")
            Else
                cmd.Parameters.AddWithValue("@grd1_parenting", "False")
            End If
            If chkbxlivewstugrd1.Checked = True Then
                cmd.Parameters.AddWithValue("@grd1_live_w_student", "True")
            Else
                cmd.Parameters.AddWithValue("@grd1_live_w_student", "False")
            End If
            If chkbxreportgrd1.Checked = True Then
                cmd.Parameters.AddWithValue("@grd1_rcv_report", "True")
            Else
                cmd.Parameters.AddWithValue("@grd1_rcv_report", "False")
            End If
            cmd.Parameters.AddWithValue("@grd1_phn", Val(txtgrd1phn.Text))
            cmd.Parameters.AddWithValue("@grd1_altphn", Val(txtgrd1altphn.Text))
            cmd.Parameters.AddWithValue("@grd1_mail", txtgrd1mail.Text)
            If chkbxgrd1adrsstud.Checked = True Then
                cmd.Parameters.AddWithValue("@grd1_res_adrs", txtaddress.Text + "," + txtlocality.Text + "-" + Val(txtpin.Text).ToString + "," + txtstate.Text + "," + country)
                cmd.Parameters.AddWithValue("@grd1_per_adrs", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@grd1_res_adrs", txtgrd1adrs.Text)
                cmd.Parameters.AddWithValue("@grd1_per_adrs", txtgrd1peradrs.Text)
            End If
            cmd.Parameters.AddWithValue("@grd1_sec_edu", ddlgrd1secondary.SelectedValue)
            cmd.Parameters.AddWithValue("@grd1_high_qual", ddlgrd1qualification.SelectedValue)
            cmd.Parameters.AddWithValue("@grd1_occu", txtgrd1occu.Text)
            cmd.Parameters.AddWithValue("@grd1_idprf", ddlgrd1idprf.SelectedValue)
            cmd.Parameters.AddWithValue("@grd1_idprfno", txtgrd1idprfno.Text)
            cmd.Parameters.AddWithValue("@grd1_idprf_url", DBNull.Value)
            cmd.Parameters.AddWithValue("@grd2_name", txtgrd2name.Text.ToUpper)
            cmd.Parameters.AddWithValue("@grd2_relation", txtgrd2reln.Text)
            If chkbxresponsiblegrd2.Checked = True Then
                cmd.Parameters.AddWithValue("@grd2_parenting", "True")
            Else
                cmd.Parameters.AddWithValue("@grd2_parenting", "False")
            End If
            If chkbxlivewstugrd2.Checked = True Then
                cmd.Parameters.AddWithValue("@grd2_live_w_student", "True")
            Else
                cmd.Parameters.AddWithValue("@grd2_live_w_student", "False")
            End If
            If chkbxreportgrd2.Checked = True Then
                cmd.Parameters.AddWithValue("@grd2_rcv_report", "True")
            Else
                cmd.Parameters.AddWithValue("@grd2_rcv_report", "False")
            End If
            cmd.Parameters.AddWithValue("@grd2_phn", Val(txtgrd2phn.Text))
            cmd.Parameters.AddWithValue("@grd2_altphn", Val(txtgrd2altphn.Text))
            cmd.Parameters.AddWithValue("@grd2_mail", txtgrd2mail.Text)
            If chkbxgrd2adrsstud.Checked = True Then
                cmd.Parameters.AddWithValue("@grd2_adrs", txtaddress.Text + "," + txtlocality.Text + "-" + Val(txtpin.Text).ToString + "," + txtstate.Text + "," + country)
                cmd.Parameters.AddWithValue("@grd2_per_adrs", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@grd2_adrs", txtgrd2adrs.Text)
                cmd.Parameters.AddWithValue("@grd2_per_adrs", txtgrd2peradrs.Text)
            End If
            cmd.Parameters.AddWithValue("@grd2_sec_edu", ddlgrd2secondary.SelectedValue)
            cmd.Parameters.AddWithValue("@grd2_high_qual", ddlgrd2qualification.SelectedValue)
            cmd.Parameters.AddWithValue("@grd2_occu", txtgrd2occu.Text)
            cmd.Parameters.AddWithValue("@grd2_idprf", ddlgrd2idprf.SelectedValue)
            cmd.Parameters.AddWithValue("@grd2_idprfno", txtgrd2idprfno.Text)
            cmd.Parameters.AddWithValue("@grd2_idprf_url", DBNull.Value)
            cmd.Parameters.AddWithValue("@sibling1_name", txtsibling1name.Text)
            If txtsibling1dob.Text <> "" Then
                cmd.Parameters.AddWithValue("@sibling1_dob", txtsibling1dob.Text)
            Else
                cmd.Parameters.AddWithValue("@sibling1_dob", DBNull.Value)
            End If
            cmd.Parameters.AddWithValue("@sibling2_name", txtsibling2name.Text)
            If txtsibling2dob.Text <> "" Then
                cmd.Parameters.AddWithValue("@sibling2_dob", txtsibling2dob.Text)
            Else
                cmd.Parameters.AddWithValue("@sibling2_dob", DBNull.Value)
            End If
            If chkbxgrd1emccntct.Checked = True Then
                cmd.Parameters.AddWithValue("@emergency_contact1", txtgrd1name.Text.ToUpper)
                cmd.Parameters.AddWithValue("@emergency_contact1_reln", txtgrd1reln.Text)
                cmd.Parameters.AddWithValue("@emergency_contact1_phn", Val(txtgrd1phn.Text))
                cmd.Parameters.AddWithValue("@emergency_contact1__alt_phn", Val(txtgrd1altphn.Text))
            Else
                cmd.Parameters.AddWithValue("@emergency_contact1", txtemgc1name.Text.ToUpper)
                cmd.Parameters.AddWithValue("@emergency_contact1_reln", txtemgc1reln.Text)
                cmd.Parameters.AddWithValue("@emergency_contact1_phn", Val(txtemgc1phn.Text))
                cmd.Parameters.AddWithValue("@emergency_contact1__alt_phn", Val(txtemgc1altphn.Text))
            End If
            If chkbxgrd2emccntc.Checked = True Then
                cmd.Parameters.AddWithValue("@emergency_contact2", txtgrd2name.Text.ToUpper)
                cmd.Parameters.AddWithValue("@emergency_contact2_reln", txtgrd2reln.Text)
                cmd.Parameters.AddWithValue("@emergency_contact2_phn", Val(txtgrd2phn.Text))
                cmd.Parameters.AddWithValue("@emergency_contact2__alt_phn", Val(txtgrd2altphn.Text))
            Else
                cmd.Parameters.AddWithValue("@emergency_contact2", txtemgc2name.Text.ToUpper)
                cmd.Parameters.AddWithValue("@emergency_contact2_reln", txtemgc2reln.Text)
                cmd.Parameters.AddWithValue("@emergency_contact2_phn", Val(txtemgc2phn.Text))
                cmd.Parameters.AddWithValue("@emergency_contact2__alt_phn", Val(txtemgc2altphn.Text))
            End If
            cmd.Parameters.AddWithValue("@medical_info", SetMedicaConsent.ToString)
            If chkbxmedother.Checked = True Then
                cmd.Parameters.AddWithValue("@medical_info_other", txtmedother.Text)
            Else
                cmd.Parameters.AddWithValue("@medical_info_other", DBNull.Value)
            End If
            cmd.Parameters.AddWithValue("@medical_desc", txtmeddesc.Text)
            cmd.Parameters.AddWithValue("@newsletter_photo_work_name", String.Join(",", newsletter).ToString)
            cmd.Parameters.AddWithValue("@yearbook_photo_work_name", String.Join(",", yearbook).ToString)
            cmd.Parameters.AddWithValue("@website_photo_work_name", String.Join(",", website).ToString)
            cmd.Parameters.AddWithValue("@created_date", Now.ToString)
            cmd.Parameters.AddWithValue("@created_by", Session("uname"))
            cmd.Parameters.AddWithValue("@status", "Active")
            cmd.Parameters.AddWithValue("@religion", txtreligion.Text)
            cmd.Parameters.AddWithValue("@nationality", txtnationality.Text)

            ID = cmd.ExecuteScalar
            cmd.Parameters.Clear()

            cmd.CommandText = "UPDATE student_ledger SET reg_no=(SELECT max(reg_no)+1 from STUDENT_LEDGER where company_id=" & Session("comid") & ") WHERE stud_id=" & ID
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()


            msgct1.InnerHtml = gcdsgn.alertmsg("Student has been Saved", "success")
        Catch ex As Exception
            msgct1.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        Finally
            dbcon.con.Close()
        End Try
    End Sub


    Protected Sub btnsave_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.ServerClick
        Dim da As New OdbcDataAdapter("select * from student_ledger where student_name=upper('" & txtstudentname.Text & "') and dob='" & txtdob.Text & "' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            msgct1.InnerHtml = gcdsgn.alertmsg("Student already Exist", "error")
        Else
            studententry()
        End If

    End Sub

    Protected Sub chkbxsecondary_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxsecondary.ServerChange
        If chkbxsecondary.Checked = True Then
            divsecondarystudent.Visible = True
        Else
            divsecondarystudent.Visible = False
        End If
    End Sub

    Protected Sub rblcountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblcountry.SelectedIndexChanged
        If rblcountry.SelectedValue.ToString = "India" Then
            txtcountry.ReadOnly = True
        Else
            txtcountry.ReadOnly = False
        End If
    End Sub

    Protected Sub chkbxgrd1_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd1.ServerChange
        If chkbxgrd1.Checked = True Then
            divguardian1.Visible = True
        Else
            divguardian1.Visible = False
        End If
    End Sub

    Protected Sub chkbxgrd2_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd2.ServerChange
        If chkbxgrd2.Checked = True Then
            divguardian2.Visible = True
        Else
            divguardian2.Visible = False
        End If
    End Sub

    Protected Sub chkbxsibling_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxsibling.ServerChange
        If chkbxsibling.Checked = True Then
            divsibling.Visible = True
        Else
            divsibling.Visible = False
        End If
    End Sub

    Protected Sub chkbxgrd1emccntct_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd1emccntct.ServerChange
        If chkbxgrd1emccntct.Checked = True Then
            emc1.Visible = False
        Else
            emc1.Visible = True
        End If
    End Sub

    Protected Sub chkbxgrd2emccntc_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd2emccntc.ServerChange
        If chkbxgrd2emccntc.Checked = True Then
            emc2.Visible = False
        Else
            emc2.Visible = True
        End If
    End Sub

    Protected Sub chkbxmedinfo_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxmedinfo.ServerChange
        If chkbxmedinfo.Checked = True Then
            divmedinfo.Visible = True
        Else
            divmedinfo.Visible = False
        End If
    End Sub

    Protected Sub chkbxgrd1adrsstud_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd1adrsstud.ServerChange
        If chkbxgrd1adrsstud.Checked = True Then
            divgrd1resadrs.Visible = False
            divgrd1peradrs.Visible = False
        Else
            divgrd1resadrs.Visible = True
            divgrd1peradrs.Visible = True
        End If
    End Sub

    Protected Sub chkbxgrd1bginfo_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd1bginfo.ServerChange
        If chkbxgrd1bginfo.Checked = True Then
            divgrd1bginfo.Visible = True
        Else
            divgrd1bginfo.Visible = False
        End If
    End Sub

    Protected Sub chkbxgrd2adrsstud_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd2adrsstud.ServerChange
        If chkbxgrd2adrsstud.Checked = True Then
            divgrd2resadrs.Visible = False
            divgrd2peradrs.Visible = False
        Else
            divgrd2resadrs.Visible = True
            divgrd2peradrs.Visible = True
        End If
    End Sub

    Protected Sub chkbxgrd2bginfo_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxgrd2bginfo.ServerChange
        If chkbxgrd2bginfo.Checked = True Then
            divgrd2bginfo.Visible = True
        Else
            divgrd2bginfo.Visible = False
        End If
    End Sub

    Protected Sub chkbxmedother_ServerChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkbxmedother.ServerChange
        If chkbxmedother.Checked = True Then
            txtmedother.ReadOnly = False
        Else
            txtmedother.ReadOnly = True
        End If
    End Sub

    Protected Sub btnsearch_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.ServerClick
        Try
            If txtsearchname.Text = "" Then
                Dim da As New OdbcDataAdapter("SELECT reg_no,student_name,father_name,mother_name,dob,status FROM student_ledger where company_id='" & Session("comid") & "'and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True

            Else
                Dim da As New OdbcDataAdapter("SELECT reg_no,student_name,father_name,mother_name,dob,status FROM student_ledger where upper(student_name) like upper('%" & txtsearchname.Text & "%') and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
                Dim dt As New DataTable
                da.Fill(dt)
                grdvleddetails.DataSource = dt
                grdvleddetails.DataBind()
                grdvleddetails.Visible = True
            End If

        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try

    End Sub

    Public Sub updatefields()
        Dim da As New OdbcDataAdapter("SELECT * FROM student_ledger where reg_no='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        If ds.Tables(0).Rows(0).Item("student_name") IsNot DBNull.Value Then
            txtstudentname.Text = ds.Tables(0).Rows(0).Item("student_name")
        End If
        If ds.Tables(0).Rows(0).Item("nickname") IsNot DBNull.Value Then
            txtnickname.Text = ds.Tables(0).Rows(0).Item("nickname")
        End If
        If ds.Tables(0).Rows(0).Item("father_name") IsNot DBNull.Value Then
            txtfathername.Text = ds.Tables(0).Rows(0).Item("father_name")
        End If
        If ds.Tables(0).Rows(0).Item("mother_name") IsNot DBNull.Value Then
            txtmothername.Text = ds.Tables(0).Rows(0).Item("mother_name")
        End If
        If ds.Tables(0).Rows(0).Item("dob") IsNot DBNull.Value Then
            txtdob.Text = ds.Tables(0).Rows(0).Item("dob")
        End If
        If ds.Tables(0).Rows(0).Item("class") IsNot DBNull.Value Then
            ddlclass.SelectedValue = ds.Tables(0).Rows(0).Item("class")
        End If
        If ds.Tables(0).Rows(0).Item("gender") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("gender") = "Male" Then
                rdblgender.Text = "Male"
            ElseIf ds.Tables(0).Rows(0).Item("gender") = "Female" Then
                rdblgender.Text = "Female"
            Else
                rdblgender.Text = "Transgender"
            End If
        End If
        If ds.Tables(0).Rows(0).Item("blood_grp") IsNot DBNull.Value Then
            ddlbloodgrp.Text = ds.Tables(0).Rows(0).Item("blood_grp")
        End If
        If ds.Tables(0).Rows(0).Item("stu_cast") IsNot DBNull.Value Then
            txtcast.Text = ds.Tables(0).Rows(0).Item("stu_cast")
        End If
        If ds.Tables(0).Rows(0).Item("stud_adrs") IsNot DBNull.Value Then
            txtaddress.Text = ds.Tables(0).Rows(0).Item("stud_adrs")
        End If
        If ds.Tables(0).Rows(0).Item("stud_pin") IsNot DBNull.Value Then
            txtpin.Text = ds.Tables(0).Rows(0).Item("stud_pin")
        End If
        If ds.Tables(0).Rows(0).Item("stud_area") IsNot DBNull.Value Then
            txtlocality.Text = ds.Tables(0).Rows(0).Item("stud_area")
        End If
        If ds.Tables(0).Rows(0).Item("stud_state") IsNot DBNull.Value Then
            txtstate.Text = ds.Tables(0).Rows(0).Item("stud_state")
        End If
        If ds.Tables(0).Rows(0).Item("stud_country") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("stud_country") = "India" Then
                rblcountry.Text = "India"
            Else
                rblcountry.Text = "Other (*Please Specify)"
                txtcountry.Text = ds.Tables(0).Rows(0).Item("stud_country")
            End If
        End If
        If ds.Tables(0).Rows(0).Item("stud_idprf") IsNot DBNull.Value Then
            ddlstudentidproof.Text = ds.Tables(0).Rows(0).Item("stud_idprf")
        End If
        If ds.Tables(0).Rows(0).Item("stud_idprfno") IsNot DBNull.Value Then
            txtstudentidprfno.Text = ds.Tables(0).Rows(0).Item("stud_idprfno")
        End If
        If ds.Tables(0).Rows(0).Item("stud_phn") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("stud_phn") <> 0 Then
                chkbxsecondary.Checked = True
                divsecondarystudent.Visible = True
            End If
            txtphnno.Text = ds.Tables(0).Rows(0).Item("stud_phn")
        End If
        If ds.Tables(0).Rows(0).Item("stud_mail") IsNot DBNull.Value Then
            txtmail.Text = ds.Tables(0).Rows(0).Item("stud_mail")
        End If
        If ds.Tables(0).Rows(0).Item("car_regno") IsNot DBNull.Value Then
            txtcarregno.Text = ds.Tables(0).Rows(0).Item("car_regno")
        End If
        If ds.Tables(0).Rows(0).Item("social_status") IsNot DBNull.Value Then
            chksstatus.Checked = True
        Else
            chksstatus.Checked = False
        End If


        If ds.Tables(0).Rows(0).Item("grd1_name") IsNot DBNull.Value Then
            txtgrd1name.Text = ds.Tables(0).Rows(0).Item("grd1_name")
            If ds.Tables(0).Rows(0).Item("grd1_name") <> "" Then
                chkbxgrd1.Checked = True
                divguardian1.Visible = True
            Else
                chkbxgrd1.Checked = False
                divguardian1.Visible = False
            End If

        End If
        If ds.Tables(0).Rows(0).Item("grd1_relation") IsNot DBNull.Value Then
            txtgrd1reln.Text = ds.Tables(0).Rows(0).Item("grd1_relation")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_phn") IsNot DBNull.Value Then
            txtgrd1phn.Text = ds.Tables(0).Rows(0).Item("grd1_phn")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_altphn") IsNot DBNull.Value Then
            txtgrd1altphn.Text = ds.Tables(0).Rows(0).Item("grd1_altphn")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_mail") IsNot DBNull.Value Then
            txtgrd1mail.Text = ds.Tables(0).Rows(0).Item("grd1_mail")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_res_adrs") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd1_per_adrs") Is DBNull.Value Then
                chkbxgrd1adrsstud.Checked = True
                txtgrd1peradrs.Text = ""
            Else
                chkbxgrd1adrsstud.Checked = False
                divgrd1peradrs.Visible = True
                divgrd1resadrs.Visible = True
                txtgrd1peradrs.Text = ds.Tables(0).Rows(0).Item("grd1_per_adrs")
            End If
            txtgrd1adrs.Text = ds.Tables(0).Rows(0).Item("grd1_res_adrs")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_sec_edu") IsNot DBNull.Value Then
            ddlgrd1secondary.Text = ds.Tables(0).Rows(0).Item("grd1_sec_edu")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_high_qual") IsNot DBNull.Value Then
            ddlgrd1qualification.Text = ds.Tables(0).Rows(0).Item("grd1_high_qual")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_occu") IsNot DBNull.Value Then
            txtgrd1occu.Text = ds.Tables(0).Rows(0).Item("grd1_occu")
            If ds.Tables(0).Rows(0).Item("grd1_occu") <> "" Then
                chkbxgrd1bginfo.Checked = True
                divgrd1bginfo.Visible = True
            End If
        End If
        If ds.Tables(0).Rows(0).Item("grd1_idprf") IsNot DBNull.Value Then
            ddlgrd1idprf.Text = ds.Tables(0).Rows(0).Item("grd1_idprf")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_idprfno") IsNot DBNull.Value Then
            txtgrd1idprfno.Text = ds.Tables(0).Rows(0).Item("grd1_idprfno")
        End If
        If ds.Tables(0).Rows(0).Item("grd1_parenting") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd1_parenting") = True Then
                chkbxresponsiblegrd1.Checked = True
            Else
                chkbxresponsiblegrd1.Checked = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item("grd1_live_w_student") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd1_live_w_student") = True Then
                chkbxlivewstugrd1.Checked = True
            Else
                chkbxlivewstugrd1.Checked = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item("grd1_rcv_report") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd1_rcv_report") = True Then
                chkbxreportgrd1.Checked = True
            Else
                chkbxreportgrd1.Checked = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact1") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("emergency_contact1") = ds.Tables(0).Rows(0).Item("grd1_name") Then
                chkbxgrd1emccntct.Checked = True
                emc1.Visible = False
            Else
                chkbxgrd1emccntct.Checked = False
                emc1.Visible = True
            End If
            txtemgc1name.Text = ds.Tables(0).Rows(0).Item("emergency_contact1")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact1_reln") IsNot DBNull.Value Then
            txtemgc1reln.Text = ds.Tables(0).Rows(0).Item("emergency_contact1_reln")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact1_phn") IsNot DBNull.Value Then
            txtemgc1phn.Text = ds.Tables(0).Rows(0).Item("emergency_contact1_phn")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact1__alt_phn") IsNot DBNull.Value Then
            txtemgc1altphn.Text = ds.Tables(0).Rows(0).Item("emergency_contact1__alt_phn")
        End If


        If ds.Tables(0).Rows(0).Item("grd2_name") IsNot DBNull.Value Then
            txtgrd2name.Text = ds.Tables(0).Rows(0).Item("grd2_name")
            If ds.Tables(0).Rows(0).Item("grd2_name") <> "" Then
                chkbxgrd2.Checked = True
                divguardian2.Visible = True
            Else
                chkbxgrd2.Checked = False
                divguardian2.Visible = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item("grd2_relation") IsNot DBNull.Value Then
            txtgrd2reln.Text = ds.Tables(0).Rows(0).Item("grd2_relation")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_phn") IsNot DBNull.Value Then
            txtgrd2phn.Text = ds.Tables(0).Rows(0).Item("grd2_phn")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_altphn") IsNot DBNull.Value Then
            txtgrd2altphn.Text = ds.Tables(0).Rows(0).Item("grd2_altphn")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_mail") IsNot DBNull.Value Then
            txtgrd2mail.Text = ds.Tables(0).Rows(0).Item("grd2_mail")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_res_adrs") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd2_per_adrs") Is DBNull.Value Then
                chkbxgrd2adrsstud.Checked = True
                txtgrd2peradrs.Text = ""
            Else
                chkbxgrd2adrsstud.Checked = False
                divgrd2peradrs.Visible = True
                divgrd2resadrs.Visible = True
                txtgrd2peradrs.Text = ds.Tables(0).Rows(0).Item("grd2_per_adrs")
            End If
            txtgrd2adrs.Text = ds.Tables(0).Rows(0).Item("grd2_res_adrs")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_sec_edu") IsNot DBNull.Value Then
            ddlgrd2secondary.Text = ds.Tables(0).Rows(0).Item("grd2_sec_edu")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_high_qual") IsNot DBNull.Value Then
            ddlgrd2qualification.Text = ds.Tables(0).Rows(0).Item("grd2_high_qual")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_occu") IsNot DBNull.Value Then
            txtgrd2occu.Text = ds.Tables(0).Rows(0).Item("grd2_occu")
            If ds.Tables(0).Rows(0).Item("grd2_occu") <> "" Then
                chkbxgrd2bginfo.Checked = True
                divgrd2bginfo.Visible = True
            End If
        End If
        If ds.Tables(0).Rows(0).Item("grd2_idprf") IsNot DBNull.Value Then
            ddlgrd2idprf.Text = ds.Tables(0).Rows(0).Item("grd2_idprf")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_idprfno") IsNot DBNull.Value Then
            txtgrd2idprfno.Text = ds.Tables(0).Rows(0).Item("grd2_idprfno")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_parenting") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd2_parenting") = True Then
                chkbxresponsiblegrd2.Checked = True
            Else
                chkbxresponsiblegrd2.Checked = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item("grd2_live_w_student") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd2_live_w_student") = True Then
                chkbxlivewstugrd2.Checked = True
            Else
                chkbxlivewstugrd2.Checked = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item("grd2_rcv_report") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("grd2_rcv_report") = True Then
                chkbxreportgrd2.Checked = True
            Else
                chkbxreportgrd2.Checked = False
            End If
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact2") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("emergency_contact2") = ds.Tables(0).Rows(0).Item("grd2_name") Then
                chkbxgrd2emccntc.Checked = True
                emc2.Visible = False
            Else
                chkbxgrd2emccntc.Checked = False
                emc2.Visible = True
            End If
            txtemgc2name.Text = ds.Tables(0).Rows(0).Item("emergency_contact2")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact2_reln") IsNot DBNull.Value Then
            txtemgc2reln.Text = ds.Tables(0).Rows(0).Item("emergency_contact2_reln")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact2_phn") IsNot DBNull.Value Then
            txtemgc2phn.Text = ds.Tables(0).Rows(0).Item("emergency_contact2_phn")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact2__alt_phn") IsNot DBNull.Value Then
            txtemgc2altphn.Text = ds.Tables(0).Rows(0).Item("emergency_contact2__alt_phn")
        End If

        If ds.Tables(0).Rows(0).Item("sibling1_name") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("sibling1_name") <> "" Then
                chkbxsibling.Checked = True
                divsibling.Visible = True
            Else
                chkbxsibling.Checked = False
                divsibling.Visible = False
            End If
            txtsibling1name.Text = ds.Tables(0).Rows(0).Item("sibling1_name")
        End If
        If ds.Tables(0).Rows(0).Item("sibling1_dob") IsNot DBNull.Value Then
            txtsibling1dob.Text = ds.Tables(0).Rows(0).Item("sibling1_dob")
        End If
        If ds.Tables(0).Rows(0).Item("sibling2_name") IsNot DBNull.Value Then
            txtsibling2name.Text = ds.Tables(0).Rows(0).Item("sibling2_name")
        End If
        If ds.Tables(0).Rows(0).Item("sibling2_dob") IsNot DBNull.Value Then
            txtsibling2dob.Text = ds.Tables(0).Rows(0).Item("sibling2_dob")
        End If
        If ds.Tables(0).Rows(0).Item("medical_info") IsNot DBNull.Value Then
            chkbxmedinfo.Checked = True
            divmedinfo.Visible = True
            GetMedicalConsent(ds.Tables(0).Rows(0).Item("medical_info").ToString)
        End If
        If ds.Tables(0).Rows(0).Item("medical_info_other") IsNot DBNull.Value Then
            chkbxmedother.Checked = True
            txtmedother.ReadOnly = False
            txtmedother.Text = ds.Tables(0).Rows(0).Item("medical_info_other")
        End If
        If ds.Tables(0).Rows(0).Item("medical_desc") IsNot DBNull.Value Then
            txtmeddesc.Text = ds.Tables(0).Rows(0).Item("medical_desc")
        End If

        If ds.Tables(0).Rows(0).Item("newsletter_photo_work_name") IsNot DBNull.Value Then
            Dim newsletter As String() = ds.Tables(0).Rows(0).Item("newsletter_photo_work_name").Split(",")
            If newsletter(0).ToString = "True" Then
                chkbxnewsletterphoto.Checked = True
            Else
                chkbxnewsletterphoto.Checked = False
            End If
            If newsletter(1).ToString = "True" Then
                chkbxnewsletterwork.Checked = True
            Else
                chkbxnewsletterwork.Checked = False
            End If
            If newsletter(2).ToString = "True" Then
                chkbxnewslettername.Checked = True
            Else
                chkbxnewslettername.Checked = False
            End If
        End If


        If ds.Tables(0).Rows(0).Item("yearbook_photo_work_name") IsNot DBNull.Value Then
            Dim yearbook As String() = ds.Tables(0).Rows(0).Item("yearbook_photo_work_name").Split(",")
            If yearbook(0).ToString = "True" Then
                chkbxyearbookphoto.Checked = True
            Else
                chkbxyearbookphoto.Checked = False
            End If
            If yearbook(1).ToString = "True" Then
                chkbxyearbookwork.Checked = True
            Else
                chkbxyearbookwork.Checked = False
            End If
            If yearbook(2).ToString = "True" Then
                chkbxyearbookname.Checked = True
            Else
                chkbxyearbookname.Checked = False
            End If
        End If


        If ds.Tables(0).Rows(0).Item("website_photo_work_name") IsNot DBNull.Value Then
            Dim website As String() = ds.Tables(0).Rows(0).Item("website_photo_work_name").Split(",")
            If website(0).ToString = "True" Then
                chkbxwebsitephoto.Checked = True
            Else
                chkbxwebsitephoto.Checked = False
            End If
            If website(1).ToString = "True" Then
                chkbxwebsitework.Checked = True
            Else
                chkbxwebsitework.Checked = False
            End If
            If website(2).ToString = "True" Then
                chkbxwebsitename.Checked = True
            Else
                chkbxwebsitename.Checked = False
            End If
        End If
        txtreligion.Text = ds.Tables(0).Rows(0).Item("religion")
        txtnationality.Text = ds.Tables(0).Rows(0).Item("nationality")

        If ds.Tables(0).Rows(0).Item("status") IsNot DBNull.Value Then
            If ds.Tables(0).Rows(0).Item("status") <> "Inactive" Then
                ddlstatus.Text = ds.Tables(0).Rows(0).Item("status")
            End If
        End If



    End Sub

    Protected Sub btnupdateinfo_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdateinfo.ServerClick
        Try
            If txtsearchname.Text <> "" Then
                Dim da As New OdbcDataAdapter("SELECT reg_no,student_name,father_name,mother_name,dob,status FROM student_ledger where reg_no='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "' and status<>'Inactive'", dbcon.con)
                Dim ds As New DataSet
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    grdvleddetails.DataSource = ds
                    grdvleddetails.DataBind()
                    grdvleddetails.Visible = True
                    updatefields()
                    txtsearchname.ReadOnly = True
                    btnsave.Visible = False
                    btnupdate.Visible = True
                    btndelete.Visible = True
                    divstatus.Visible = True
                Else
                    grdvleddetails.DataSource = Nothing
                    grdvleddetails.DataBind()
                    msgct2.InnerHtml = gcdsgn.alertmsg("Wrong Student ID", "error")
                End If
            Else
                grdvleddetails.DataSource = Nothing
                grdvleddetails.DataBind()
                msgct2.InnerHtml = gcdsgn.alertmsg("Please Enter Student ID", "error")
            End If
        Catch ex As Exception
            msgct2.InnerHtml = gcdsgn.alertmsg(ex.Message, "info")
        End Try
    End Sub

    Private Sub stupdateinfo()

        Dim country As String = ""
        If rblcountry.SelectedValue.ToString = "India" Then
            country = "India"
        Else
            country = txtcountry.Text.ToString
        End If


        Dim newsletter(2) As String
        If chkbxnewsletterphoto.Checked = True Then
            newsletter(0) = "True"
        Else
            newsletter(0) = "False"
        End If
        If chkbxnewsletterwork.Checked = True Then
            newsletter(1) = "True"
        Else
            newsletter(1) = "False"
        End If
        If chkbxnewslettername.Checked = True Then
            newsletter(2) = "True"
        Else
            newsletter(2) = "False"
        End If


        Dim yearbook(2) As String
        If chkbxyearbookphoto.Checked = True Then
            yearbook(0) = "True"
        Else
            yearbook(0) = "False"
        End If
        If chkbxyearbookwork.Checked = True Then
            yearbook(1) = "True"
        Else
            yearbook(1) = "False"
        End If
        If chkbxyearbookname.Checked = True Then
            yearbook(2) = "True"
        Else
            yearbook(2) = "False"
        End If


        Dim website(2) As String
        If chkbxwebsitephoto.Checked = True Then
            website(0) = "True"
        Else
            website(0) = "False"
        End If
        If chkbxwebsitework.Checked = True Then
            website(1) = "True"
        Else
            website(1) = "False"
        End If
        If chkbxwebsitename.Checked = True Then
            website(2) = "True"
        Else
            website(2) = "False"
        End If

        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update student_ledger set student_name=?,nickname=?,father_name=?,mother_name=?,dob=?,class=?,gender=?,blood_grp=?,stu_cast=?,stu_img_url=?,stud_adrs=?,stud_pin=?,stud_area=?,stud_state=?,stud_country=?,stud_idprf=?,stud_idprfno=?,stud_idprf_url=?,stud_phn=?,stud_mail=?,car_regno=?,social_status=?,grd1_name=?,grd1_relation=?,grd1_parenting=?,grd1_live_w_student=?,grd1_rcv_report=?,grd1_phn=?,grd1_altphn=?,grd1_mail=?,grd1_res_adrs=?,grd1_per_adrs=?,grd1_sec_edu=?,grd1_high_qual=?,grd1_occu=?,grd1_idprf=?,grd1_idprfno=?,grd1_idprf_url=?,grd2_name=?,grd2_relation=?,grd2_parenting=?,grd2_live_w_student=?,grd2_rcv_report=?,grd2_phn=?,grd2_altphn=?,grd2_mail=?,grd2_res_adrs=?,grd2_per_adrs=?,grd2_sec_edu=?,grd2_high_qual=?,grd2_occu=?,grd2_idprf=?,grd2_idprfno=?,grd2_idprf_url=?,sibling1_name=?,sibling1_dob=?,sibling2_name=?,sibling2_dob=?,emergency_contact1=?,emergency_contact1_reln=?,emergency_contact1_phn=?,emergency_contact1__alt_phn=?,emergency_contact2=?,emergency_contact2_reln=?,emergency_contact2_phn=?,emergency_contact2__alt_phn=?,medical_info=?,medical_info_other=?,medical_desc=?,newsletter_photo_work_name=?,yearbook_photo_work_name=?,website_photo_work_name=?,modified_date=?,modified_by=?,status=?,religion=?,nationality=? where reg_no='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'"
        cmd.Parameters.AddWithValue("@student_name", txtstudentname.Text.ToUpper)
        cmd.Parameters.AddWithValue("@nickname", txtnickname.Text)
        cmd.Parameters.AddWithValue("@father_name", txtfathername.Text.ToString.ToUpper)
        cmd.Parameters.AddWithValue("@mother_name", txtmothername.Text.ToString.ToUpper)
        cmd.Parameters.AddWithValue("@dob", txtdob.Text)
        cmd.Parameters.AddWithValue("@class", ddlclass.SelectedValue)
        cmd.Parameters.AddWithValue("@gender", rdblgender.SelectedValue)
        cmd.Parameters.AddWithValue("@blood_grp", ddlbloodgrp.SelectedValue)
        cmd.Parameters.AddWithValue("@stu_cast", txtcast.Text.ToUpper)
        cmd.Parameters.AddWithValue("@stu_img_url", DBNull.Value)
        cmd.Parameters.AddWithValue("@stud_adrs", txtaddress.Text)
        cmd.Parameters.AddWithValue("@stud_pin", Val(txtpin.Text))
        cmd.Parameters.AddWithValue("@stud_area", txtlocality.Text)
        cmd.Parameters.AddWithValue("@stud_state", txtstate.Text)
        cmd.Parameters.AddWithValue("@stud_country", country)
        cmd.Parameters.AddWithValue("@stud_idprf", ddlstudentidproof.SelectedValue)
        cmd.Parameters.AddWithValue("@stud_idprfno", txtstudentidprfno.Text)
        cmd.Parameters.AddWithValue("@stud_idprf_url", DBNull.Value)
        cmd.Parameters.AddWithValue("@stud_phn", Val(txtphnno.Text))
        cmd.Parameters.AddWithValue("@stud_mail", txtmail.Text)
        cmd.Parameters.AddWithValue("@car_regno", txtcarregno.Text)
        If chksstatus.Checked = True Then
            cmd.Parameters.AddWithValue("@social_status", "Independent")
        Else
            cmd.Parameters.AddWithValue("@social_status", DBNull.Value)
        End If
        cmd.Parameters.AddWithValue("@grd1_name", txtgrd1name.Text.ToUpper)
        cmd.Parameters.AddWithValue("@grd1_relation", txtgrd1reln.Text)
        If chkbxresponsiblegrd1.Checked = True Then
            cmd.Parameters.AddWithValue("@grd1_parenting", "True")
        Else
            cmd.Parameters.AddWithValue("@grd1_parenting", "False")
        End If
        If chkbxlivewstugrd1.Checked = True Then
            cmd.Parameters.AddWithValue("@grd1_live_w_student", "True")
        Else
            cmd.Parameters.AddWithValue("@grd1_live_w_student", "False")
        End If
        If chkbxreportgrd1.Checked = True Then
            cmd.Parameters.AddWithValue("@grd1_rcv_report", "True")
        Else
            cmd.Parameters.AddWithValue("@grd1_rcv_report", "False")
        End If
        cmd.Parameters.AddWithValue("@grd1_phn", Val(txtgrd1phn.Text))
        cmd.Parameters.AddWithValue("@grd1_altphn", Val(txtgrd1altphn.Text))
        cmd.Parameters.AddWithValue("@grd1_mail", txtgrd1mail.Text)
        If chkbxgrd1adrsstud.Checked = True Then
            cmd.Parameters.AddWithValue("@grd1_res_adrs", txtaddress.Text + "," + txtlocality.Text + "-" + Val(txtpin.Text).ToString + "," + txtstate.Text + "," + country)
            cmd.Parameters.AddWithValue("@grd1_per_adrs", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@grd1_res_adrs", txtgrd1adrs.Text)
            cmd.Parameters.AddWithValue("@grd1_per_adrs", txtgrd1peradrs.Text)
        End If
        cmd.Parameters.AddWithValue("@grd1_sec_edu", ddlgrd1secondary.SelectedValue)
        cmd.Parameters.AddWithValue("@grd1_high_qual", ddlgrd1qualification.SelectedValue)
        cmd.Parameters.AddWithValue("@grd1_occu", txtgrd1occu.Text)
        cmd.Parameters.AddWithValue("@grd1_idprf", ddlgrd1idprf.SelectedValue)
        cmd.Parameters.AddWithValue("@grd1_idprfno", txtgrd1idprfno.Text)
        cmd.Parameters.AddWithValue("@grd1_idprf_url", DBNull.Value)
        cmd.Parameters.AddWithValue("@grd2_name", txtgrd2name.Text.ToUpper)
        cmd.Parameters.AddWithValue("@grd2_relation", txtgrd2reln.Text)
        If chkbxresponsiblegrd2.Checked = True Then
            cmd.Parameters.AddWithValue("@grd2_parenting", "True")
        Else
            cmd.Parameters.AddWithValue("@grd2_parenting", "False")
        End If
        If chkbxlivewstugrd2.Checked = True Then
            cmd.Parameters.AddWithValue("@grd2_live_w_student", "True")
        Else
            cmd.Parameters.AddWithValue("@grd2_live_w_student", "False")
        End If
        If chkbxreportgrd2.Checked = True Then
            cmd.Parameters.AddWithValue("@grd2_rcv_report", "True")
        Else
            cmd.Parameters.AddWithValue("@grd2_rcv_report", "False")
        End If
        cmd.Parameters.AddWithValue("@grd2_phn", Val(txtgrd2phn.Text))
        cmd.Parameters.AddWithValue("@grd2_altphn", Val(txtgrd2altphn.Text))
        cmd.Parameters.AddWithValue("@grd2_mail", txtgrd2mail.Text)
        If chkbxgrd2adrsstud.Checked = True Then
            cmd.Parameters.AddWithValue("@grd2_adrs", txtaddress.Text + "," + txtlocality.Text + "-" + Val(txtpin.Text).ToString + "," + txtstate.Text + "," + country)
            cmd.Parameters.AddWithValue("@grd2_per_adrs", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@grd2_adrs", txtgrd2adrs.Text)
            cmd.Parameters.AddWithValue("@grd2_per_adrs", txtgrd2peradrs.Text)
        End If
        cmd.Parameters.AddWithValue("@grd2_sec_edu", ddlgrd2secondary.SelectedValue)
        cmd.Parameters.AddWithValue("@grd2_high_qual", ddlgrd2qualification.SelectedValue)
        cmd.Parameters.AddWithValue("@grd2_occu", txtgrd2occu.Text)
        cmd.Parameters.AddWithValue("@grd2_idprf", ddlgrd2idprf.SelectedValue)
        cmd.Parameters.AddWithValue("@grd2_idprfno", txtgrd2idprfno.Text)
        cmd.Parameters.AddWithValue("@grd2_idprf_url", DBNull.Value)
        cmd.Parameters.AddWithValue("@sibling1_name", txtsibling1name.Text)
        If txtsibling1dob.Text <> "" Then
            cmd.Parameters.AddWithValue("@sibling1_dob", txtsibling1dob.Text)
        Else
            cmd.Parameters.AddWithValue("@sibling1_dob", DBNull.Value)
        End If
        cmd.Parameters.AddWithValue("@sibling2_name", txtsibling2name.Text)
        If txtsibling2dob.Text <> "" Then
            cmd.Parameters.AddWithValue("@sibling2_dob", txtsibling2dob.Text)
        Else
            cmd.Parameters.AddWithValue("@sibling2_dob", DBNull.Value)
        End If
        If chkbxgrd1emccntct.Checked = True Then
            cmd.Parameters.AddWithValue("@emergency_contact1", txtgrd1name.Text.ToUpper)
            cmd.Parameters.AddWithValue("@emergency_contact1_reln", txtgrd1reln.Text)
            cmd.Parameters.AddWithValue("@emergency_contact1_phn", Val(txtgrd1phn.Text))
            cmd.Parameters.AddWithValue("@emergency_contact1__alt_phn", Val(txtgrd1altphn.Text))
        Else
            cmd.Parameters.AddWithValue("@emergency_contact1", txtemgc1name.Text.ToUpper)
            cmd.Parameters.AddWithValue("@emergency_contact1_reln", txtemgc1reln.Text)
            cmd.Parameters.AddWithValue("@emergency_contact1_phn", Val(txtemgc1phn.Text))
            cmd.Parameters.AddWithValue("@emergency_contact1__alt_phn", Val(txtemgc1altphn.Text))
        End If
        If chkbxgrd2emccntc.Checked = True Then
            cmd.Parameters.AddWithValue("@emergency_contact2", txtgrd2name.Text.ToUpper)
            cmd.Parameters.AddWithValue("@emergency_contact2_reln", txtgrd2reln.Text)
            cmd.Parameters.AddWithValue("@emergency_contact2_phn", Val(txtgrd2phn.Text))
            cmd.Parameters.AddWithValue("@emergency_contact2__alt_phn", Val(txtgrd2altphn.Text))
        Else
            cmd.Parameters.AddWithValue("@emergency_contact2", txtemgc2name.Text.ToUpper)
            cmd.Parameters.AddWithValue("@emergency_contact2_reln", txtemgc2reln.Text)
            cmd.Parameters.AddWithValue("@emergency_contact2_phn", Val(txtemgc2phn.Text))
            cmd.Parameters.AddWithValue("@emergency_contact2__alt_phn", Val(txtemgc2altphn.Text))
        End If
        cmd.Parameters.AddWithValue("@medical_info", SetMedicaConsent.ToString)
        If chkbxmedother.Checked = True Then
            cmd.Parameters.AddWithValue("@medical_info_other", txtmedother.Text)
        Else
            cmd.Parameters.AddWithValue("@medical_info_other", DBNull.Value)
        End If
        cmd.Parameters.AddWithValue("@medical_desc", txtmeddesc.Text)
        cmd.Parameters.AddWithValue("@newsletter_photo_work_name", String.Join(",", newsletter).ToString)
        cmd.Parameters.AddWithValue("@yearbook_photo_work_name", String.Join(",", yearbook).ToString)
        cmd.Parameters.AddWithValue("@website_photo_work_name", String.Join(",", website).ToString)
        cmd.Parameters.AddWithValue("@modified_date", Now.ToString)
        cmd.Parameters.AddWithValue("@modified_by", Session("uname"))
        cmd.Parameters.AddWithValue("@status", ddlstatus.SelectedValue)
        cmd.Parameters.AddWithValue("@religion", txtreligion.Text)
        cmd.Parameters.AddWithValue("@nationality", txtnationality.Text)

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Information Updated Successfully", "success")

    End Sub


    Protected Sub btnupdate_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.ServerClick
        If txtsearchname.Text <> "" Then
            Dim da As New OdbcDataAdapter("select * from student_ledger where student_name=upper('" & txtstudentname.Text & "') and dob='" & txtdob.Text & "' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 1 Then
                msgct1.InnerHtml = gcdsgn.alertmsg("Student already Exist", "error")
            Else
                stupdateinfo()
                btnsave.Visible = True
                btnupdate.Visible = False
                btndelete.Visible = False
                divstatus.Visible = False
            End If
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Student ID to Update", "error")
        End If
    End Sub

    Private Sub deleteledger()
        Dim cmd As New OdbcCommand
        dbcon.con.Open()
        cmd.Connection = dbcon.con
        cmd.CommandText = "update student_ledger set status='Inactive' where reg_no='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'"
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        dbcon.con.Close()
        msgct1.InnerHtml = gcdsgn.alertmsg("Student Deleted Successfully", "success")
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsearchname.Text <> "" Then
            deleteledger()
            btnsave.Visible = True
            btnupdate.Visible = False
            btndelete.Visible = False
            divstatus.Visible = False
        Else
            msgct1.InnerHtml = gcdsgn.alertmsg("Enter Student ID to Delete", "error")
        End If
    End Sub
    Public Sub chkbxlbl()
        If chkbxsecondary.Checked Then
            lblchkbxsecondary.InnerText = "Yes"
        Else
            lblchkbxsecondary.InnerText = "No"
        End If


        If chkbxsibling.Checked Then
            lblchkbxsibling.InnerHtml = "Yes"
        Else
            lblchkbxsibling.InnerHtml = "No"
        End If


        If chkbxmedinfo.Checked Then
            lblchkbxmedinfo.InnerHtml = "Yes"
        Else
            lblchkbxmedinfo.InnerHtml = "No"
        End If


        If chkbxgrd1bginfo.Checked Then
            lblchkbxgrd1bginfo.InnerHtml = "Yes"
        Else
            lblchkbxgrd1bginfo.InnerHtml = "No"
        End If


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then

        End If

        If Me.IsPostBack = True Then
            msgct1.InnerText = ""
            msgct2.InnerText = ""
            valmsg.InnerText = ""
        End If
        chkbxlbl()
        grdvleddetails.HeaderStyle.BackColor = Drawing.Color.Blue
        grdvleddetails.HeaderStyle.ForeColor = Drawing.Color.White

    End Sub


    Protected Sub txtdob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdob.TextChanged
        Dim da As New OdbcDataAdapter("select * from student_ledger where student_name=upper('" & txtstudentname.Text & "') and dob='" & txtdob.Text & "' and company_id='" & Session("comid") & "' and status='Active'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            valmsg.InnerHtml = gcdsgn.validmsg("Student already exist", "error")
        Else
            valmsg.InnerHtml = gcdsgn.validmsg("Ok", "success")
        End If
    End Sub

    Private Function medinfo(ByVal medicaltext As String) As Boolean
        Dim allergy As Boolean = False
        Dim asthma As Boolean = False
        Dim diab As Boolean = False
        Dim seidis As Boolean = False
        Dim hearim As Boolean = False
        Dim phydis As Boolean = False
        Dim spch As Boolean = False
        Dim visual As Boolean = False
        Dim intel As Boolean = False
        Dim aqbrain As Boolean = False
        Dim behave As Boolean = False

        Dim lst() As String = medicaltext.Split(",")

        For i As Integer = 0 To lst.Count - 1
            If lst(i).ToString = "Allergy" Then
                allergy = True
            End If
            If lst(i).ToString = "Asthma" Then
                asthma = True
            End If
            If lst(i).ToString = "Diabetes" Then
                diab = True
            End If
            If lst(i).ToString = "Seizure disorder (e.g. epilepsy)" Then
                seidis = True
            End If
            If lst(i).ToString = "Hearing impairment" Then
                hearim = True
            End If
            If lst(i).ToString = "Physical disability" Then
                phydis = True
            End If
            If lst(i).ToString = "Speech impairment" Then
                spch = True
            End If
            If lst(i).ToString = "Visual impairment" Then
                visual = True
            End If
            If lst(i).ToString = "Intellectual/learning impairment (e.g. dyslexia)" Then
                intel = True
            End If
            If lst(i).ToString = "Acquired brain impairment" Then
                aqbrain = True
            End If
            If lst(i).ToString = "Mental health or behaviour issue (e.g. depression; ADHD)" Then
                behave = True
            End If
        Next

        Return allergy
        Return asthma
        Return diab
        Return seidis
        Return hearim
        Return phydis
        Return spch
        Return visual
        Return intel
        Return aqbrain
        Return behave
    End Function

    Public Function studentreg() As String
        Dim ss As StringBuilder = New StringBuilder()
        Dim htmltext As String
        Dim p As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")

        Dim da As New OdbcDataAdapter("SELECT * FROM student_ledger where reg_no='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)



        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 2px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")

        ''Header starts here

        ss.Append("<div style='width:100%;'>")

        ss.Append("<div style='width:30%;height:150px;float:left;'>")
        ss.Append("<div style='border:2px solid white;'><img src='" & p & "img/letterhead1.png'  alt='logo' width='150px' height='100px' border=0'></div>")
        ss.Append("</div>")

        ss.Append("<p>")
        ss.Append("<div style='width: 70%;border: 0px solid black;float: right;'>")
        ss.Append("<h2 align='center'>Student Registration Form</h2>")
        ss.Append("<p align='center'>Student Information System (SIS)</p>")
        ss.Append("<p>This form must be completed for all new students who are registering in <b>School Name</b> school</p>")
        ss.Append("</div>")
        ss.Append("</p>")
        ss.Append("</div>")

        ss.Append("<div class='clearfix'></div>")
        ss.Append("<div style='border: 2px solid black;'></div>")
        ''Header ends here

        ss.Append("<div class='clearfix'></div>")

        ''Body starts here

        ss.Append("<div>")
        ss.Append("<p>")
        ss.Append("<div style='width: 100%;'>")
        ss.Append("<p><b>Information and Privacy</b></br>")
        ss.Append("The school is committed to providing students with quality education services. The department needs to ask for personal information from students, parents and guardians so it can plan, provide and report on its services, and to monitor compliance under the Education Act. Personal information will only be disclosed for these purposes as permitted by the Information Act. The Privacy Statement attached is for your information. Please take the time to read this as it outlines in greater detail the use and disclosure of the information that you provide.</p>")
        ss.Append("</div>")
        ss.Append("</p>")
        ss.Append("</div>")

        ''office use table
        ss.Append("<div>")
        ss.Append("<table style='background-color:#d6dde9;width: 70%;float: left';border='1px black;height:250px;' class='table table-bordered table-secondary'>")
        ss.Append("<tr>")
        ss.Append("<td colspan='2'>")
        ss.Append("<h5><b>Office use only</b></h5></td></tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("Student UPN: </td>")
        ss.Append("<td></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("Academic Year: </td>")
        ss.Append("<td></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("Anticipated start date: </td>")
        ss.Append("<td></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("Enrolment status: </td>")
        ss.Append("<td></td>")
        ss.Append("</tr>")
        ss.Append("</table>")


        ss.Append("<div style='width: 30%; float: right;height:250px;align-items: center;justify-content: center;text-align:center;'>")
        ss.Append("<div style='border: 1px solid black;height: 210px; width: 80%;position: relative;margin: 15px auto;text-align:center;align-items: center;justify-content: center;'>")
        ss.Append("Please affix student photograph here")
        ss.Append("</div>")
        ss.Append("</div>")

        ss.Append("</div>")

        ss.Append("<div class='clearfix'></div>")

        ss.Append("<div>")
        ss.Append("<div style='width: 100%;'>")
        ss.Append("<p><b>If you need help completing this form, please contact your school</b></p>")
        ss.Append("</div>")
        ss.Append("</div>")



        ''Student Details table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<td colspan='2'>")
        ss.Append("<h5><b>SECTION I: Student Details</b></h5></td></tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Full Name : </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("student_name") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Has the student been known by any other names? </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("nickname") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Date of Birth: </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("dob") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Entrance Class: </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("class") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Gender: </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("gender") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Religion: </td>")
        ss.Append("<td></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Cast/Quota: </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("stu_cast") & "</td>")
        ss.Append("</tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Student’s residential address: </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("stud_adrs") & "," & ds.Tables(0).Rows(0).Item("stud_area") & "-" & ds.Tables(0).Rows(0).Item("stud_pin") & "," & ds.Tables(0).Rows(0).Item("stud_state") & "," & ds.Tables(0).Rows(0).Item("stud_country") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Nationality: </td>")
        ss.Append("<td></td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")

        ss.Append("</br>")

        ''Student id proof table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<td colspan='2'>")
        ss.Append("<h5><b>SECTION II: Student ID Proof Details</b></h5></td></tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("ID Proof Type : </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("stud_idprf") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("ID Proof Number : </td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("stud_idprfno") & "</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")

        ss.Append("</div>")
        ss.Append("</div>")         ''1st page ends


        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 2px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")

        ss.Append("<p></br></p>")
        ''Senior secondary student table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px solid black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<th colspan='2'>")
        ss.Append("<h5><b>SECTION III: For Senior Secondary Student Only</b></h5></th></tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;' rowspan=2>")
        ss.Append("Student’s contact details : </td>")
        If ds.Tables(0).Rows(0).Item("stud_phn") = 0 Then
            ss.Append("<td>Phone: </td>")
        Else
            ss.Append("<td>Phone: " & ds.Tables(0).Rows(0).Item("stud_phn") & "</td>")
        End If

        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td>Email: " & ds.Tables(0).Rows(0).Item("stud_mail") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Student’s car registration number: </br><span style='font-size:13px;font-style:italic;'>(if applicable)</span></td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("car_regno") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Is the student independent? </br><span style='font-size:13px;font-style:italic;'>(i.e. living without a parent/guardian)</span></td>")

        If ds.Tables(0).Rows(0).Item("social_status") IsNot DBNull.Value Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If


        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")

        ss.Append("<p></br></p>")

        ''Guardian table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px solid black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<th colspan='3'>")
        ss.Append("<h5><b>SECTION IV: Parent/Guardian Information</b></h5></th></tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("</td>")
        ss.Append("<td align='center'><b>Parent/guardian 1</b></td>")
        ss.Append("<td align='center'><b>Parent/guardian 2</b></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Full Name:</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_name") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_name") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Relationship to student:</br><span style='font-size:13px;font-style:italic;'>(e.g. father, grandmother)</span></td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_relation") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_relation") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Responsible for parenting:</td>")
        If ds.Tables(0).Rows(0).Item("grd1_parenting") = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If

        If ds.Tables(0).Rows(0).Item("grd2_parenting") = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Lives with student:</td>")

        If ds.Tables(0).Rows(0).Item("grd1_live_w_student") = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If

        If ds.Tables(0).Rows(0).Item("grd2_live_w_student") = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If

        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Receive reports etc:</td>")

        If ds.Tables(0).Rows(0).Item("grd1_rcv_report") = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If

        If ds.Tables(0).Rows(0).Item("grd2_rcv_report") = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If

        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Contact this person in an emergency?</td>")
        If ds.Tables(0).Rows(0).Item("emergency_contact1") = ds.Tables(0).Rows(0).Item("grd1_name") Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact2") = ds.Tables(0).Rows(0).Item("grd2_name") Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td>No</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Phone Number:</td>")
        If ds.Tables(0).Rows(0).Item("grd1_phn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_phn") & "</td>")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_phn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_phn") & "</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Alternate Phone Number:</td>")
        If ds.Tables(0).Rows(0).Item("grd1_altphn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_altphn") & "</td>")
        End If
        If ds.Tables(0).Rows(0).Item("grd2_altphn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_altphn") & "</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Email:</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_mail") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_mail") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Residential Address:</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_res_adrs") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_res_adrs") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Permanent Address: </br><span style='font-size:13px;font-style:italic;'>(If different from above)</span></td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_per_adrs") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_per_adrs") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("ID Proof Type:</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_idprf") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_idprf") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("ID Proof No.:</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_idprfno") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_idprfno") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("</table>")
        ss.Append("</div>")

        ss.Append("<p></br></p>")
        ss.Append("<p></br></p>")
        ss.Append("<p></br></p>")
        ss.Append("<p></br></p>")
        ss.Append("</br>")
        ss.Append("</br>")


        ss.Append("</div>")
        ss.Append("</div>")         ''2nd page ends here


        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 2px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")


        ss.Append("<p></br></p>")

        ''Guardian Background Table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<th colspan='2'>")
        ss.Append("<h5><b>SECTION V: Parent/Guardian Background Information</b></h5></th></tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan=2 style='background-color:#d6dde9;'>")
        ss.Append("What is the <b>Highest</b> Class of primary or secondary school the parent/guardian has completed?")
        ss.Append("</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td align='center'><b>Parent/guardian 1</b></td>")
        ss.Append("<td align='center'><b>Parent/guardian 2</b></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_sec_edu") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_sec_edu") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan=2 style='background-color:#d6dde9;'>")
        ss.Append("What is the level of the <b>Highest</b> qualification the parent/guardian has completed?")
        ss.Append("</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td align='center'><b>Parent/guardian 1</b></td>")
        ss.Append("<td align='center'><b>Parent/guardian 2</b></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_high_qual") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_high_qual") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan=2 style='background-color:#d6dde9;'>")
        ss.Append("What is the <b>Occupation</b> of the parent/guardian?")
        ss.Append("</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td align='center'><b>Parent/guardian 1</b></td>")
        ss.Append("<td align='center'><b>Parent/guardian 2</b></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd1_occu") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("grd2_occu") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan=2 style='background-color:#d6dde9;'>")
        ss.Append("What is the yearly <b>Gross Salary</b> of the parent/guardian?")
        ss.Append("</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td align='center'><b>Parent/guardian 1</b></td>")
        ss.Append("<td align='center'><b>Parent/guardian 2</b></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td>Amount</td>")
        ss.Append("<td>Amount</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")

        ss.Append("</br>")

        ''Sibling Table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px solid black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<th colspan='2'>")
        ss.Append("<h5><b>SECTION VI: Sibling Information</b></h5></th></tr>")
        ss.Append("<tr>")
        ss.Append("<td width='50%' style='background-color:#d6dde9;'>")
        ss.Append("Does the student have any brothers or sisters <b>at this school?</b></td>")
        If ds.Tables(0).Rows(0).Item("sibling1_name") <> "" Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Yes</b> </td>")
        Else
            ss.Append("<td>No</td>")
        End If

        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td align='center'><u>Sibling’s names</u></td>")
        ss.Append("<td align='center'><u>Date of Birth</u></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("sibling1_name") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("sibling1_dob") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("sibling2_name") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("sibling2_dob") & "</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")

        ss.Append("</br>")

        ''Additional emergency Table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px solid black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<th colspan='3'>")
        ss.Append("<h5><b>SECTION VII: Additional Emergency Contacts</b></h5></th></tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan=3>For an emergency where the parent/guardian cannot be contacted, please provide alternative contacts. For independent students this is the 1st point of contact in an emergency.</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("</td>")
        ss.Append("<td align='center'><b>Contact 1</b></td>")
        ss.Append("<td align='center'><b>Contact 2</b></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Full Name:</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact1") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact2") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Relationship: <span style='font-size:13px;font-style:italic;'>(e.g. aunt, friend)</span></td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact1_reln") & "</td>")
        ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact2_reln") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Phone Number:</td>")
        If ds.Tables(0).Rows(0).Item("emergency_contact1_phn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact1_phn") & "</td>")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact2_phn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact2_phn") & "</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("Alternate Phone Number:</td>")
        If ds.Tables(0).Rows(0).Item("emergency_contact1__alt_phn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact1__alt_phn") & "</td>")
        End If
        If ds.Tables(0).Rows(0).Item("emergency_contact2__alt_phn") = 0 Then
            ss.Append("<td></td>")
        Else
            ss.Append("<td>" & ds.Tables(0).Rows(0).Item("emergency_contact2__alt_phn") & "</td>")
        End If
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")


        ss.Append("<p></br></p>")
        ss.Append("</br>")

        ss.Append("</div>")
        ss.Append("</div>")             '' 3rd page ends here




        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 2px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")


        ss.Append("<p></br></p>")




        ''Medical details Table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<th colspan='3'>")
        ss.Append("<h5><b>SECTION VIII: Medical Details and Consent</b></h5></th></tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("Blood Group: </td>")
        ss.Append("<td colspan='2'>" & ds.Tables(0).Rows(0).Item("blood_grp") & "</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan='3' style='background-color:#d6dde9;'>")
        ss.Append("Does your child suffer from any of the following?")
        ss.Append("</td>")
        ss.Append("</tr>")



        Dim allergy As Boolean = False
        Dim asthma As Boolean = False
        Dim diab As Boolean = False
        Dim seidis As Boolean = False
        Dim hearim As Boolean = False
        Dim phydis As Boolean = False
        Dim spch As Boolean = False
        Dim visual As Boolean = False
        Dim intel As Boolean = False
        Dim aqbrain As Boolean = False
        Dim behave As Boolean = False

        Dim lst() As String = ds.Tables(0).Rows(0).Item("medical_info").ToString.Split(",")

        For i As Integer = 0 To lst.Count - 1
            If lst(i).ToString = "Allergy" Then
                allergy = True
            End If
            If lst(i).ToString = "Asthma" Then
                asthma = True
            End If
            If lst(i).ToString = "Diabetes" Then
                diab = True
            End If
            If lst(i).ToString = "Seizure disorder (e.g. epilepsy)" Then
                seidis = True
            End If
            If lst(i).ToString = "Hearing impairment" Then
                hearim = True
            End If
            If lst(i).ToString = "Physical disability" Then
                phydis = True
            End If
            If lst(i).ToString = "Speech impairment" Then
                spch = True
            End If
            If lst(i).ToString = "Visual impairment" Then
                visual = True
            End If
            If lst(i).ToString = "Intellectual/learning impairment (e.g. dyslexia)" Then
                intel = True
            End If
            If lst(i).ToString = "Acquired brain impairment" Then
                aqbrain = True
            End If
            If lst(i).ToString = "Mental health or behaviour issue (e.g. depression; ADHD)" Then
                behave = True
            End If
        Next


        ss.Append("<tr class='table-borderless'>")
        If allergy = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Allergies</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Allergies</td>")
        End If
        If asthma = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Asthma</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Asthma</td>")
        End If
        If diab = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Diabetes</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Diabetes</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr class='table-borderless'>")
        If seidis = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Seizure disorder (e.g. epilepsy)</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Seizure disorder (e.g. epilepsy)</td>")
        End If
        If hearim = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Hearing impairment</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Hearing impairment</td>")
        End If
        If phydis = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Physical disability</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Physical disability</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr class='table-borderless'>")
        If spch = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Speech impairment</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Speech impairment</td>")
        End If
        If visual = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Visual impairment</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Visual impairment</td>")
        End If
        If intel = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Intellectual/learning impairment (e.g. dyslexia)</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Intellectual/learning impairment (e.g. dyslexia)</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr class='table-borderless'>")
        If aqbrain = True Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Acquired brain impairment</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Acquired brain impairment</td>")
        End If
        If behave = True Then
            ss.Append("<td colspan='2'><i class='far fa-circle-check text-lg'></i> <b>Mental health or behaviour issue (e.g. depression, ADHD)</b></td>")
        Else
            ss.Append("<td colspan='2'><i class='far fa-circle'></i> Mental health or behaviour issue (e.g. depression, ADHD)</td>")
        End If
        ss.Append("</tr>")


        ss.Append("<tr class='table-borderless'>")
        If ds.Tables(0).Rows(0).Item("medical_info_other") IsNot DBNull.Value Then
            ss.Append("<td><i class='far fa-circle-check text-lg'></i> <b>Other, please specify</b></td>")
        Else
            ss.Append("<td><i class='far fa-circle'></i> Other, please specify</td>")
        End If
        ss.Append("<td colspan='2'><div style='height: 100px;'><b>" & ds.Tables(0).Rows(0).Item("medical_info_other") & "</b></div></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan='3' style='background-color:#d6dde9;'>")
        ss.Append("If the student has any of the issues above, please provide further information. Also provide details if the student has any special needs or requires support in school (including details of previous special needs assessments undertaken by a school etc).")
        ss.Append("</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan='3' height='200px'>Medical detailed description here: " & ds.Tables(0).Rows(0).Item("medical_desc") & "</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")


        ss.Append("<p></br></p>")

        ''Additional concents Table
        ss.Append("<div>")
        ss.Append("<table style='width: 100%;' border='1px solid black' class='table table-bordered'>")
        ss.Append("<tr>")
        ss.Append("<th colspan='4'>")
        ss.Append("<h5><b>SECTION IX: Additional Consents</b></h5></th></tr>")
        ss.Append("<tr>")
        ss.Append("<td colspan='4' style='background-color:#d6dde9;'><b>Consent for publication of a student’s Photo and Work</b></br>School may record sound and/or vision of a student and their work while they are at school or taking part in school related activities or performances. Photographs of students involved in activities, and work by students, are often published to enable the students to share their experiences and to enable parents and others to be informed about the school or college’s work. This does not mean that the student loses ownership of the works.</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%'>")
        ss.Append("</td>")
        ss.Append("<td align='center'><b>Use of Student Photograph </b></td>")
        ss.Append("<td align='center'><b>Use of Work by Student</b></td>")
        ss.Append("<td align='center'><b>Publishing Student Name</b></td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("<b>School/College Newsletter</b></td>")
        Dim newsletter As String() = ds.Tables(0).Rows(0).Item("newsletter_photo_work_name").Split(",")
        If newsletter(0).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        If newsletter(1).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        If newsletter(2).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("<b>School/College Yearbook</b></td>")
        Dim yearbook As String() = ds.Tables(0).Rows(0).Item("yearbook_photo_work_name").Split(",")
        If yearbook(0).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        If yearbook(1).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        If yearbook(2).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If

        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<tr>")
        ss.Append("<td width='40%' style='background-color:#d6dde9;'>")
        ss.Append("<b>School/College/Department Website</b></td>")
        Dim website As String() = ds.Tables(0).Rows(0).Item("website_photo_work_name").Split(",")
        If website(0).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        If website(1).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        If website(2).ToString = "True" Then
            ss.Append("<td align='center'><i class='far fa-circle-check text-lg'></i> <b>Yes</b></td>")
        Else
            ss.Append("<td align='center'>No</td>")
        End If
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("</table>")
        ss.Append("</div>")

        ss.Append("<p></br></p>")
        ss.Append("<p></br></p>")
        ss.Append("<p></br></p>")






        ss.Append("</div>")
        ss.Append("</div>")
        htmltext = ss.ToString
        Return htmltext
    End Function

    Public Function studentidformatone() As String
        Dim ss As StringBuilder = New StringBuilder()
        Dim htmltext As String
        Dim p As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")

        Dim da As New OdbcDataAdapter("SELECT * FROM student_ledger where reg_no='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)



        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div align='center' style='border: 0px solid black;width: 400px; height:300px;'>")
        ''Header starts here

        ss.Append("<div style='width:400px;;text-align: center;border: 0px solid black;padding:2px;height:30px;background-color: blue; color: white;'>")
        ss.Append("<b>IDENTITY CARD</b>")
        ss.Append("</div>")

        

        'ss.Append("<p>")
        'ss.Append("<div style='width: 70%;border: 0px solid black;float: right;'>")
        'ss.Append("<h2 align='center'>Student Registration Form</h2>")
        'ss.Append("<p align='center'>Student Information System (SIS)</p>")
        'ss.Append("<p>This form must be completed for all new students who are registering in <b>School Name</b> school</p>")
        'ss.Append("</div>")
        'ss.Append("</p>")
        ss.Append("<div class='clearfix'></div>")

        ss.Append("<div style='width: 400px;;text-align: center;border: 0px solid black'>")
        ss.Append("<div style='width:30%;height:50px;float:left;'>")
        ss.Append("<div style='border:0px solid white;'><img src='" & p & "img/letterhead1.png'  alt='logo' width='50px' height='60px' border=0'></div>")
        ss.Append("</div>")

        ss.Append("<div style='width:70%;height:60px;float:right;border:0px solid black;''>")
        ss.Append("<div>")
        ss.Append("<b>School Name</b></br>(Affilated to CBSE)")
        ss.Append("</div>")
        ss.Append("</div>")
        ss.Append("</div>")

        ss.Append("<div class='clearfix'></div>")

        ss.Append("<div style='width:400px;; height:90px; border: 0px solid black;'>")
        ss.Append("<table style='width:100%;' class='text-sm'>")
        ss.Append("<tr>")
        ss.Append("<td style='width:50%;padding-left: 4px;text-align:right;'>")
        ss.Append("Name: &emsp;</td>")
        ss.Append("<td style='width:60%;'>Souvik Roy</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td style='width:50%;padding-left: 4px;text-align:right;'>")
        ss.Append("Blood Group:  &emsp;</td>")
        ss.Append("<td style='width:60%;'>A Positive</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td style='width:50%;padding-left: 4px;text-align:right;'>")
        ss.Append("Class:  &emsp;</td>")
        ss.Append("<td style='width:60%;'>VIII</td>")
        ss.Append("</tr>")
        ss.Append("<tr>")
        ss.Append("<td style='width:50%;padding-left: 4px;text-align:right;'>")
        ss.Append("Validity:  &emsp;</td>")
        ss.Append("<td style='width:60%;'>01-03-2023</td>")
        ss.Append("</tr>")
        ss.Append("</table>")
        ss.Append("</div>")


        ss.Append("<div style='height: 24px;background-color: blue; color: white;'>")
        ss.Append("<span class='text-sm'>Salt Lake, Kolkata-700064</span>")
        ss.Append("</div>")



        ss.Append("</div>")

        ss.Append("</div>")
        ss.Append("</div>")
        htmltext = ss.ToString
        Return htmltext
    End Function

    Public Function studentidformattwo() As String
        Dim ss As StringBuilder = New StringBuilder()
        Dim htmltext As String
        Dim p As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & VirtualPathUtility.ToAbsolute("~/")

        Dim da As New OdbcDataAdapter("SELECT * FROM student_ledger where reg_no='" & txtsearchname.Text & "' and company_id='" & Session("comid") & "'", dbcon.con)
        Dim ds As New DataSet
        da.Fill(ds)

        Dim da1 As New OdbcDataAdapter("select * from company_details where id='" & Session("comid") & "'", dbcon.con)
        Dim ds1 As New DataSet
        da1.Fill(ds1)

        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")
        ss.Append("<div style='position:relative;border: 0px solid #000000;margin-top:16px;margin-bottom:16px;padding:0.01em 16px;'>")

        ss.Append("<div style='width: 550px;'>")
        ss.Append("<div class='card bg-light d-flex flex-fill'>")
        ss.Append("<div class='card-header text-muted border-bottom-0 bg-gradient-primary text-white text-center'>")
        ss.Append("<h2>IDENTITY CARD</h2>")
        ss.Append("</div>")

        ss.Append("<div class='card-body pt-0'>")
        ss.Append("</br>")
        ss.Append(" <div class='row'>")
        ss.Append("<div class='col-7'>")
        ss.Append("<h4 class=' text-primary text-lg'>" & ds1.Tables(0).Rows(0).Item("company_name") & "</h4>")
        ss.Append("<h2 class='lead'><b>" & ds.Tables(0).Rows(0).Item("student_name") & "</b></h2>")
        ss.Append("<p class='text-muted text-sm'><b>Class: </b>" & ds.Tables(0).Rows(0).Item("class") & "</p>")
        ss.Append("<p class='text-muted text-sm'><b>Blood Group:</b> " & ds.Tables(0).Rows(0).Item("blood_grp") & "</p>")
        ss.Append("<p class='text-muted text-sm'><b>Emergency Contact: </b>" & ds.Tables(0).Rows(0).Item("emergency_contact1_phn") & " ,</br>" & ds.Tables(0).Rows(0).Item("emergency_contact2_phn") & "</p>")
        ss.Append(" <p class='text-muted text-sm'><b>Validity: </b>2022-2023</p>")
        ss.Append("</div>")
        ss.Append("<div><img src='" & p & "img/student_img.jpg' alt='student-image' style='width: 200px; height: 200px;object-fit: cover; border-radius: 50%;background-position:center;'></div>")
        ss.Append("</div>")
        ss.Append("</div>")
        ss.Append("<div class='card-footer bg-gradient-primary text-white text-sm'>" & ds1.Tables(0).Rows(0).Item("address") & "</div>")
        ss.Append("</div>")

        ss.Append("</div>")

        ss.Append("</div>")
        ss.Append("</div>")
        htmltext = ss.ToString
        Return htmltext
    End Function

    Protected Sub btndocument_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndocument.ServerClick
        'viewreg.InnerHtml = studentreg.ToString
        'viewreg.InnerHtml = studentidformatone.ToString
        viewreg.InnerHtml = studentidformattwo.ToString
    End Sub


End Class
