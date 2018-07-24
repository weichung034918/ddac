<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewPort.aspx.cs" Inherits="ddac.staff.viewPort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="portData" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" runat="server" SelectCommand="select * from port">
    </asp:SqlDataSource>

    
    <br />
    <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" id="Title1" style="text-align: left;" CssClass="col-md-12 control-label" Font-Size="Large" >Ports</asp:Label>
            </div>
    </div>
    <asp:GridView ID="portTable" CssClass="table table-striped table-bordered table-condensed" runat="server" 
            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="portData" OnRowCommand="tableAction">
        <Columns>            
            <asp:BoundField 
                DataField="id" 
                HeaderText="ID" 
                SortExpression="id"  
                InsertVisible="False" 
                ReadOnly="True" />
            <asp:BoundField 
                DataField="name" 
                HeaderText="Port" 
                SortExpression="name"/>
            <asp:BoundField 
                DataField="longtitude" 
                HeaderText="Longtitude" 
                SortExpression="longtitude"/>
            <asp:BoundField 
                DataField="Latitude" 
                HeaderText="latitude" 
                SortExpression="Latitude"/>
            <asp:ButtonField 
                CommandName="delete" 
                Text="Remove" />
        </Columns>
    </asp:GridView>
</asp:Content>
