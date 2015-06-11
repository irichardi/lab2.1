<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="lab2.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Students</h1>
    <a href="student.aspx">Add Students</a>

    <asp:GridView ID="grdStudent" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" OnRowDeleting="grdStudent_RowDeleting"
        DataKeyNames="StudentID">
        <Columns>
                   
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="FirstMidName" HeaderText="Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />

            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="student.aspx" 
                 Text="Edit" DataNavigateUrlFields="StudentID"
                 DataNavigateUrlFormatString="student.aspx?StudentID={0}" />

            <asp:CommandField DeleteText="Delete" ShowDeleteButton="true" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
