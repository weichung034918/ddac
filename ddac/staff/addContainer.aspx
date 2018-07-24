<%@ Page Title="Add Container" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addContainer.aspx.cs" Inherits="ddac.staff.addContainer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create new Container Category.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="size" CssClass="col-md-2 control-label">Port Name: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="size" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="size"
                    CssClass="text-danger" ErrorMessage="The size of container is required" />
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="size" CssClass="text-danger" Display="Dynamic" ErrorMessage="RangeValidator" MinimumValue="0.0001" Type="Double">Range must be bigger than 0</asp:RangeValidator>
            </div>
        </div>       
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="rate" CssClass="col-md-2 control-label">Rate: </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="rate" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="rate"
                    CssClass="text-danger" ErrorMessage="Rate is required" Display="Dynamic" />
                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="rate" CssClass="text-danger" Display="Dynamic" ErrorMessage="RangeValidator" MinimumValue="0.0001" Type="Double">Range must be bigger than 0</asp:RangeValidator>
            </div>
        </div> 
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="createContainer_Click" Text="Confirm" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
