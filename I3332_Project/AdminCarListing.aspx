<%@ Page Title="Car Listing" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdminCarListing.aspx.cs" Inherits="I3332_Project.AdminCarListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        /* Custom styling */
        .car-box {
            border: 1px solid #ccc;
            padding: 15px;
            margin: 10px;
            width: 250px;
            display: inline-block;
            vertical-align: top;
            border-radius: 8px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
            background-color: #fff;
        }

        .car-box img {
            width: 100%;
            height: 150px;
            object-fit: cover;
            border-radius: 5px;
        }

        .car-box h3 {
            font-size: 1.2rem;
            font-weight: bold;
            margin: 10px 0;
        }

        .car-box p {
            font-size: 1rem;
            margin: 5px 0;
        }

        .car-box a {
            font-size: 1rem;
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
        }

        .car-box a:hover {
            text-decoration: underline;
        }
    </style>

    <div class="container my-4">
        <asp:Panel ID="pnlAddCar" runat="server" CssClass="add-car-form">
    <h2>Add New Car Listing</h2>

    <asp:Label runat="server" AssociatedControlID="txtBrand" Text="Brand:" />
    <asp:TextBox ID="txtBrand" runat="server" />

    <asp:Label runat="server" AssociatedControlID="txtModel" Text="Model:" />
    <asp:TextBox ID="txtModel" runat="server" />

    <asp:Label runat="server" AssociatedControlID="txtType" Text="Type:" />
    <asp:TextBox ID="txtType" runat="server" />

    <asp:Label runat="server" AssociatedControlID="txtPricePerDay" Text="Price per Day:" />
    <asp:TextBox ID="txtPricePerDay" runat="server" />

    <asp:Label runat="server" AssociatedControlID="txtImagePath" Text="Image Path:" />
    <asp:TextBox ID="txtImagePath" runat="server" />

    <asp:Label runat="server" AssociatedControlID="chkAvailable" Text="Available?" />
    <asp:CheckBox ID="chkAvailable" runat="server" Checked="true" />

    <br />
    <asp:Button ID="btnAddCar" runat="server" Text="Add Car" OnClick="btnAddCar_Click" CssClass="btn btn-primary" />
    <asp:Label ID="lblAddCarMessage" runat="server" ForeColor="Red" />
</asp:Panel>

<hr />
      
        
        <h2 class="text-center">Available Cars for Rent</h2>
        <asp:Repeater ID="rptCars" runat="server">
            <ItemTemplate>
                <div class="car-box">
                    <img src='<%# Eval("ImagePath") %>' alt="Car Image" class="img-fluid" />
                    <h3><%# Eval("Brand") %> <%# Eval("Model") %></h3>
                    <p>Type: <%# Eval("Type") %></p>
                    <p>Price Per Day: $<%# Eval("PricePerDay") %></p>
<a href='Update.aspx?id=<%# Eval("Id") %>'>edit </a>
<asp:Button 
    ID="btnDelete" 
    runat="server" 
    Text="Delete" 
    CssClass="btn btn-danger" 
    CommandName="DeleteCar" 
    CommandArgument='<%# Eval("Id") %>' 
    OnCommand="Btn_Delete" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
