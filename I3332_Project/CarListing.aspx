<%@ Page Title="Car Listing" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CarListing.aspx.cs" Inherits="I3332_Project.CarListing" %>

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
        <h2 class="text-center">Available Cars for Rent</h2>
        <asp:Repeater ID="rptCars" runat="server">
            <ItemTemplate>
                <div class="car-box">
                    <img src='<%# Eval("ImagePath") %>' alt="Car Image" class="img-fluid" />
                    <h3><%# Eval("Brand") %> <%# Eval("Model") %></h3>
                    <p>Type: <%# Eval("Type") %></p>
                    <p>Price Per Day: $<%# Eval("PricePerDay") %></p>
<a href='BookCar.aspx?id=<%# Eval("Id") %>'>Book Now</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
