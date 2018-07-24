<%@ Page Title="View Container" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewContainer.aspx.cs" Inherits="ddac.staff.viewContainer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:SqlDataSource ID="containerData" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" runat="server" SelectCommand="select * from container">
    </asp:SqlDataSource>

    
    <br />
    <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" id="Title1" style="text-align: left;" CssClass="col-md-12 control-label" Font-Size="Large" >Containers</asp:Label>
            </div>
    </div>
    <asp:GridView ID="containerTable" CssClass="table table-striped table-bordered table-condensed" runat="server" 
            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="containerData" OnRowCommand="tableAction">
        <Columns>            
            <asp:BoundField 
                DataField="id" 
                HeaderText="ID" 
                SortExpression="id"  
                InsertVisible="False" 
                ReadOnly="True" />
            <asp:BoundField 
                DataField="size" 
                HeaderText="Size" 
                SortExpression="size"/>
            <asp:BoundField 
                DataField="rate" 
                HeaderText="Rate" 
                SortExpression="rate"/>
            <asp:ButtonField 
                CommandName="delete" 
                Text="Remove" />
        </Columns>
    </asp:GridView>
</asp:Content>
