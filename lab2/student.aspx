<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="lab2.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Students</h1>

    <h5>Please fill all fields.</h5>
    <div class="form-group">
        <label for="txtStuID" class="col-sm-3">Student ID:</label>
        <asp:TextBox ID="txtStuID" runat="server" required="true" MaxLength="15" />
        <asp:RangeValidator runat="server" ControlToValidate="txtStuID"
             CssClass="label label-info" ErrorMessage="Your ID should be a number between 0 and 10,000,000"
         MinimumValue="0" MaximumValue="10000000" Type="Integer" />

    </div>
    <div class="form-group">
        <label for="txtName" class="col-sm-3">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required="true" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtlName" class="col-sm-3">Last Name:</label>
        <asp:TextBox ID="txtlName" runat="server" required="true" MaxLength="70" />
    </div>

    <div class="col-sm-offset-3">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary"
             OnClick="btnSave_Click" />
    </div>
</asp:Content>
