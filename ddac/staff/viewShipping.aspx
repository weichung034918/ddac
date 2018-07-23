<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewShipping.aspx.cs" Inherits="ddac.staff.viewShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="approvalData" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" runat="server" SelectCommand="select a.id, a.date,a.status,a.cost,a.remark,a.departure_port,a.container_size,name as arrival_port from (select shipping.id, shipping.date,shipping.status,shipping.cost,shipping.remark,shipping.arrival_port, port.name as departure_port,container.size as container_size,container.id as container_id from shipping inner join port on departure_port = port.id join container on container.id = container_id where status='PENDING APPROVAL') a join port on a.arrival_port = port.id;">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="arrivalData" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" runat="server" SelectCommand="select a.id, a.date,a.status,a.cost,a.remark,a.departure_port,a.container_size,name as arrival_port from (select shipping.id, shipping.date,shipping.status,shipping.cost,shipping.remark,shipping.arrival_port, port.name as departure_port,container.size as container_size,container.id as container_id from shipping inner join port on departure_port = port.id join container on container.id = container_id where status='PENDING ARRIVAL') a join port on a.arrival_port = port.id;">
    </asp:SqlDataSource>

    <br />
    <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" id="Title1" style="text-align: left;" CssClass="col-md-12 control-label" Font-Size="Large" >Approval Table</asp:Label>
            </div>
    </div>
    <asp:GridView ID="tableApproval" CssClass="table table-striped table-bordered table-condensed" runat="server" 
            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="approvalData" OnRowCommand="tableAction">
        <Columns>            
            <asp:BoundField 
                DataField="id" 
                HeaderText="ID" 
                SortExpression="id"  
                InsertVisible="False" 
                ReadOnly="True" />
            <asp:BoundField 
                DataField="date" 
                HeaderText="Date" 
                SortExpression="date"/>
            <asp:BoundField 
                DataField="departure_port" 
                HeaderText="Departure" 
                SortExpression="departure_port"/>
            <asp:BoundField 
                DataField="arrival_port" 
                HeaderText="Arrival" 
                SortExpression="arrival_port"/>
            <asp:BoundField 
                DataField="cost" 
                HeaderText="Cost" 
                SortExpression="cost"/>
            <asp:BoundField 
                DataField="container_size" 
                HeaderText="Container Size" 
                SortExpression="container_size"/>
            <asp:BoundField 
                DataField="remark" 
                HeaderText="Remark" 
                SortExpression="remark"/>
            <asp:BoundField 
                DataField="status" 
                HeaderText="Status"     
                SortExpression="status" />
            <asp:ButtonField 
                CommandName="approval" 
                Text="Approve" />
        </Columns>
    </asp:GridView>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" id="emptyApproval" style="text-align: left;" CssClass="col-md-12 control-label" Font-Size="Large" Visible="false">There is no pending Approval for Shipping!</asp:Label>
            </div>
        </div>
    <br />
    <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" id="Title2" style="text-align: left;" CssClass="col-md-12 control-label" Font-Size="Large" >Arrival Table</asp:Label>
            </div>
    </div>
    <asp:GridView ID="tableArrival" CssClass="table table-striped table-bordered table-condensed" runat="server" 
            AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="arrivalData" OnRowCommand="tableAction">
        <Columns>            
            <asp:BoundField 
                DataField="id" 
                HeaderText="ID" 
                SortExpression="id"  
                InsertVisible="False" 
                ReadOnly="True" />
            <asp:BoundField 
                DataField="date" 
                HeaderText="Date" 
                SortExpression="date"/>
            <asp:BoundField 
                DataField="departure_port" 
                HeaderText="Departure" 
                SortExpression="departure_port"/>
            <asp:BoundField 
                DataField="arrival_port" 
                HeaderText="Arrival" 
                SortExpression="arrival_port"/>
            <asp:BoundField 
                DataField="cost" 
                HeaderText="Cost" 
                SortExpression="cost"/>
            <asp:BoundField 
                DataField="container_size" 
                HeaderText="Container Size" 
                SortExpression="container_size"/>
            <asp:BoundField 
                DataField="remark" 
                HeaderText="Remark" 
                SortExpression="remark"/>
            <asp:BoundField 
                DataField="status" 
                HeaderText="Status"     
                SortExpression="status" />
            <asp:ButtonField 
                CommandName="arrival" 
                Text="Confirm Arrival" />
        </Columns>
    </asp:GridView>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" id="emptyArrival" style="text-align: left;" CssClass="col-md-12 control-label" Font-Size="Large" Visible="false">There is no pending Arrival for Shipping!</asp:Label>
            </div>
        </div>
</asp:Content>
