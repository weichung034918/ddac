<%@ Page Title="New Port" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addPort.aspx.cs" Inherits="ddac.staff.addPort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create new Port.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="portName" CssClass="col-md-2 control-label">Port Name: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="portName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="portName"
                    CssClass="text-danger" ErrorMessage="The port name is required" />
            </div>
        </div>       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="longtitude" CssClass="col-md-2 control-label">longtitude: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="longtitude" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="longtitude"
                    CssClass="text-danger" ErrorMessage="Longtitude is required" Display="Dynamic" />
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="longtitude" CssClass="text-danger" Display="Dynamic" ErrorMessage="RangeValidator" MaximumValue="90" MinimumValue="-90" Type="Double">Range must be between -90 and 90</asp:RangeValidator>
            </div>
        </div> 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="latitude" CssClass="col-md-2 control-label">latitude:</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="latitude" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="latitude"
                    CssClass="text-danger" ErrorMessage="Latitude is required" Display="Dynamic" />
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="latitude" CssClass="text-danger" Display="Dynamic" ErrorMessage="RangeValidator" MaximumValue="90" MinimumValue="-90" Type="Double">Range must be between -90 and 90</asp:RangeValidator>
            </div>
        </div> 
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="createPort_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
