<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="BookCar.aspx.cs" Inherits="I3332_Project.BookCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Book This Car</h2>

    <!-- Main container for left and right sections -->
    <div style="display: flex; justify-content: space-between;">

        <!-- Left section for car details -->
        <div style="width: 60%; padding-right: 20px;">
            <asp:Panel ID="pnlCarInfo" runat="server">
                <asp:Image ID="imgCar" runat="server" Width="300px" />
                <h3><asp:Label ID="lblBrandModel" runat="server" /></h3>
                <p><asp:Label ID="lblType" runat="server" /></p>
                <p>Price Per Day: $<asp:Label ID="lblPricePerDay" runat="server" /></p>
            </asp:Panel>

            <br />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" /><br />

            <label>Start Date:</label>
            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" /><br /><br />

            <label>End Date:</label>
            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" /><br /><br />

            <asp:Button ID="btnBook" runat="server" Text="Confirm Booking" OnClick="btnBook_Click" />
        </div>

        <!-- Right section for the form -->
        <div style="width: 35%; border-left: 2px solid #ccc; padding-left: 20px;">
            <h3>delivery Information optional</h3>
            <form>
                <!-- Location Field -->
                <label for="txtLocation">Location:</label><br />
                <asp:TextBox ID="txtLocation" runat="server" /><br /><br />

                <!-- Phone Number Field -->
                <label for="txtPhoneNumber">Phone Number:</label><br />
                <asp:TextBox ID="txtPhoneNumber" runat="server" /><br /><br />

                <!-- Price Field -->
                <label for="txtPrice">Price:</label><br />
                <asp:TextBox ID="txtPrice" runat="server" /><br /><br />

                <!-- Submit Button -->
            </form>
        </div>
    </div>
</asp:Content>
