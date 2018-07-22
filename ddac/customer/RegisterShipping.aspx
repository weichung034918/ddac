<%@ Page Title="Submit Shipping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterShipping.aspx.cs" Inherits="ddac.customer.RegisterShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Submit new Shipping</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <asp:SqlDataSource ID="portList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT name, CONVERT(varchar(10), id) +','+ latitude  + ','+ longtitude AS port_location FROM Port;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="containerList" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="  SELECT size, CONVERT(varchar(10), id) +','+ rate AS container FROM container;"></asp:SqlDataSource>

         
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="departurePort" CssClass="col-md-2 control-label">Departure Port:</asp:Label>
            <div class="col-md-10"> 
                <asp:DropDownList ID="departurePort" AutoPostBack="True" OnSelectedIndexChanged="updatePrice" DataSourceID="portList" DataTextField="name" DataValueField="port_location" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Value="" Selected="True" Text="Select Departure Port"></asp:ListItem>
                </asp:DropDownList>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="departurePort"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="Pleas select departure Port" InitialValue=""></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="arrivalPort" CssClass="col-md-2 control-label">Arrival Port:</asp:Label>
            <div class="col-md-10"> 
                <asp:DropDownList ID="arrivalPort" AutoPostBack="True" OnSelectedIndexChanged="updatePrice" DataSourceID="portList" DataTextField="name" DataValueField="port_location" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Value="" Selected="True" Text="Select Arrival Port"></asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="arrivalPort"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="Pleas select departure Port" InitialValue=""></asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ControlToCompare="departurePort" ControlToValidate="arrivalPort"
                    CssClass="text-danger" Display="Dynamic" Operator="NotEqual" ErrorMessage="Departure port and arrival Port must not be same." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="containerSize" CssClass="col-md-2 control-label">Container Size:</asp:Label>
            <div class="col-md-10"> 
                <asp:DropDownList ID="containerSize" AutoPostBack="True" OnSelectedIndexChanged="updatePrice" DataSourceID="containerList" DataTextField="size" DataValueField="container" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Value="" Selected="True" Text="Select Container Size (kg) "></asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="containerSize"
                CssClass="text-danger" Display="Dynamic" ErrorMessage="Pleas select container size" InitialValue=""></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="remark" CssClass="col-md-2 control-label">Remark:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="remark" TextMode="MultiLine" Rows="3" CssClass="form-control" />
            </div>
        </div>         
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" Text="0" CssClass="form-control" Enabled="False" />
            </div>
        </div>       

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="registerShipping" Text="Submit" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
